using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class StrategicOdds {

	private int bombers;
	private double denominator;

	public StrategicOdds(int bombers) {
		// The amount of bombers is the number of dice to roll
		this.bombers = bombers;
		this.denominator = System.Math.Pow(6, bombers);
	}

	public double OddsOf(int damage) {
		int numerator = 0;
		List<long> dice = new List<long>(this.bombers);
		// letlongn = this.bombers; get the smallest n + 1 digit number
		long possible = (long)Mathf.Pow (10, this.bombers);
		// let n = this.bombers; get the smallest n digit number where one of the digits is a 6
		possible -= 4;
		// let n = this.bombers; i = the smallest n digit number
		for (long i = (long)Mathf.Pow(10, this.bombers - 1); i <= possible; i++) {
			// for each digit count do a mod operation
			for (int digits = this.bombers; digits > 0; digits--) {
				long die = (i / (long)Mathf.Pow(10, digits - 1)) % 10;
				dice.Add(die);
			}
			if (dice.Sum() == damage && !dice.Contains(0) && !dice.Contains(7) && !dice.Contains(8) && !dice.Contains(9)){
				numerator++;
			}
			dice.Clear();
		}
		return numerator / this.denominator;
	}
		
	// basic recursive factorial function
	private long factorial(long n) {
		if (n <= 1) return 1;
		return n * factorial(n - 1);
	}
}
