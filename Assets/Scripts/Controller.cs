using UnityEngine;
using System;
using System.Collections.Generic;

public class Controller : MonoBehaviour {

	private Battle battle;

	// Use this for initialization
	void Start () {
		List<Unit> attackers = new List<Unit>(6);
		List<Unit> defenders = new List<Unit>(6);
		attackers.Add(new Infantry());
		attackers.Add(new Infantry());
		attackers.Add(new Infantry());
		attackers.Add(new Infantry());
		attackers.Add(new Infantry());
		attackers.Add(new Infantry());
		attackers.Add(new Artillery());
		attackers.Add(new Artillery());
		attackers.Add(new Artillery());
		attackers.Add(new Fighter());
		attackers.Add(new Fighter());
		this.battle = new Battle(attackers, defenders);
		for (int i = 0; i <= attackers.Count; i++) {
			Debug.Log("Odds of " + i + " hits: " + this.battle.AttackerOdds.OddsOf(i));
		}
		this.battle.Reset();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
