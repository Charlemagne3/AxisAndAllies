using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class AntiAircraftOdds : CombatOdds {
	
	public AntiAircraftOdds(List<AntiAircraftArtillery> antiAircraftArtillery, int aircraft) {
		int shots = antiAircraftArtillery.Count * Mathf.Clamp(antiAircraftArtillery.Count, 0, 3);
		base.Odds = new List<Odds>(shots);
		for (int i = 0; i < shots; i++) {
			base.Odds.Add(new Odds(1));
		}
		base.denominator = System.Math.Pow(6, shots);
	}
}
