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
		// Set all dice as failing the roll
		this.Odds.ForEach (x => x.Active = false);
		// Generate all combinations that could result in hits
		List<bool[]> combinations = this.GetBinaryStrings(this.Odds.Count, hits).Select(s => s.Select(c => c == '1').ToArray()).ToList();
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
		
	// Apply the combination to the odds
	private void applyCombination(bool[] combination) {
		for (int i = 0; i < combination.Length; i++) {
			this.Odds[i].Active = combination[i];
		}
	}

	// Get all binary strings with bits and length
	private IEnumerable<string> GetBinaryStrings(int length, int bits) {
		if (length == 1) {
			yield return bits.ToString();
		} else {
			int first = length / 2;
			int last = length - first;
			int low = Math.Max(0, bits - last);
			int high = Math.Min(bits, first);
			for (int i = low; i <= high; i++) {
				foreach (string f in GetBinaryStrings(first, i)) {
					foreach (string l in GetBinaryStrings(last, bits - i)) {
						yield return f + l;
					}
				}
			}
		}
	}

	public override string ToString() {
		return string.Join(string.Empty, this.Odds.Select(x => x.ToString()).ToArray());
	}
}