﻿using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using System.Linq;

public class Controller : MonoBehaviour {

	public enum Theater {
		Land,
		Sea,
		Air
	}

	public enum SumMode {
		Individual,
		Summation
	}

	private Theater theater;

	private SumMode sumMode;
	private int decimals;

	// theater containers
	public GameObject Land;
	public GameObject Sea;
	public GameObject Air;

	// Main containers
	public GameObject Setup;
	public GameObject Outcome;

	// Options container
	public GameObject OptionsPanel;
	private bool showOptions;

	// Mode Toggle
	public Dropdown ModeDropdown;

	// Attacker units
	private List<Infantry> attackerInfantry;
	private List<Artillery> attackerArtillery;
	private List<Tank> attackerTanks;
	private List<Fighter> attackerFightersLand;
	private List<Fighter> attackerFightersSea;
	private List<Bomber> attackerBombersLand;
	private List<Bomber> attackerBombersSea;
	private List<Battleship> attackerBattleships;
	private List<Cruiser> attackerCruisers;
	private List<Destroyer> attackerDestroyers;
	private List<Submarine> attackerSubmarines;
	private List<AircraftCarrier> attackerAircraftCarriers;

	private List<Battleship> bombardingBattleships;
	private List<Cruiser> bombardingCruisers;

	private List<Fighter> escortFighters;
	private List<Bomber> escortedBombers;

	// Defender units
	private List<Infantry> defenderInfantry;
	private List<Artillery> defenderArtillery;
	private List<Tank> defenderTanks;
	private List<Fighter> defenderFightersLand;
	private List<Fighter> defenderFightersSea;
	private List<Bomber> defenderBombersLand;
	private List<Bomber> defenderBombersSea;
	private List<Battleship> defenderBattleships;
	private List<Cruiser> defenderCruisers;
	private List<Destroyer> defenderDestroyers;
	private List<Submarine> defenderSubmarines;
	private List<AircraftCarrier> defenderAircraftCarriers;

	private List<AntiAircraftArtillery> antiAircraftArtillery;

	private List<Fighter> interceptors;

	// Texts for all the units
	public Text AttackerInfantryText;
	public Text DefenderInfantryText;

	public Text AttackerArtilleryText;
	public Text DefenderArtilleryText;

	public Text AttackerTanksText;
	public Text DefenderTanksText;

	public Text AttackerFightersLandText;
	public Text DefenderFightersLandText;

	public Text AttackerFightersSeaText;
	public Text DefenderFightersSeaText;

	public Text AttackerBombersLandText;
	public Text DefenderBombersLandText;

	public Text AttackerBombersSeaText;
	public Text DefenderBombersSeaText;

	public Text AttackerBattleshipsText;
	public Text DefenderBattleshipsText;

	public Text AttackerCruisersText;
	public Text DefenderCruisersText;

	public Text AttackerDestroyersText;
	public Text DefenderDestroyersText;

	public Text AttackerSubmarinesText;
	public Text DefenderSubmarinesText;

	public Text AttackerAircraftCarriersText;
	public Text DefenderAircraftCarriersText;

	public Text BombardingBattleshipsText;
	public Text BombardingCruisersText;

	public Text AntiAircraftArtilleryText;

	public Text EscortFightersText;
	public Text EscortedBombersText;

	public Text InterceptorsText;

	public Text AttackerOutcomeText;
	public Text DefenderOutcomeText;

	public Text DecimalsText;

	// Use this for initialization
	void Start () {
		this.theater = Theater.Land;

		this.sumMode = SumMode.Individual;
		this.decimals = 2;

		this.attackerInfantry = new List<Infantry>(2);
		this.attackerArtillery = new List<Artillery>(2);
		this.attackerTanks = new List<Tank>(2);
		this.attackerFightersLand = new List<Fighter>(2);
		this.attackerFightersSea = new List<Fighter>(2);
		this.attackerBombersLand = new List<Bomber>(2);
		this.attackerBombersSea = new List<Bomber>(2);
		this.attackerBattleships = new List<Battleship>(2);
		this.attackerCruisers = new List<Cruiser>(2);
		this.attackerDestroyers = new List<Destroyer>(2);
		this.attackerSubmarines = new List<Submarine>(2);
		this.attackerAircraftCarriers = new List<AircraftCarrier>(2);

		this.bombardingBattleships = new List<Battleship>(2);
		this.bombardingCruisers = new List<Cruiser>(2);

		this.escortFighters = new List<Fighter>(2);
		this.escortedBombers = new List<Bomber>(2);

		this.defenderInfantry = new List<Infantry>(2);
		this.defenderArtillery = new List<Artillery>(2);
		this.defenderTanks = new List<Tank>(2);
		this.defenderFightersLand = new List<Fighter>(2);
		this.defenderFightersSea = new List<Fighter>(2);
		this.defenderBombersLand = new List<Bomber>(2);
		this.defenderBombersSea = new List<Bomber>(2);
		this.defenderBattleships = new List<Battleship>(2);
		this.defenderCruisers = new List<Cruiser>(2);
		this.defenderDestroyers = new List<Destroyer>(2);
		this.defenderSubmarines = new List<Submarine>(2);
		this.defenderAircraftCarriers = new List<AircraftCarrier>(2);

		this.antiAircraftArtillery = new List<AntiAircraftArtillery>(2);

		this.interceptors = new List<Fighter>(2);

		this.AttackerOutcomeText.text = "";
		this.DefenderOutcomeText.text = "";

		this.DecimalsText.text = this.decimals.ToString();
	}

	// Set to land mode
	public void LandBattle() {
		this.theater = Theater.Land;
		this.Land.SetActive(true);
		this.Sea.SetActive(false);
		this.Air.SetActive(false);
		this.Land.GetComponent<Image>().color = new Color (255, 255, 255, 255);
	}

	// Set to sea mode
	public void SeaBattle() {
		this.theater = Theater.Sea;
		this.Land.SetActive(false);
		this.Sea.SetActive(true);
		this.Air.SetActive(false);
		this.Sea.GetComponent<Image>().color = new Color (255, 255, 255, 255);
	}

	// Set to strategic bombing mode
	public void AirBattle() {
		this.theater = Theater.Air;
		this.Land.SetActive(false);
		this.Sea.SetActive(false);
		this.Air.SetActive(true);
		this.Air.GetComponent<Image>().color = new Color (255, 255, 255, 255);
	}

	public void Options() {
		this.showOptions = !this.showOptions;
		if (this.showOptions) {
			OptionsPanel.GetComponent<RectTransform> ().localPosition = new Vector3 (0, 640, 0);
		} else {
			OptionsPanel.GetComponent<RectTransform> ().localPosition = new Vector3 (0, 1024, 0);
		}
	}

	public void ModeChange() {
		if (this.ModeDropdown.value == 0) {
			this.sumMode = SumMode.Individual;
		} else if (this.ModeDropdown.value == 1) {
			this.sumMode = SumMode.Summation;
		}
	}

	// Start a battle
	public void Battle() {
		this.AttackerOutcomeText.text = "";
		this.DefenderOutcomeText.text = "";

	    List<Unit> attackers = new List<Unit>(
		    this.attackerInfantry.Count +
			this.attackerArtillery.Count +
			this.attackerTanks.Count +
			this.attackerFightersLand.Count +
			this.attackerFightersSea.Count +
			this.attackerBombersLand.Count +
			this.attackerBombersSea.Count +
			this.attackerBattleships.Count +
			this.attackerCruisers.Count +
			this.attackerDestroyers.Count +
			this.attackerSubmarines.Count +
			this.attackerAircraftCarriers.Count
		);
		List<Unit> defenders = new List<Unit>(
			this.defenderInfantry.Count +
			this.defenderArtillery.Count +
			this.defenderTanks.Count +
			this.defenderFightersLand.Count +
			this.defenderFightersSea.Count +
			this.defenderBombersLand.Count +
			this.defenderBombersSea.Count +
			this.defenderBattleships.Count +
			this.defenderCruisers.Count +
			this.defenderDestroyers.Count +
			this.defenderSubmarines.Count +
			this.defenderAircraftCarriers.Count
		);
		List<Unit> bombarders = new List<Unit>(
			this.bombardingBattleships.Count + 
			this.bombardingCruisers.Count
		);
		List<Unit> raiders = new List<Unit>(
			this.escortFighters.Count +
			this.escortedBombers.Count
		);
		List<Unit> interceptors = new List<Unit>(this.interceptors.Count);

		switch (this.theater) {
			case Theater.Land:
			
				this.attackerInfantry.ForEach(x => attackers.Add(x));
				this.attackerArtillery.ForEach(x => attackers.Add(x));
				this.attackerTanks.ForEach(x => attackers.Add(x));
				this.attackerFightersLand.ForEach(x => attackers.Add(x));
				this.attackerBombersLand.ForEach(x => attackers.Add(x));

				this.bombardingBattleships.ForEach (x => bombarders.Add(x));
				this.bombardingCruisers.ForEach (x => bombarders.Add(x));

				this.defenderInfantry.ForEach(x => defenders.Add(x));
				this.defenderArtillery.ForEach(x => defenders.Add(x));
				this.defenderTanks.ForEach(x => defenders.Add(x));
				this.defenderFightersLand.ForEach(x => defenders.Add(x));
				this.defenderBombersLand.ForEach(x => defenders.Add(x));

				break;

			case Theater.Sea:
			
				this.attackerFightersSea.ForEach(x => attackers.Add(x));
				this.attackerBombersSea.ForEach(x => attackers.Add(x));
				this.attackerBattleships.ForEach(x => attackers.Add(x));
				this.attackerCruisers.ForEach(x => attackers.Add(x));
				this.attackerDestroyers.ForEach(x => attackers.Add(x));
				this.attackerSubmarines.ForEach(x => attackers.Add(x));
				this.attackerAircraftCarriers.ForEach(x => attackers.Add(x));
				
				this.defenderFightersSea.ForEach(x => defenders.Add(x));
				this.defenderBombersSea.ForEach(x => defenders.Add(x));
				this.defenderBattleships.ForEach(x => defenders.Add(x));
				this.defenderCruisers.ForEach(x => defenders.Add(x));
				this.defenderDestroyers.ForEach(x => defenders.Add(x));
				this.defenderSubmarines.ForEach(x => defenders.Add(x));
				this.defenderAircraftCarriers.ForEach(x => defenders.Add(x));

				break;

			case Theater.Air:
				
				this.escortFighters.ForEach (x => raiders.Add(x));
				this.escortedBombers.ForEach (x => raiders.Add(x));
					
				this.interceptors.ForEach (x => interceptors.Add(x));

				break;

			default:
				break;
		}

		Battle battle = new Battle(attackers, defenders, bombarders, this.antiAircraftArtillery, raiders, interceptors);

		if (this.theater == Theater.Land) {
			this.landBattle(battle);
		} else if (this.theater == Theater.Sea) {
			this.seaBattle(battle);
		} else if (this.theater == Theater.Air) {
			this.airBattle(battle);
		}

		this.Setup.SetActive(false);
		this.Outcome.SetActive(true);
	}

	private void landBattle(Battle battle) {
		
		if (this.sumMode == SumMode.Individual) {
			// Attackers
			if (battle.Bombarders.Any ()) {
				this.AttackerOutcomeText.text += "Odds of bombarding hits:\n";
				for (int i = 0; i <= battle.Bombarders.Count; i++) {
					this.AttackerOutcomeText.text += i + ": " + System.Math.Round (battle.BombarderOdds.OddsOf (i) * 100, this.decimals) + "%\n";
				}
			}
			this.AttackerOutcomeText.text += "Odds of hits:\n";
			for (int i = 0; i <= battle.Attackers.Count; i++) {
				this.AttackerOutcomeText.text += i + ": " + System.Math.Round (battle.AttackerOdds.OddsOf (i) * 100, this.decimals) + "%\n";
			}

			// Defenders
			if (this.antiAircraftArtillery.Any ()) {
				this.DefenderOutcomeText.text += "Odds of anti-aircraft hits:\n";
				for (int i = 0; i <= battle.AntiAircraftOdds.Shots; i++) {
					this.DefenderOutcomeText.text += i + ": " + System.Math.Round (battle.AntiAircraftOdds.OddsOf (i) * 100, this.decimals) + "%\n";
				}
			}
			this.DefenderOutcomeText.text += "Odds of hits:\n";
			for (int i = 0; i <= battle.Defenders.Count; i++) {
				this.DefenderOutcomeText.text += i + ": " + System.Math.Round (battle.DefenderOdds.OddsOf (i) * 100, this.decimals) + "%\n";
			}
		} else if (this.sumMode == SumMode.Summation) {
			List<double> attackerOddsList = new List<double>(battle.Attackers.Count);
			List<double> bombarderOddsList = new List<double>(battle.Bombarders.Count);

			List<double> defenderOddsList = new List<double>(battle.Defenders.Count);
			List<double> antiAircraftOddsList = new List<double>(battle.AntiAircraftOdds.Shots);

			// Attackers
			if (battle.Bombarders.Any()) {
				for (int i = 0; i <= battle.Bombarders.Count; i++) {
					double odds = battle.BombarderOdds.OddsOf(i);
					bombarderOddsList.Add(odds);
				}
			}
			for (int i = 0; i <= battle.Attackers.Count; i++) {
				double odds = battle.AttackerOdds.OddsOf(i);
				attackerOddsList.Add(odds);
			}

			if (bombarderOddsList.Any()) {
				this.AttackerOutcomeText.text += "Odds of bombarding hits:\n";
				for (int i = 0; i < bombarderOddsList.Count; i++) {
					this.AttackerOutcomeText.text += i + ": " + System.Math.Round(bombarderOddsList.Skip(i).Sum() * 100, this.decimals) + "%\n";
				}
			}
			this.AttackerOutcomeText.text += "Odds of hits:\n";
			for (int i = 0; i < attackerOddsList.Count; i++) {
				this.AttackerOutcomeText.text += i + ": " + System.Math.Round(attackerOddsList.Skip(i).Sum() * 100, this.decimals) + "%\n";
			}

			// Defenders
			if (this.antiAircraftArtillery.Any()) {
				for (int i = 0; i <= battle.AntiAircraftOdds.Shots; i++) {
					double odds = battle.AntiAircraftOdds.OddsOf(i);
					antiAircraftOddsList.Add(odds);
				}
			}
			for (int i = 0; i <= battle.Defenders.Count; i++) {
				double odds = battle.DefenderOdds.OddsOf(i);
				defenderOddsList.Add(odds);
			}

			if (antiAircraftOddsList.Any()) {
				this.DefenderOutcomeText.text += "Odds of anti-aircraft hits:\n";
				for (int i = 0; i < antiAircraftOddsList.Count; i++) {
					this.DefenderOutcomeText.text += i + ": " + System.Math.Round(antiAircraftOddsList.Skip(i).Sum() * 100, this.decimals) + "%\n";
				}
			}
			this.DefenderOutcomeText.text += "Odds of hits:\n";
			for (int i = 0; i < defenderOddsList.Count; i++) {
				this.DefenderOutcomeText.text += i + ": " + System.Math.Round(defenderOddsList.Skip(i).Sum() * 100, this.decimals) + "%\n";
			}
		}
	}

	private void seaBattle(Battle battle) {

		if (this.sumMode == SumMode.Individual) {
			// Attackers
			this.AttackerOutcomeText.text += "Odds of hits:\n";
			for (int i = 0; i <= battle.Attackers.Count; i++) {
				this.AttackerOutcomeText.text += i + ": " + System.Math.Round (battle.AttackerOdds.OddsOf (i) * 100, this.decimals) + "%\n";
			}

			// Defenders
			this.DefenderOutcomeText.text += "Odds of hits:\n";
			for (int i = 0; i <= battle.Defenders.Count; i++) {
				this.DefenderOutcomeText.text += i + ": " + System.Math.Round (battle.DefenderOdds.OddsOf (i) * 100, this.decimals) + "%\n";
			}
		} else if (this.sumMode == SumMode.Summation) {
			List<double> attackerOddsList = new List<double>(battle.Attackers.Count);
			List<double> defenderOddsList = new List<double>(battle.Defenders.Count);

			// Attackers
			for (int i = 0; i <= battle.Attackers.Count; i++) {
				double odds = battle.AttackerOdds.OddsOf(i);
				attackerOddsList.Add(odds);
			}

			// Defenders
			for (int i = 0; i <= battle.Defenders.Count; i++) {
				double odds = battle.DefenderOdds.OddsOf(i);
				defenderOddsList.Add(odds);
			}

			// Attackers
			this.AttackerOutcomeText.text += "Odds of hits:\n";
			for (int i = 0; i < attackerOddsList.Count; i++) {
				this.AttackerOutcomeText.text += i + ": " + System.Math.Round(attackerOddsList.Skip(i).Sum() * 100, this.decimals) + "%\n";
			}

			// Defenders
			this.DefenderOutcomeText.text += "Odds of hits:\n";
			for (int i = 0; i < defenderOddsList.Count; i++) {
				this.DefenderOutcomeText.text += i + ": " + System.Math.Round(defenderOddsList.Skip(i).Sum() * 100, this.decimals) + "%\n";
			}
		}
	}

	private void airBattle(Battle battle) {

		if (this.sumMode == SumMode.Individual) {
			// Attackers
			this.AttackerOutcomeText.text += "Odds of hits:\n";
			for (int i = 0; i <= battle.Raiders.Count; i++) {
				this.AttackerOutcomeText.text += i + ": " + System.Math.Round (battle.RaiderOdds.OddsOf (i) * 100, this.decimals) + "%\n";
			}

			this.AttackerOutcomeText.text += "Odds of damage:\n";
			int minDamage = this.escortedBombers.Count;
			int maxDamage = minDamage * 6;
			for (int i = minDamage; i <= maxDamage; i++) {
				this.AttackerOutcomeText.text += i + ": " + System.Math.Round (battle.StrategicOdds.OddsOf (i) * 100, this.decimals) + "%\n";
			}

			// Defenders
			this.DefenderOutcomeText.text += "Odds of hits:\n";
			for (int i = 0; i <= interceptors.Count; i++) {
				this.DefenderOutcomeText.text += i + ": " + System.Math.Round (battle.InterceptorOdds.OddsOf (i) * 100, this.decimals) + "%\n";
			}

			this.DefenderOutcomeText.text += "Odds of hits:\n";
			for (int i = 0; i <= this.escortedBombers.Count; i++) {
				this.DefenderOutcomeText.text += i + ": " + System.Math.Round (battle.IndustrialComplexOdds.OddsOf (i) * 100, this.decimals) + "%\n";
			}
		} else if (this.sumMode == SumMode.Summation) {
			List<double> raiderOddsList = new List<double>(battle.Raiders.Count);
			List<double> strategicOddsList = new List<double>(battle.Raiders.Count);
			List<double> interceptorOddsList = new List<double>(battle.Interceptors.Count);
			List<double> industrialComplexOddsList = new List<double>(this.escortedBombers.Count);

			// Attackers
			for (int i = 0; i <= battle.Raiders.Count; i++) {
				double odds = battle.RaiderOdds.OddsOf(i);
				raiderOddsList.Add(odds);
			}

			int minDamage = this.escortedBombers.Count;
			int maxDamage = minDamage * 6;
			for (int i = minDamage; i <= maxDamage; i++) {
				double odds = battle.StrategicOdds.OddsOf(i);
				strategicOddsList.Add(odds);
			}

			this.AttackerOutcomeText.text += "Odds of hits:\n";
			for (int i = 0; i < raiderOddsList.Count; i++) {
				this.AttackerOutcomeText.text += i + ": " + System.Math.Round(raiderOddsList.Skip(i).Sum() * 100, this.decimals) + "%\n";
			}

			this.AttackerOutcomeText.text += "Odds of damage:\n";
			for (int i = minDamage; i < maxDamage; i++) {
				this.AttackerOutcomeText.text += i + ": " + System.Math.Round(strategicOddsList.Skip(i).Sum() * 100, this.decimals) + "%\n";
			}

			// Defenders
			for (int i = 0; i <= interceptors.Count; i++) {
				double odds = battle.InterceptorOdds.OddsOf(i);
				interceptorOddsList.Add(odds);			
			}

			for (int i = 0; i <= this.escortedBombers.Count; i++) {
				double odds = battle.IndustrialComplexOdds.OddsOf(i);
				industrialComplexOddsList.Add(odds);			
			}

			this.DefenderOutcomeText.text += "Odds of hits:\n";
			for (int i = 0; i < interceptorOddsList.Count; i++) {
				this.DefenderOutcomeText.text += i + ": " + System.Math.Round(interceptorOddsList.Skip(i).Sum() * 100, this.decimals) + "%\n";
			}

			this.DefenderOutcomeText.text += "Odds of hits:\n";
			for (int i = 0; i < industrialComplexOddsList.Count; i++) {
				this.DefenderOutcomeText.text += i + ": " + System.Math.Round(industrialComplexOddsList.Skip(i).Sum() * 100, this.decimals) + "%\n";
			}
		}
	}

	public void Back() {
		this.Outcome.SetActive(false);
		this.Setup.SetActive(true);
	}

	// Increment and decrement functions for all units
	public void IncrementAttackerInfantry() {
		this.attackerInfantry.Add(new Infantry());
		this.AttackerInfantryText.text = this.attackerInfantry.Count.ToString();
	}

	public void DecrementAttackerInfantry() {
		if (this.attackerInfantry.Any()) {
			this.attackerInfantry.RemoveAt(0);
		}
		this.AttackerInfantryText.text = this.attackerInfantry.Count.ToString();
	}

	public void IncrementDefenderInfantry() {
		this.defenderInfantry.Add(new Infantry());
		this.DefenderInfantryText.text = this.defenderInfantry.Count.ToString();
	}

	public void DecrementDefenderInfantry() {
		if (this.defenderInfantry.Any()) {
			this.defenderInfantry.RemoveAt(0);
		}
		this.DefenderInfantryText.text = this.defenderInfantry.Count.ToString();
	}

	public void IncrementAttackerArtillery() {
		this.attackerArtillery.Add(new Artillery());
		this.AttackerArtilleryText.text = this.attackerArtillery.Count.ToString();
	}

	public void DecrementAttackerArtillery() {
		if (this.attackerArtillery.Any()) {
			this.attackerArtillery.RemoveAt(0);
		}
		this.AttackerArtilleryText.text = this.attackerArtillery.Count.ToString();
	}

	public void IncrementDefenderArtillery() {
		this.defenderArtillery.Add(new Artillery());
		this.DefenderArtilleryText.text = this.defenderArtillery.Count.ToString();
	}

	public void DecrementDefenderArtillery() {
		if (this.defenderArtillery.Any()) {
			this.defenderArtillery.RemoveAt(0);
		}
		this.DefenderArtilleryText.text = this.defenderArtillery.Count.ToString();
	}

	public void IncrementAttackerTanks() {
		this.attackerTanks.Add(new Tank());
		this.AttackerTanksText.text = this.attackerTanks.Count.ToString();
	}

	public void DecrementAttackerTanks() {
		if (this.attackerTanks.Any()) {
			this.attackerTanks.RemoveAt(0);
		}
		this.AttackerTanksText.text = this.attackerTanks.Count.ToString();
	}

	public void IncrementDefenderTanks() {
		this.defenderTanks.Add(new Tank());
		this.DefenderTanksText.text = this.defenderTanks.Count.ToString();
	}

	public void DecrementDefenderTanks() {
		if (this.defenderTanks.Any()) {
			this.defenderTanks.RemoveAt(0);
		}
		this.DefenderTanksText.text = this.defenderTanks.Count.ToString();
	}

	public void IncrementAttackerFightersLand() {
		this.attackerFightersLand.Add(new Fighter());
		this.AttackerFightersLandText.text = this.attackerFightersLand.Count.ToString();
	}

	public void DecrementAttackerFightersLand() {
		if (this.attackerFightersLand.Any()) {
			this.attackerFightersLand.RemoveAt(0);
		}
		this.AttackerFightersLandText.text = this.attackerFightersLand.Count.ToString();
	}

	public void IncrementDefenderFightersLand() {
		this.defenderFightersLand.Add(new Fighter());
		this.DefenderFightersLandText.text = this.defenderFightersLand.Count.ToString();
	}

	public void DecrementDefenderFightersLand() {
		if (this.defenderFightersLand.Any()) {
			this.defenderFightersLand.RemoveAt(0);
		}
		this.DefenderFightersLandText.text = this.defenderFightersLand.Count.ToString();
	}

	public void IncrementAttackerFightersSea() {
		this.attackerFightersSea.Add(new Fighter());
		this.AttackerFightersSeaText.text = this.attackerFightersSea.Count.ToString();
	}

	public void DecrementAttackerFightersSea() {
		if (this.attackerFightersSea.Any()) {
			this.attackerFightersSea.RemoveAt(0);
		}
		this.AttackerFightersSeaText.text = this.attackerFightersSea.Count.ToString();
	}

	public void IncrementDefenderFightersSea() {
		this.defenderFightersSea.Add(new Fighter());
		this.DefenderFightersSeaText.text = this.defenderFightersSea.Count.ToString();
	}

	public void DecrementDefenderFightersSea() {
		if (this.defenderFightersSea.Any()) {
			this.defenderFightersSea.RemoveAt(0);
		}
		this.DefenderFightersSeaText.text = this.defenderFightersSea.Count.ToString();
	}

	public void IncrementAttackerBombersLand() {
		this.attackerBombersLand.Add(new Bomber());
		this.AttackerBombersLandText.text = this.attackerBombersLand.Count.ToString();
	}

	public void DecrementAttackerBombersLand() {
		if (this.attackerBombersLand.Any()) {
			this.attackerBombersLand.RemoveAt(0);
		}
		this.AttackerBombersLandText.text = this.attackerBombersLand.Count.ToString();
	}

	public void IncrementDefenderBombersLand() {
		this.defenderBombersLand.Add(new Bomber());
		this.DefenderBombersLandText.text = this.defenderBombersLand.Count.ToString();
	}

	public void DecrementDefenderBombersLand() {
		if (this.defenderBombersLand.Any()) {
			this.defenderBombersLand.RemoveAt(0);
		}
		this.DefenderBombersLandText.text = this.defenderBombersLand.Count.ToString();
	}

	public void IncrementAttackerBombersSea() {
		this.attackerBombersSea.Add(new Bomber());
		this.AttackerBombersSeaText.text = this.attackerBombersSea.Count.ToString();
	}

	public void DecrementAttackerBombersSea() {
		if (this.attackerBombersSea.Any()) {
			this.attackerBombersSea.RemoveAt(0);
		}
		this.AttackerBombersSeaText.text = this.attackerBombersSea.Count.ToString();
	}

	public void IncrementDefenderBombersSea() {
		this.defenderBombersSea.Add(new Bomber());
		this.DefenderBombersSeaText.text = this.defenderBombersSea.Count.ToString();
	}

	public void DecrementDefenderBombersSea() {
		if (this.defenderBombersSea.Any()) {
			this.defenderBombersSea.RemoveAt(0);
		}
		this.DefenderBombersSeaText.text = this.defenderBombersSea.Count.ToString();
	}
		
	public void IncrementAttackerBattleships() {
		this.attackerBattleships.Add(new Battleship());
		this.AttackerBattleshipsText.text = this.attackerBattleships.Count.ToString();
	}

	public void DecrementAttackerBattleships() {
		if (this.attackerBattleships.Any()) {
			this.attackerBattleships.RemoveAt(0);
		}
		this.AttackerBattleshipsText.text = this.attackerBattleships.Count.ToString();
	}

	public void IncrementDefenderBattleships() {
		this.defenderBattleships.Add(new Battleship());
		this.DefenderBattleshipsText.text = this.defenderBattleships.Count.ToString();
	}

	public void DecrementDefenderBattleships() {
		if (this.defenderBattleships.Any()) {
			this.defenderBattleships.RemoveAt(0);
		}
		this.DefenderBattleshipsText.text = this.defenderBattleships.Count.ToString();
	}

	public void IncrementAttackerCruisers() {
		this.attackerCruisers.Add(new Cruiser());
		this.AttackerCruisersText.text = this.attackerCruisers.Count.ToString();
	}

	public void DecrementAttackerCruisers() {
		if (this.attackerCruisers.Any()) {
			this.attackerCruisers.RemoveAt(0);
		}
		this.AttackerCruisersText.text = this.attackerCruisers.Count.ToString();
	}

	public void IncrementDefenderCruisers() {
		this.defenderCruisers.Add(new Cruiser());
		this.DefenderCruisersText.text = this.defenderCruisers.Count.ToString();
	}

	public void DecrementDefenderCruisers() {
		if (this.defenderCruisers.Any()) {
			this.defenderCruisers.RemoveAt(0);
		}
		this.DefenderCruisersText.text = this.defenderCruisers.Count.ToString();
	}

	public void IncrementAttackerDestroyers() {
		this.attackerDestroyers.Add(new Destroyer());
		this.AttackerDestroyersText.text = this.attackerDestroyers.Count.ToString();
	}

	public void DecrementAttackerDestroyers() {
		if (this.attackerDestroyers.Any()) {
			this.attackerDestroyers.RemoveAt(0);
		}
		this.AttackerDestroyersText.text = this.attackerDestroyers.Count.ToString();
	}

	public void IncrementDefenderDestroyers() {
		this.defenderDestroyers.Add(new Destroyer());
		this.DefenderDestroyersText.text = this.defenderDestroyers.Count.ToString();
	}

	public void DecrementDefenderDestroyers() {
		if (this.defenderDestroyers.Any()) {
			this.defenderDestroyers.RemoveAt(0);
		}
		this.DefenderDestroyersText.text = this.defenderDestroyers.Count.ToString();
	}

	public void IncrementAttackerSubmarines() {
		this.attackerSubmarines.Add(new Submarine());
		this.AttackerSubmarinesText.text = this.attackerSubmarines.Count.ToString();
	}

	public void DecrementAttackerSubmarines() {
		if (this.attackerSubmarines.Any()) {
			this.attackerSubmarines.RemoveAt(0);
		}
		this.AttackerSubmarinesText.text = this.attackerSubmarines.Count.ToString();
	}

	public void IncrementDefenderSubmarines() {
		this.defenderSubmarines.Add(new Submarine());
		this.DefenderSubmarinesText.text = this.defenderSubmarines.Count.ToString();
	}

	public void DecrementDefenderSubmarines() {
		if (this.defenderSubmarines.Any()) {
			this.defenderSubmarines.RemoveAt(0);
		}
		this.DefenderSubmarinesText.text = this.defenderSubmarines.Count.ToString();
	}

	public void IncrementAttackerAircraftCarriers() {
		this.attackerAircraftCarriers.Add(new AircraftCarrier());
		this.AttackerAircraftCarriersText.text = this.attackerAircraftCarriers.Count.ToString();
	}

	public void DecrementAttackerAircraftCarriers() {
		if (this.attackerAircraftCarriers.Any()) {
			this.attackerAircraftCarriers.RemoveAt(0);
		}
		this.AttackerAircraftCarriersText.text = this.attackerAircraftCarriers.Count.ToString();
	}

	public void IncrementDefenderAircraftCarriers() {
		this.defenderAircraftCarriers.Add(new AircraftCarrier());
		this.DefenderAircraftCarriersText.text = this.defenderAircraftCarriers.Count.ToString();
	}

	public void DecrementDefenderAircraftCarriers() {
		if (this.defenderAircraftCarriers.Any()) {
			this.defenderAircraftCarriers.RemoveAt(0);
		}
		this.DefenderAircraftCarriersText.text = this.defenderAircraftCarriers.Count.ToString();
	}

	public void IncrementBombardingBattleships() {
		this.bombardingBattleships.Add(new Battleship());
		this.BombardingBattleshipsText.text = this.bombardingBattleships.Count.ToString();
	}

	public void DecrementBombardingBattleships() {
		if (this.bombardingBattleships.Any()) {
			this.bombardingBattleships.RemoveAt(0);
		}
		this.BombardingBattleshipsText.text = this.bombardingBattleships.Count.ToString();
	}

	public void IncrementBombardingCruisers() {
		this.bombardingCruisers.Add(new Cruiser());
		this.BombardingCruisersText.text = this.bombardingCruisers.Count.ToString();
	}

	public void DecrementBombardingCruisers() {
		if (this.bombardingCruisers.Any()) {
			this.bombardingCruisers.RemoveAt(0);
		}
		this.BombardingCruisersText.text = this.bombardingCruisers.Count.ToString();
	}

	public void IncrementAntiAircraftArtillery() {
		this.antiAircraftArtillery.Add(new AntiAircraftArtillery());
		this.AntiAircraftArtilleryText.text = this.antiAircraftArtillery.Count.ToString();
	}

	public void DecrementAntiAircraftArtillery() {
		if (this.antiAircraftArtillery.Any()) {
			this.antiAircraftArtillery.RemoveAt(0);
		}
		this.AntiAircraftArtilleryText.text = this.antiAircraftArtillery.Count.ToString();
	}

	public void IncrementEscortFighters() {
		this.escortFighters.Add(new Fighter());
		this.EscortFightersText.text = this.escortFighters.Count.ToString();
	}

	public void DecrementEscortFighters() {
		if (this.escortFighters.Any()) {
			this.escortFighters.RemoveAt(0);
		}
		this.EscortFightersText.text = this.escortFighters.Count.ToString();
	}

	public void IncrementInterceptorFighters() {
		this.interceptors.Add(new Fighter());
		this.InterceptorsText.text = this.interceptors.Count.ToString();
	}

	public void DecrementInterceptorFighters() {
		if (this.interceptors.Any()) {
			this.interceptors.RemoveAt(0);
		}
		this.InterceptorsText.text = this.interceptors.Count.ToString();
	}

	public void IncrementEscortedBombers() {
		this.escortedBombers.Add(new Bomber());
		this.EscortedBombersText.text = this.escortedBombers.Count.ToString();
	}

	public void DecrementEscortedBombers() {
		if (this.escortedBombers.Any()) {
			this.escortedBombers.RemoveAt(0);
		}
		this.EscortedBombersText.text = this.escortedBombers.Count.ToString();
	}

	public void IncrementDecimals() {
		this.decimals = Mathf.Clamp (this.decimals + 1, 0, 6);
		this.DecimalsText.text = this.decimals.ToString();
	}

	public void DecrementDecimals() {
		this.decimals = Mathf.Clamp (this.decimals - 1, 0, 6);
		this.DecimalsText.text = this.decimals.ToString();
	}
}
