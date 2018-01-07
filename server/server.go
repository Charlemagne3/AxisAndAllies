package main

import (
	"encoding/json"
	"log"
	"net/http"
	"reflect"
	"time"
	"strconv"

	"github.com/Charlemagne3/AxisAndAllies/server/util"
)

type appServer struct {
	server     *http.Server
	tlsServer  *http.Server
	router     *http.ServeMux
	createTime time.Time
}

func (s *appServer) ListenAndServe() {
	log.Println("Starting HTTP server on", s.server.Addr)
	log.Fatal(s.server.ListenAndServe())
}

func (s *appServer) ListenAndServeTLS() {
	log.Println("Starting HTTPS server on", s.tlsServer.Addr)
	log.Fatal(s.tlsServer.ListenAndServeTLS(conf.TLSCertFile, conf.TLSKeyFile))
}

func makeServer() *appServer {
	s := appServer{}

	handler := buildPrimaryHandler(&s)

	s.server = &http.Server{
		Addr:    conf.AppAddress,
		Handler: handler,
	}

	s.tlsServer = &http.Server{
		Addr:    conf.TLSAddress,
		Handler: handler,
	}

	s.createTime = time.Now().UTC()

	return &s
}

func buildPrimaryHandler(s *appServer) http.Handler {
	routerV1 := http.NewServeMux()

	routerV1.HandleFunc("/", s.indexHandler)
	routerV1.HandleFunc("/health", s.healthHandler)
	routerV1.HandleFunc("/battle/land/", validate(s.landHandler))
	routerV1.HandleFunc("/battle/sea/", validate(s.seaHandler))
	routerV1.HandleFunc("/battle/air/", validate(s.airHandler))
	routerV1.HandleFunc("/get-token", s.jwtHandler)
	
	handler := util.AggregateHandler(routerV1, util.HTTPRecovery, util.HTTPLogger)
	return handler
}

func (s *appServer) writeJSON(w http.ResponseWriter, r *http.Request, body interface{}, code int) {
	contentTypes := []string{"application/json; charset=UTF-8"}
	w.Header()["Content-Type"] = contentTypes
	w.WriteHeader(code)
	err := json.NewEncoder(w).Encode(body)
	if err != nil {
		log.Panic(err)
	}
}
