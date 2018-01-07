package main

import (
	"flag"
	"log"

	"github.com/Charlemagne3/AxisAndAllies/server/config"
)

var conf *config.Configuration

func init() {
	if flag.Lookup("test.v") == nil {
		conf = config.GetConfiguration()
	}
}

func main() {
	log.Printf("%s %s \n", conf.AppName, conf.AppVersion)
	s := makeServer()
	s.ListenAndServe()
}
