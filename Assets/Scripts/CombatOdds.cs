using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class CombatOdds {
	
	public List<Odds> Odds { get; protected set; }
	protected double denominator;

	public CombatOdds() {}

	public CombatOdds(List<Unit> units, bool attacking) {
		this.Odds = new List<Odds> (units.Count);
		foreach (Unit unit in units) {
			if (attacking) {
				this.Odds.Add(new Odds(unit.Attack));
			} else {
				this.Odds.Add(new Odds(unit.Defense));
			}
		}
		this.denominator = System.Math.Pow(6, units.Count);
	}

	// Return the odds of hits on x dice
	public double OddsOf(int hits) {
		// Accumulate a numerator
		long accumulator = 0;
		// Create a list for the possible combinations
		List<bool[]> combinations = new List<bool[]>((int)System.Math.Pow(2, this.Odds.Count));
		// Set all dice as failing the roll
		this.Odds.ForEach (x => x.Active = false);
		// Generate all combinations that could result in hits
		this.generateCombinations(hits, combinations);
		// Iterate the odds for each possible combination that could result in the hits
		for (int i = 0; i < combinations.Count; i++) {
			this.applyCombination(combinations[i]);
			// Multiply all the numerators together for each combination of rolls
			long subAccumulator = 1;
			foreach (var odds in Odds) {
				subAccumulator *= odds.GetOdds();
			}
			// Add the odds of this combination to the total odds
			accumulator += subAccumulator;
		}
		// Divide the accumulated numertors by the number of possible combinations to get the odds of the hits
		return accumulator / this.denominator;
	}
		
	// Get all combinations of hits
	private void generateCombinations(int hits, List<bool[]> combinations) {
		int power = (int)System.Math.Pow(2, this.Odds.Count);
		for (int generator = 0; generator < power; generator++) {
			BitArray bitArray = new BitArray(new int[] { generator });
			bool[] bits = new bool[bitArray.Count];
			bitArray.CopyTo(bits, 0);
			bool[] truncatedBits = new bool[this.Odds.Count];
			for (int i = 0; i < truncatedBits.Length; i++) {
				truncatedBits[i] = bits[i];
			}
			if (truncatedBits.Select(x => System.Convert.ToInt32(x)).Sum() == hits) {
				combinations.Add(truncatedBits);
			}
		}
	}

	// Apply the combination to the odds
	private void applyCombination(bool[] combination) {
		for (int i = 0; i < combination.Length; i++) {
			this.Odds[i].Active = combination[i];
		}
	}

	public override string ToString() {
		return string.Join(string.Empty, this.Odds.Select(x => x.ToString()).ToArray());
	}
}