package util

import (
	"log"
	"net/http"
	"time"
)

type StatusResponseWriter struct {
	http.ResponseWriter
	HTTPStatus   int
	ResponseSize int
}

func (w *StatusResponseWriter) WriteHeader(status int) {
	w.HTTPStatus = status
	w.ResponseWriter.WriteHeader(status)
}

func (w *StatusResponseWriter) Flush() {
	writer := w.ResponseWriter
	if f, ok := writer.(http.Flusher); ok {
		f.Flush()
	}
}

func (w *StatusResponseWriter) CloseNotify() <-chan bool {
	writer := w.ResponseWriter
	return writer.(http.CloseNotifier).CloseNotify()
}

func (w *StatusResponseWriter) Write(b []byte) (int, error) {
	if w.HTTPStatus == 0 {
		w.HTTPStatus = 200
	}
	w.ResponseSize = len(b)
	return w.ResponseWriter.Write(b)
}

func HTTPLogger(handler http.Handler) http.Handler {
	return http.HandlerFunc(func(w http.ResponseWriter, r *http.Request) {
		log.Printf("%s %s %s", r.RemoteAddr, r.Method, r.URL)
		t := time.Now()
		interceptWriter := StatusResponseWriter{w, 0, 0}

		handler.ServeHTTP(&interceptWriter, r)
		log.Printf("%s - - %s \"%s %s %s\" %d %d %s %dus\n",
			r.RemoteAddr,
			t.Format("02/Jan/2006:15:04:05 -0700"),
			r.Method,
			r.URL.Path,
			r.Proto,
			interceptWriter.HTTPStatus,
			interceptWriter.ResponseSize,
			r.UserAgent(),
			time.Since(t),
		)
	})
}
