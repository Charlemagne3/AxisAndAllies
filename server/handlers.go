package main

import (
	"log"
	"fmt"
	"net/http"
	"strings"
	"encoding/json"
	"io/ioutil"
	"bytes"
	"time"
	"strconv"

	crypto "github.com/SermoDigital/jose/crypto"
	jws "github.com/SermoDigital/jose/jws"
	jwt "github.com/SermoDigital/jose/jwt"
)

type CartographerResponse struct {
	Session Session
	Message string
}

// JWT middleware
func validate(authorizedRoute http.HandlerFunc) http.HandlerFunc {
	return http.HandlerFunc(func(w http.ResponseWriter, r *http.Request){
		parsedJWT, err := jws.ParseJWTFromRequest(r)
		if (err != nil) {
			http.Error(w, err.Error(), http.StatusUnauthorized)			
			return
		}
		v := jwt.Validator{}
		v.SetIssuer("default")
		v.SetAudience("default")
		v.SetSubject("axisandallies")
		err = v.Validate(parsedJWT)
		if (err != nil) {
			http.Error(w, err.Error(), http.StatusUnauthorized)			
			return
		}
		authorizedRoute(w, r)
	})
}

func (s *appServer) indexHandler(w http.ResponseWriter, r *http.Request) {
	var responseBody map[string]interface{}

	if r.URL.Path != "/" {
		responseBody = map[string]interface{}{
			"host":     r.Host,
			"path":     r.URL.Path,
		}
		s.writeJSON(w, r, responseBody, http.StatusNotFound)
		return
	}

	responseBody = map[string]interface{}{
		"host":     r.Host,
		"path":     r.URL.Path,
	}
	s.writeJSON(w, r, responseBody, http.StatusOK)
}

func (s *appServer) healthHandler(w http.ResponseWriter, r *http.Request) {
	responseBody := map[string]interface{}{
		"host":     r.Host,
		"path":     r.URL.Path,
	}
	s.writeJSON(w, r, responseBody, http.StatusOK)
}

func (s *appServer) sessionHandler(w http.ResponseWriter, r *http.Request) {
	w.Header().Set("Content-Type", "application/json")
	switch r.Method {
	case http.MethodGet:
		sessionGet(s, w, r)
	case http.MethodPost:
		sessionPost(s, w, r)
	case http.MethodPut:
		http.Error(w, "error", http.StatusMethodNotAllowed)
	case http.MethodPatch:
		http.Error(w, "error", http.StatusMethodNotAllowed)
	case http.MethodDelete:
		http.Error(w, "error", http.StatusMethodNotAllowed)
	default:
		http.Error(w, "error", http.StatusMethodNotAllowed)
	}
}

func statsGet(s *appServer, w http.ResponseWriter, r *http.Request) {
	response := StatsResponse{}
	var stats Stats{}
	response.Stats = stats
	json.NewEncoder(w).Encode(response)
}

func statsPost(s *appServer, w http.ResponseWriter, r *http.Request) {
	// Check for empty body
	if r.Body == nil {
		http.Error(w, "Please send a request body", 400)
		log.Println("post error", "no request body")
		return
	}
	// Read request body as bytes with a reader for decoding
	var bodyBytes []byte
	bodyBytes, err := ioutil.ReadAll(r.Body)
	bodyReader := bytes.NewReader(bodyBytes)
	// Decode bytes into session
	var bodySession Session
	if err := json.NewDecoder(bodyReader).Decode(&bodySession);
	err != nil {
		http.Error(w, err.Error(), http.StatusInternalServerError)
		log.Println("session post error", err.Error())
		return
	}
	// Get existing session
	var existingSession Session
	sessionJson, err := s.redisClient.Get(fmt.Sprintf("router:session-tracker:%s", bodySession.Id)).Result()
	if err == redis.Nil {
		// Create empty session object if there is no existing session
	} else if err != nil {
		http.Error(w, err.Error(), http.StatusInternalServerError)
		log.Println("session post error", err.Error())
		return
	} else {
		// If the session exists, unmarshal the json
		json.Unmarshal([]byte(sessionJson), &existingSession)
	}
	bodyReader = bytes.NewReader(bodyBytes)
	err = json.NewDecoder(bodyReader).Decode(&existingSession)
	if err != nil {
		http.Error(w, err.Error(), http.StatusInternalServerError)
		log.Println("session post error", err.Error())
		return
	}
}

func (s *appServer) jwtHandler(w http.ResponseWriter, r *http.Request) {
	claims := jws.Claims{}
	claims.SetIssuer("default")
	claims.SetAudience("cartographer")
	claims.SetSubject("cartographer")
	token := jws.NewJWT(claims, crypto.SigningMethodHS256)
	serial, err := token.Serialize([]byte(conf.JwtKey))
	if (err != nil) {
		http.Error(w, err.Error(), http.StatusInternalServerError)
		return
	}
	w.Write([]byte(serial))	
}