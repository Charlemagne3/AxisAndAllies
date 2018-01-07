package main

import (
	"log"
	"testing"
)

func TestGetHitCombinations0(t *testing.T) {
	combinations := getHitCombinations(0, 1)
	expected := [][]bool{[]bool{false}}
	log.Printf("combinations: %v", combinations)
	log.Printf("expected: %v", expected)
	if combinations[0][0] != expected[0][0] {
		t.Errorf("wrong, got: %v, want: %v", combinations[0][0], expected[0][0])
	}
}

func TestGetHitCombinations1(t *testing.T) {
	combinations := getHitCombinations(1, 1)
	expected := [][]bool{[]bool{true}}
	log.Printf("combinations: %v", combinations)
	log.Printf("expected: %v", expected)
	if combinations[0][0] != expected[0][0] {
		t.Errorf("wrong, got: %v, want: %v", combinations[0][0], expected[0][0])
	}
}

func TestGetHitCombinations2(t *testing.T) {
	combinations := getHitCombinations(1, 2)
	expected := [][]bool{[]bool{false, true}, []bool{true, false}}
	log.Printf("combinations: %v", combinations)
	log.Printf("expected: %v", expected)
	if combinations[0][0] != expected[0][0] {
		t.Errorf("wrong, got: %v, want: %v", combinations[0][0], expected[0][0])
	}
	if combinations[0][1] != expected[0][1] {
		t.Errorf("wrong, got: %v, want: %v", combinations[0][1], expected[0][1])
	}
	if combinations[1][0] != expected[1][0] {
		t.Errorf("wrong, got: %v, want: %v", combinations[1][0], expected[1][0])
	}
	if combinations[1][1] != expected[1][1] {
		t.Errorf("wrong, got: %v, want: %v", combinations[1][1], expected[1][1])
	}
}

func TestOneInfantryZeroHits(t *testing.T) {
	attackers := []Unit{
		Unit{Attack: 1, Defense: 2, Move: 1, Cost: 3},
	}
	odds := oddsOf(attackers, 0, true)
	log.Printf("odds: %v", odds)
	expected := 5 / 6.0
	if odds != expected {
		t.Errorf("wrong, got: %v, want: %v", odds, expected)
	}
}

func TestOneInfantryOneHit(t *testing.T) {
	attackers := []Unit{
		Unit{Attack: 1, Defense: 2, Move: 1, Cost: 3},
	}
	odds := oddsOf(attackers, 1, true)
	log.Printf("odds: %v", odds)
	expected := 1 / 6.0
	if odds != expected {
		t.Errorf("wrong, got: %v, want: %v", odds, expected)
	}
}

func TestTwoInfantryZeroHits(t *testing.T) {
	attackers := []Unit{
		Unit{Attack: 1, Defense: 2, Move: 1, Cost: 3},
		Unit{Attack: 1, Defense: 2, Move: 1, Cost: 3},
	}
	odds := oddsOf(attackers, 0, true)
	log.Printf("odds: %v", odds)
	expected := 25 / 36.0
	if odds != expected {
		t.Errorf("wrong, got: %v, want: %v", odds, expected)
	}
}

func TestTwoInfantryOneHit(t *testing.T) {
	attackers := []Unit{
		Unit{Attack: 1, Defense: 2, Move: 1, Cost: 3},
		Unit{Attack: 1, Defense: 2, Move: 1, Cost: 3},
	}
	odds := oddsOf(attackers, 1, true)
	log.Printf("odds: %v", odds)
	expected := 10 / 36.0
	if odds != expected {
		t.Errorf("wrong, got: %v, want: %v", odds, expected)
	}
}

func TestTwoInfantryTwoHits(t *testing.T) {
	attackers := []Unit{
		Unit{Attack: 1, Defense: 2, Move: 1, Cost: 3},
		Unit{Attack: 1, Defense: 2, Move: 1, Cost: 3},
	}
	odds := oddsOf(attackers, 2, true)
	log.Printf("odds: %v", odds)
	expected := 1 / 36.0
	if odds != expected {
		t.Errorf("wrong, got: %v, want: %v", odds, expected)
	}
}

func TestThreeInfantryZeroHits(t *testing.T) {
	attackers := []Unit{
		Unit{Attack: 1, Defense: 2, Move: 1, Cost: 3},
		Unit{Attack: 1, Defense: 2, Move: 1, Cost: 3},
		Unit{Attack: 1, Defense: 2, Move: 1, Cost: 3},
	}
	odds := oddsOf(attackers, 0, true)
	log.Printf("odds: %v", odds)
	expected := 125 / 216.0
	if odds != expected {
		t.Errorf("wrong, got: %v, want: %v", odds, expected)
	}
}

func TestThreeInfantryOneHit(t *testing.T) {
	attackers := []Unit{
		Unit{Attack: 1, Defense: 2, Move: 1, Cost: 3},
		Unit{Attack: 1, Defense: 2, Move: 1, Cost: 3},
		Unit{Attack: 1, Defense: 2, Move: 1, Cost: 3},
	}
	odds := oddsOf(attackers, 1, true)
	log.Printf("odds: %v", odds)
	expected := 75 / 216.0
	if odds != expected {
		t.Errorf("wrong, got: %v, want: %v", odds, expected)
	}
}

func TestThreeInfantryTwoHits(t *testing.T) {
	attackers := []Unit{
		Unit{Attack: 1, Defense: 2, Move: 1, Cost: 3},
		Unit{Attack: 1, Defense: 2, Move: 1, Cost: 3},
		Unit{Attack: 1, Defense: 2, Move: 1, Cost: 3},
	}
	odds := oddsOf(attackers, 2, true)
	log.Printf("odds: %v", odds)
	expected := 15 / 216.0
	if odds != expected {
		t.Errorf("wrong, got: %v, want: %v", odds, expected)
	}
}

func TestThreeInfantryThreeHits(t *testing.T) {
	attackers := []Unit{
		Unit{Attack: 1, Defense: 2, Move: 1, Cost: 3},
		Unit{Attack: 1, Defense: 2, Move: 1, Cost: 3},
		Unit{Attack: 1, Defense: 2, Move: 1, Cost: 3},
	}
	odds := oddsOf(attackers, 3, true)
	log.Printf("odds: %v", odds)
	expected := 1 / 216.0
	if odds != expected {
		t.Errorf("wrong, got: %v, want: %v", odds, expected)
	}
}

func TestFourInfantryZeroHits(t *testing.T) {
	attackers := []Unit{
		Unit{Attack: 1, Defense: 2, Move: 1, Cost: 3},
		Unit{Attack: 1, Defense: 2, Move: 1, Cost: 3},
		Unit{Attack: 1, Defense: 2, Move: 1, Cost: 3},
		Unit{Attack: 1, Defense: 2, Move: 1, Cost: 3},
	}
	odds := oddsOf(attackers, 0, true)
	log.Printf("odds: %v", odds)
	expected := 625 / 1296.0
	if odds != expected {
		t.Errorf("wrong, got: %v, want: %v", odds, expected)
	}
}

func TestFourInfantryOneHit(t *testing.T) {
	attackers := []Unit{
		Unit{Attack: 1, Defense: 2, Move: 1, Cost: 3},
		Unit{Attack: 1, Defense: 2, Move: 1, Cost: 3},
		Unit{Attack: 1, Defense: 2, Move: 1, Cost: 3},
		Unit{Attack: 1, Defense: 2, Move: 1, Cost: 3},
	}
	odds := oddsOf(attackers, 1, true)
	log.Printf("odds: %v", odds)
	expected := 500 / 1296.0
	if odds != expected {
		t.Errorf("wrong, got: %v, want: %v", odds, expected)
	}
}

func TestFourInfantryTwoHits(t *testing.T) {
	attackers := []Unit{
		Unit{Attack: 1, Defense: 2, Move: 1, Cost: 3},
		Unit{Attack: 1, Defense: 2, Move: 1, Cost: 3},
		Unit{Attack: 1, Defense: 2, Move: 1, Cost: 3},
		Unit{Attack: 1, Defense: 2, Move: 1, Cost: 3},
	}
	odds := oddsOf(attackers, 2, true)
	log.Printf("odds: %v", odds)
	expected := 150 / 1296.0
	if odds != expected {
		t.Errorf("wrong, got: %v, want: %v", odds, expected)
	}
}

func TestFourInfantryThreeHits(t *testing.T) {
	attackers := []Unit{
		Unit{Attack: 1, Defense: 2, Move: 1, Cost: 3},
		Unit{Attack: 1, Defense: 2, Move: 1, Cost: 3},
		Unit{Attack: 1, Defense: 2, Move: 1, Cost: 3},
		Unit{Attack: 1, Defense: 2, Move: 1, Cost: 3},
	}
	odds := oddsOf(attackers, 3, true)
	log.Printf("odds: %v", odds)
	expected := 20 / 1296.0
	if odds != expected {
		t.Errorf("wrong, got: %v, want: %v", odds, expected)
	}
}

func TestFourInfantryFourHits(t *testing.T) {
	attackers := []Unit{
		Unit{Attack: 1, Defense: 2, Move: 1, Cost: 3},
		Unit{Attack: 1, Defense: 2, Move: 1, Cost: 3},
		Unit{Attack: 1, Defense: 2, Move: 1, Cost: 3},
		Unit{Attack: 1, Defense: 2, Move: 1, Cost: 3},
	}
	odds := oddsOf(attackers, 4, true)
	log.Printf("odds: %v", odds)
	expected := 1 / 1296.0
	if odds != expected {
		t.Errorf("wrong, got: %v, want: %v", odds, expected)
	}
}
func TestOneTanksOneHit(t *testing.T) {
	attackers := []Unit{
		Unit{Attack: 3, Defense: 3, Move: 2, Cost: 6},
	}
	odds := oddsOf(attackers, 1, true)
	log.Printf("odds: %v", odds)
	expected := 3 / 6.0
	if odds != expected {
		t.Errorf("wrong, got: %v, want: %v", odds, expected)
	}
}

func TestTwoTanksOneHit(t *testing.T) {
	attackers := []Unit{
		Unit{Attack: 3, Defense: 3, Move: 2, Cost: 6},
		Unit{Attack: 3, Defense: 3, Move: 2, Cost: 6},
	}
	odds := oddsOf(attackers, 1, true)
	log.Printf("odds: %v", odds)
	expected := 3 / 6.0
	if odds != expected {
		t.Errorf("wrong, got: %v, want: %v", odds, expected)
	}
}

func TestThreeTanksOneHit(t *testing.T) {
	attackers := []Unit{
		Unit{Attack: 3, Defense: 3, Move: 2, Cost: 6},
		Unit{Attack: 3, Defense: 3, Move: 2, Cost: 6},
		Unit{Attack: 3, Defense: 3, Move: 2, Cost: 6},
	}
	odds := oddsOf(attackers, 1, true)
	log.Printf("odds: %v", odds)
	expected := 81 / 216.0
	if odds != expected {
		t.Errorf("wrong, got: %v, want: %v", odds, expected)
	}
}
