using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class IndustrialComplexOdds : CombatOdds {

	public IndustrialComplexOdds(int bombers) {
		base.Odds = new List<Odds>(bombers);
		for (int i = 0; i < bombers; i++) {
			base.Odds.Add(new Odds(1));
		}
		base.denominator = System.Math.Pow(6, bombers);
	}
}
