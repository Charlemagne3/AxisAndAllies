package main

import (
	"bytes"
	"math"
	"strconv"
	"strings"
)

//
type Odds struct {
	Success int
	Failure int
	Active  bool
}

func (odds Odds) getOdds() int64 {
	o := odds.Failure
	if odds.Active {
		o = odds.Success
	}
	return int64(o)
}

func (odds Odds) getStringOdds() string {
	o := strconv.Itoa(odds.Failure)
	if odds.Active {
		o = strconv.Itoa(odds.Success)
	}
	return o
}

func toString(odds Odds) string {
	s := "0"
	if odds.Active {
		s = "1"
	}
	return s
}

// oddsOf rseturn the odds of numHits hits on len(units) dice
func oddsOf(units []Unit, numHits int, attacking bool) float64 {
	// Convert the units into a list of Odds based on their attack or defense stats
	odds := []Odds{}
	if attacking {
		for _, unit := range units {
			odds = append(odds, Odds{Success: unit.Attack, Failure: 6 - unit.Attack, Active: false})
		}
	} else {
		for _, unit := range units {
			odds = append(odds, Odds{Success: unit.Defense, Failure: 6 - unit.Defense, Active: false})
		}
	}
	// Total number of unique die combinations that could be rolled
	denominator := math.Pow(6, float64(len(units)))
	// Accumulate a numerator to divide at the end to get the odds
	accumulator := int64(0)
	// Generate all hit combinations that could result in numHits
	combinations := getHitCombinations(numHits, len(units))
	// Iterate the odds for each possible combination that could result in numHits
	for i := 0; i < len(combinations); i++ {
		applyCombination(odds, combinations[i])
		// Multiply all the numerators together for each combination of rolls
		subAccumulator := int64(1)
		for _, o := range odds {
			subAccumulator *= o.getOdds()
		}
		// Add the odds of this combination to the total odds
		accumulator += subAccumulator
	}
	// Divide the accumulated numerators by the number of possible combinations to get the odds of the hits
	return float64(accumulator) / denominator
}

// applyCombination sets a list of odds active based on the list of bools describing which ones should be active
func applyCombination(odds []Odds, combination []bool) {
	for i := 0; i < len(combination); i++ {
		odds[i].Active = combination[i]
	}
}

// getHitCombinations returns all combinations of dice pool rolls that result in numHits number of hits
func getHitCombinations(numHits int, numUnits int) [][]bool {
	// Generate a string of all hits
	var buffer bytes.Buffer
	for i := 0; i < numUnits; i++ {
		buffer.WriteString("1")
	}
	allHits := buffer.String()
	// Max value to interate to is the binary string of all 1s
	max, _ := strconv.ParseInt(allHits, 2, 32)
	// Holds all combinations of hits
	var combinations [][]bool
	// Iterate all numbers up the string of all 1s (a hit on every dice)
	for i := 0; i <= int(max); i++ {
		// Get a bit string of the num
		hitString := strconv.FormatInt(int64(i), 2)
		// Buffer it with zeroes to make the length numHits
		var hitBuffer bytes.Buffer
		neededZeros := numUnits - len(hitString)
		for i := 0; i < neededZeros; i++ {
			hitBuffer.WriteString("0")
		}
		hitBuffer.WriteString(hitString)
		bufferedHitString := hitBuffer.String()
		// Make a slice
		bitString := strings.Split(bufferedHitString, "")
		// Count the numHits
		sum := 0
		for _, c := range bitString {
			bit, _ := strconv.Atoi(c)
			sum += bit
		}
		// If it has the needed numHits add it to the combinations
		if sum == numHits {
			var boolHits []bool
			for _, c := range bitString {
				boolHits = append(boolHits, c == "1")
			}
			combinations = append(combinations, boolHits)
		}
	}
	return combinations
}
