package main

import (
	"log"

	"github.com/Charlemagne3/AxisAndAllies/server/config"
)

// Configuration
var conf *config.Configuration

func init() {
	conf = config.GetConfiguration()
}

func main() {
	// Write welcome message
	log.Printf("%s %s \n", conf.AppName, conf.AppVersion)

	// Start HTTP server.
	s := makeServer()
	go s.ListenAndServe()
	go s.ListenAndServeTLS()

	// Sleep forever.
	select {}
}
