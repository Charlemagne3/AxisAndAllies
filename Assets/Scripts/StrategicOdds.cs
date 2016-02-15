using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class StrategicOdds {

	private int bombers;
	private double denominator;

	public StrategicOdds(int bombers) {
		this.bombers = bombers;
		this.denominator = System.Math.Pow(6, bombers);
	}

	public double OddsOf(int damage) {
		int numerator = 0;
		List<int> possible = new List<int>(this.bombers);
		for (int i = 0; i < this.bombers; i++) {
			possible.Add(1);
		}
		for (int i = 0; i < possible.Count; i++) {
			while (possible[i] <= 6) {
				if (possible.Sum() == damage) {
					var groups = possible.GroupBy(x => x);
					int denominator = 1;
					foreach (var group in groups) {
						denominator *= this.factorial(group.Count());
					}
					numerator += factorial(possible.Count) / denominator;
				}
				if (possible[i] >= 6) {
					break;
				}
				possible[i]++;
			}
		}
		return numerator / this.denominator;
	}
		
	private int factorial(int n) {
		if (n <= 1) return 1;
		return n * factorial(n - 1);
	}
}
