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
		this.battle = new Battle(attackers, defenders);
		Debug.Log(this.battle.AttackerOdds.OddsOf(1));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
