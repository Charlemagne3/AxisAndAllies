using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class AntiAircraftOdds : CombatOdds {

	public int Shots { get; private set; }

	public AntiAircraftOdds(List<AntiAircraftArtillery> antiAircraftArtillery, int aircraft) {
		this.Shots = antiAircraftArtillery.Count * Mathf.Clamp(antiAircraftArtillery.Count, 0, 3);
		base.Odds = new List<Odds>(this.Shots);
		for (int i = 0; i < this.Shots; i++) {
			base.Odds.Add(new Odds(1));
		}
		base.denominator = System.Math.Pow(6, this.Shots);
	}
}
