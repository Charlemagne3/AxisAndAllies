package main

import (
	"encoding/json"
	"log"
	"net/http"
	"time"

	"github.com/Charlemagne3/AxisAndAllies/server/util"
)

type AppServer struct {
	server     *http.Server
	router     *http.ServeMux
	createTime time.Time
}

func (s *AppServer) ListenAndServe() {
	log.Println("Starting HTTP server on", s.server.Addr)
	log.Fatal(s.server.ListenAndServe())
}

func makeServer() *AppServer {
	s := AppServer{}
	handler := buildHandler(&s)
	s.server = &http.Server{
		Addr:    conf.Address,
		Handler: handler,
	}
	s.createTime = time.Now().UTC()
	return &s
}

func buildHandler(s *AppServer) http.Handler {
	router := http.NewServeMux()

	router.HandleFunc("/", s.rootHandler)
	router.HandleFunc("/api/v0/battle/land", s.landHandler)
	router.HandleFunc("/api/v0/battle/sea", s.seaHandler)
	router.HandleFunc("/api/v0/battle/air", s.airHandler)

	handler := util.AggregateHandler(router, util.HTTPRecovery, util.HTTPLogger)
	return handler
}

func (s *AppServer) writeJSON(w http.ResponseWriter, r *http.Request, body interface{}, code int) {
	contentTypes := []string{"application/json; charset=UTF-8"}
	w.Header()["Content-Type"] = contentTypes
	w.WriteHeader(code)
	err := json.NewEncoder(w).Encode(body)
	if err != nil {
		log.Panic(err)
	}
}
