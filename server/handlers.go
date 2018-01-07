package main

import (
	"bytes"
	"encoding/json"
	"io/ioutil"
	"log"
	"net/http"
	"strconv"
)

type StatsResponse struct {
	AttackerHits map[string]float64
	DefenderHits map[string]float64
}

func (s *AppServer) rootHandler(w http.ResponseWriter, r *http.Request) {
	var responseBody map[string]interface{}
	if r.URL.Path != "/" {
		responseBody = map[string]interface{}{
			"host": r.Host,
			"path": r.URL.Path,
		}
		s.writeJSON(w, r, responseBody, http.StatusNotFound)
		return
	}
	responseBody = map[string]interface{}{
		"host": r.Host,
		"path": r.URL.Path,
	}
	s.writeJSON(w, r, responseBody, http.StatusOK)
}

func (s *AppServer) landHandler(w http.ResponseWriter, r *http.Request) {
	w.Header().Set("Content-Type", "application/json")
	switch r.Method {
	case http.MethodGet:
		http.Error(w, "error", http.StatusMethodNotAllowed)
	case http.MethodPost:
		landBattle(s, w, r)
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

func (s *AppServer) seaHandler(w http.ResponseWriter, r *http.Request) {
	w.Header().Set("Content-Type", "application/json")
	switch r.Method {
	case http.MethodGet:
		http.Error(w, "error", http.StatusMethodNotAllowed)
	case http.MethodPost:
		seaBattle(s, w, r)
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

func (s *AppServer) airHandler(w http.ResponseWriter, r *http.Request) {
	w.Header().Set("Content-Type", "application/json")
	switch r.Method {
	case http.MethodGet:
		http.Error(w, "error", http.StatusMethodNotAllowed)
	case http.MethodPost:
		airBattle(s, w, r)
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

func landBattle(s *AppServer, w http.ResponseWriter, r *http.Request) {
	// Check for empty body
	if r.Body == nil {
		http.Error(w, "Please send a request body", 400)
		log.Println("stats post error", "no request body")
		return
	}
	// Read request body as bytes with a reader for decoding
	var bodyBytes []byte
	bodyBytes, err := ioutil.ReadAll(r.Body)
	if err != nil {
		http.Error(w, err.Error(), http.StatusInternalServerError)
		log.Println("stats post error", err.Error())
		return
	}
	bodyReader := bytes.NewReader(bodyBytes)
	// Decode bytes into battle
	var battle LandBattle
	if err := json.NewDecoder(bodyReader).Decode(&battle); err != nil {
		http.Error(w, err.Error(), http.StatusInternalServerError)
		log.Println("stats post error", err.Error())
		return
	}
	var attackers []Unit
	var defenders []Unit

	for i := 0; i < battle.AttackingInfantry; i++ {
		if i < battle.AttackingArtillery {
			attackers = append(attackers, Unit{Attack: 2, Defense: 2, Move: 1, Cost: 3})
		} else {
			attackers = append(attackers, Unit{Attack: 1, Defense: 2, Move: 1, Cost: 3})
		}
	}
	for i := 0; i < battle.AttackingArtillery; i++ {
		attackers = append(attackers, Unit{Attack: 2, Defense: 2, Move: 1, Cost: 4})
	}
	for i := 0; i < battle.AttackingMechanizedInfantry; i++ {
		attackers = append(attackers, Unit{Attack: 1, Defense: 2, Move: 2, Cost: 4})
	}
	for i := 0; i < battle.AttackingTanks; i++ {
		attackers = append(attackers, Unit{Attack: 3, Defense: 3, Move: 2, Cost: 6})
	}
	for i := 0; i < battle.AttackingFighters; i++ {
		attackers = append(attackers, Unit{Attack: 3, Defense: 4, Move: 4, Cost: 10})
	}
	for i := 0; i < battle.AttackingTacticalBombers; i++ {
		attackers = append(attackers, Unit{Attack: 3, Defense: 3, Move: 4, Cost: 11})
	}
	for i := 0; i < battle.AttackingStrategicBombers; i++ {
		attackers = append(attackers, Unit{Attack: 4, Defense: 1, Move: 6, Cost: 12})
	}

	for i := 0; i < battle.DefendingInfantry; i++ {
		defenders = append(defenders, Unit{Attack: 1, Defense: 2, Move: 1, Cost: 3})
	}
	for i := 0; i < battle.DefendingArtillery; i++ {
		defenders = append(defenders, Unit{Attack: 2, Defense: 2, Move: 1, Cost: 4})
	}
	for i := 0; i < battle.DefendingMechanizedInfantry; i++ {
		defenders = append(defenders, Unit{Attack: 1, Defense: 2, Move: 2, Cost: 4})
	}
	for i := 0; i < battle.DefendingTanks; i++ {
		defenders = append(defenders, Unit{Attack: 3, Defense: 3, Move: 2, Cost: 6})
	}
	for i := 0; i < battle.DefendingFighters; i++ {
		defenders = append(defenders, Unit{Attack: 3, Defense: 4, Move: 4, Cost: 10})
	}
	for i := 0; i < battle.DefendingTacticalBombers; i++ {
		defenders = append(defenders, Unit{Attack: 3, Defense: 3, Move: 4, Cost: 11})
	}
	for i := 0; i < battle.DefendingStrategicBombers; i++ {
		defenders = append(defenders, Unit{Attack: 4, Defense: 1, Move: 6, Cost: 12})
	}

	response := StatsResponse{
		AttackerHits: make(map[string]float64),
		DefenderHits: make(map[string]float64),
	}

	for i := 0; i <= len(attackers); i++ {
		response.AttackerHits[strconv.Itoa(i)] = oddsOf(attackers, i, true)
	}
	for i := 0; i <= len(defenders); i++ {
		response.DefenderHits[strconv.Itoa(i)] = oddsOf(defenders, i, false)
	}

	json.NewEncoder(w).Encode(response)
}

func seaBattle(s *AppServer, w http.ResponseWriter, r *http.Request) {
	// Check for empty body
	if r.Body == nil {
		http.Error(w, "Please send a request body", 400)
		log.Println("stats post error", "no request body")
		return
	}
	// Read request body as bytes with a reader for decoding
	var bodyBytes []byte
	bodyBytes, err := ioutil.ReadAll(r.Body)
	if err != nil {
		http.Error(w, err.Error(), http.StatusInternalServerError)
		log.Println("stats post error", err.Error())
		return
	}
	bodyReader := bytes.NewReader(bodyBytes)
	// Decode bytes into battle
	var battle SeaBattle
	if err := json.NewDecoder(bodyReader).Decode(&battle); err != nil {
		http.Error(w, err.Error(), http.StatusInternalServerError)
		log.Println("stats post error", err.Error())
		return
	}
	var attackers []Unit
	var defenders []Unit

	for i := 0; i < battle.AttackingSubmarines; i++ {
		attackers = append(attackers, Unit{Attack: 2, Defense: 1, Move: 2, Cost: 6})
	}
	for i := 0; i < battle.AttackingDestroyers; i++ {
		attackers = append(attackers, Unit{Attack: 2, Defense: 2, Move: 2, Cost: 8})
	}
	for i := 0; i < battle.AttackingCrusiers; i++ {
		attackers = append(attackers, Unit{Attack: 3, Defense: 3, Move: 2, Cost: 12})
	}
	for i := 0; i < battle.AttackingBattleships; i++ {
		attackers = append(attackers, Unit{Attack: 4, Defense: 4, Move: 2, Cost: 20})
	}
	for i := 0; i < battle.AttackingAircraftCarriers; i++ {
		attackers = append(attackers, Unit{Attack: 1, Defense: 2, Move: 2, Cost: 14})
	}
	for i := 0; i < battle.AttackingFighters; i++ {
		attackers = append(attackers, Unit{Attack: 3, Defense: 4, Move: 4, Cost: 10})
	}
	for i := 0; i < battle.AttackingTacticalBombers; i++ {
		attackers = append(attackers, Unit{Attack: 3, Defense: 3, Move: 4, Cost: 11})
	}
	for i := 0; i < battle.AttackingStrategicBombers; i++ {
		attackers = append(attackers, Unit{Attack: 4, Defense: 1, Move: 6, Cost: 12})
	}

	for i := 0; i < battle.DefendingSubmarines; i++ {
		defenders = append(defenders, Unit{Attack: 2, Defense: 1, Move: 2, Cost: 6})
	}
	for i := 0; i < battle.DefendingDestroyers; i++ {
		defenders = append(defenders, Unit{Attack: 2, Defense: 2, Move: 2, Cost: 8})
	}
	for i := 0; i < battle.DefendingCrusiers; i++ {
		defenders = append(defenders, Unit{Attack: 3, Defense: 3, Move: 2, Cost: 12})
	}
	for i := 0; i < battle.DefendingBattleships; i++ {
		defenders = append(defenders, Unit{Attack: 4, Defense: 4, Move: 2, Cost: 20})
	}
	for i := 0; i < battle.DefendingAircraftCarriers; i++ {
		defenders = append(defenders, Unit{Attack: 1, Defense: 2, Move: 4, Cost: 14})
	}
	for i := 0; i < battle.DefendingFighters; i++ {
		defenders = append(defenders, Unit{Attack: 3, Defense: 4, Move: 4, Cost: 10})
	}
	for i := 0; i < battle.DefendingTacticalBombers; i++ {
		defenders = append(defenders, Unit{Attack: 3, Defense: 3, Move: 4, Cost: 11})
	}
	for i := 0; i < battle.DefendingStrategicBombers; i++ {
		defenders = append(defenders, Unit{Attack: 4, Defense: 1, Move: 6, Cost: 12})
	}

	response := StatsResponse{
		AttackerHits: make(map[string]float64),
		DefenderHits: make(map[string]float64),
	}

	for i := 0; i <= len(attackers); i++ {
		response.AttackerHits[strconv.Itoa(i)] = oddsOf(attackers, i, true)
	}
	for i := 0; i <= len(defenders); i++ {
		response.DefenderHits[strconv.Itoa(i)] = oddsOf(defenders, i, false)
	}

	json.NewEncoder(w).Encode(response)
}

func airBattle(s *AppServer, w http.ResponseWriter, r *http.Request) {
	// Check for empty body
	if r.Body == nil {
		http.Error(w, "Please send a request body", 400)
		log.Println("stats post error", "no request body")
		return
	}
	// Read request body as bytes with a reader for decoding
	var bodyBytes []byte
	bodyBytes, err := ioutil.ReadAll(r.Body)
	if err != nil {
		http.Error(w, err.Error(), http.StatusInternalServerError)
		log.Println("stats post error", err.Error())
		return
	}
	bodyReader := bytes.NewReader(bodyBytes)
	// Decode bytes into battle
	var battle AirBattle
	if err := json.NewDecoder(bodyReader).Decode(&battle); err != nil {
		http.Error(w, err.Error(), http.StatusInternalServerError)
		log.Println("stats post error", err.Error())
		return
	}
	var attackers []Unit
	var defenders []Unit

	for i := 0; i < battle.AttackingFighters; i++ {
		attackers = append(attackers, Unit{Attack: 3, Defense: 4, Move: 4, Cost: 10})
	}
	for i := 0; i < battle.AttackingTacticalBombers; i++ {
		attackers = append(attackers, Unit{Attack: 3, Defense: 3, Move: 4, Cost: 11})
	}
	for i := 0; i < battle.AttackingStrategicBombers; i++ {
		attackers = append(attackers, Unit{Attack: 4, Defense: 1, Move: 6, Cost: 12})
	}

	for i := 0; i < battle.DefendingFighters; i++ {
		defenders = append(defenders, Unit{Attack: 3, Defense: 4, Move: 4, Cost: 10})
	}
	for i := 0; i < battle.DefendingTacticalBombers; i++ {
		defenders = append(defenders, Unit{Attack: 3, Defense: 3, Move: 4, Cost: 11})
	}
	for i := 0; i < battle.DefendingStrategicBombers; i++ {
		defenders = append(defenders, Unit{Attack: 4, Defense: 1, Move: 6, Cost: 12})
	}

	response := StatsResponse{
		AttackerHits: make(map[string]float64),
		DefenderHits: make(map[string]float64),
	}

	for i := 0; i <= len(attackers); i++ {
		response.AttackerHits[strconv.Itoa(i)] = oddsOf(attackers, i, true)
	}
	for i := 0; i <= len(defenders); i++ {
		response.DefenderHits[strconv.Itoa(i)] = oddsOf(defenders, i, false)
	}

	json.NewEncoder(w).Encode(response)
}
