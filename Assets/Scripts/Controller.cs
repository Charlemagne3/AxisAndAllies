using UnityEngine;
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
		Summation,
		Individual
	}
		
	public enum RuleSet {
		AA1940 = 1940,
		AA1941 = 1941,
		AA1942 = 1942
	}

	// Options values
	private Theater theater;
	private SumMode sumMode;
	private int decimals;
	private int rules;

	// theater containers
	public GameObject Land1940;
	public GameObject Sea1940;
	public GameObject Air1940;
	public GameObject Land1941;
	public GameObject Sea1941;
	public GameObject Land1942;
	public GameObject Sea1942;
	public GameObject Air1942;

	// Main containers
	public GameObject Setup;
	public GameObject Outcome;

	// Battle Containers
	public GameObject AA1940;
	public GameObject AA1941;
	public GameObject AA1942;

	// Options container
	public GameObject OptionsPanel;
	private bool showOptions;

	// Mode Toggle
	public Dropdown ModeDropdown;

	// Rules Toggle
	public Dropdown RulesDropdown;

	// Attacker units
	private List<Infantry> attackerInfantry;
	private List<MechanizedInfantry> attackerMechanizedInfantry;
	private List<Artillery> attackerArtillery;
	private List<Tank> attackerTanks;
	private List<Fighter> attackerFightersLand;
	private List<Fighter> attackerFightersSea;
	private List<TacticalBomber> attackerTacticalBombersLand;
	private List<TacticalBomber> attackerTacticalBombersSea;	
	private List<Bomber> attackerBombersLand;
	private List<Bomber> attackerBombersSea;
	private List<Battleship> attackerBattleships;
	private List<Cruiser> attackerCruisers;
	private List<Destroyer> attackerDestroyers;
	private List<Submarine> attackerSubmarines;
	private List<AircraftCarrier> attackerAircraftCarriers;
	private List<AircraftCarrier1940> attackerAircraftCarriers1940;

	private List<Battleship> bombardingBattleships;
	private List<Cruiser> bombardingCruisers;

	private List<Fighter> escortFighters;
	private List<TacticalBomber> escortedTacticalBombers;
	private List<Bomber> escortedBombers;

	// Defender units
	private List<Infantry> defenderInfantry;
	private List<MechanizedInfantry> defenderMechanizedInfantry;
	private List<Artillery> defenderArtillery;
	private List<Tank> defenderTanks;
	private List<Fighter> defenderFightersLand;
	private List<Fighter> defenderFightersSea;	
	private List<TacticalBomber> defenderTacticalBombersLand;
	private List<TacticalBomber> defenderTacticalBombersSea;
	private List<Bomber> defenderBombersLand;
	private List<Battleship> defenderBattleships;
	private List<Cruiser> defenderCruisers;
	private List<Destroyer> defenderDestroyers;
	private List<Submarine> defenderSubmarines;
	private List<AircraftCarrier> defenderAircraftCarriers;
	private List<AircraftCarrier1940> defenderAircraftCarriers1940;

	private List<AntiAircraftArtillery> antiAircraftArtillery;

	private List<Fighter> interceptors;

	// Texts for all the units	
	public Text AttackerInfantryText1940;
	public Text DefenderInfantryText1940;
	public Text AttackerInfantryText1941;
	public Text DefenderInfantryText1941;
	public Text AttackerInfantryText1942;
	public Text DefenderInfantryText1942;

	public Text AttackerArtilleryText1940;
	public Text DefenderArtilleryText1940;
	public Text AttackerArtilleryText1942;
	public Text DefenderArtilleryText1942;

	public Text AttackerTanksText1940;
	public Text DefenderTanksText1940;
	public Text AttackerTanksText1941;
	public Text DefenderTanksText1941;	
	public Text AttackerTanksText1942;
	public Text DefenderTanksText1942;

	public Text AttackerFightersLandText1940;
	public Text DefenderFightersLandText1940;
	public Text AttackerFightersLandText1941;
	public Text DefenderFightersLandText1941;
	public Text AttackerFightersLandText1942;
	public Text DefenderFightersLandText1942;

	public Text AttackerFightersSeaText1940;
	public Text DefenderFightersSeaText1940;
	public Text AttackerFightersSeaText1941;
	public Text DefenderFightersSeaText1941;
	public Text AttackerFightersSeaText1942;
	public Text DefenderFightersSeaText1942;

	public Text AttackerTacticalBombersLandText1940;
	public Text DefenderTacticalBombersLandText1940;

	public Text AttackerTacticalBombersSeaText1940;
	public Text DefenderTacticalBombersSeaText1940;

	public Text AttackerBombersLandText1940;
	public Text DefenderBombersLandText1940;
	public Text AttackerBombersLandText1941;
	public Text DefenderBombersLandText1941;
	public Text AttackerBombersLandText1942;
	public Text DefenderBombersLandText1942;

	public Text AttackerBombersSeaText1940;
	public Text AttackerBombersSeaText1941;
	public Text AttackerBombersSeaText1942;

	public Text AttackerBattleshipsText1940;
	public Text DefenderBattleshipsText1940;
	public Text AttackerBattleshipsText1941;
	public Text DefenderBattleshipsText1941;
	public Text AttackerBattleshipsText1942;
	public Text DefenderBattleshipsText1942;

	public Text AttackerCruisersText1940;
	public Text DefenderCruisersText1940;
	public Text AttackerCruisersText1942;
	public Text DefenderCruisersText1942;

	public Text AttackerDestroyersText1940;
	public Text DefenderDestroyersText1940;
	public Text AttackerDestroyersText1941;
	public Text DefenderDestroyersText1941;
	public Text AttackerDestroyersText1942;
	public Text DefenderDestroyersText1942;

	public Text AttackerSubmarinesText1940;
	public Text DefenderSubmarinesText1940;
	public Text AttackerSubmarinesText1941;
	public Text DefenderSubmarinesText1941;
	public Text AttackerSubmarinesText1942;
	public Text DefenderSubmarinesText1942;

	public Text AttackerAircraftCarriersText1940;
	public Text DefenderAircraftCarriersText1940;
	public Text AttackerAircraftCarriersText1941;
	public Text DefenderAircraftCarriersText1941;
	public Text AttackerAircraftCarriersText1942;
	public Text DefenderAircraftCarriersText1942;

	public Text BombardingBattleshipsText1940;
	public Text BombardingCruisersText1940;
	public Text BombardingBattleshipsText1942;
	public Text BombardingCruisersText1942;

	public Text AntiAircraftArtilleryText1940;
	public Text AntiAircraftArtilleryText1942;

	public Text EscortFightersText1940;
	public Text EscortedTacticalBombersText1940;	
	public Text EscortedBombersText1940;	
	public Text EscortFightersText1942;
	public Text EscortedBombersText1942;

	public Text InterceptorsText1940;
	public Text InterceptorsText1942;

	public Text AttackerOutcomeText;
	public Text DefenderOutcomeText;

	public Text DecimalsText;

	// Use this for initialization
	void Start () {
		
		this.theater = Theater.Land;
		this.sumMode = SumMode.Summation;
		this.decimals = 2;
		this.rules = (int)RuleSet.AA1940;

		this.attackerInfantry = new List<Infantry>(2);
		this.attackerArtillery = new List<Artillery>(2);
		this.attackerTanks = new List<Tank>(2);
		this.attackerFightersLand = new List<Fighter>(2);
		this.attackerFightersSea = new List<Fighter>(2);
		this.attackerTacticalBombersLand = new List<TacticalBomber>(2);
		this.attackerTacticalBombersSea = new List<TacticalBomber>(2);
		this.attackerBombersLand = new List<Bomber>(2);
		this.attackerBombersSea = new List<Bomber>(2);
		this.attackerBattleships = new List<Battleship>(2);
		this.attackerCruisers = new List<Cruiser>(2);
		this.attackerDestroyers = new List<Destroyer>(2);
		this.attackerSubmarines = new List<Submarine>(2);
		this.attackerAircraftCarriers = new List<AircraftCarrier>(2);
		this.attackerAircraftCarriers1940 = new List<AircraftCarrier1940>(2);

		this.bombardingBattleships = new List<Battleship>(2);
		this.bombardingCruisers = new List<Cruiser>(2);

		this.escortFighters = new List<Fighter>(2);
		this.escortedTacticalBombers = new List<TacticalBomber>(2);
		this.escortedBombers = new List<Bomber>(2);

		this.defenderInfantry = new List<Infantry>(2);
		this.defenderArtillery = new List<Artillery>(2);
		this.defenderTanks = new List<Tank>(2);
		this.defenderFightersLand = new List<Fighter>(2);
		this.defenderFightersSea = new List<Fighter>(2);
		this.defenderTacticalBombersLand = new List<TacticalBomber>(2);
		this.defenderTacticalBombersSea = new List<TacticalBomber>(2);
		this.defenderBombersLand = new List<Bomber>(2);
		this.defenderBattleships = new List<Battleship>(2);
		this.defenderCruisers = new List<Cruiser>(2);
		this.defenderDestroyers = new List<Destroyer>(2);
		this.defenderSubmarines = new List<Submarine>(2);
		this.defenderAircraftCarriers = new List<AircraftCarrier>(2);
		this.defenderAircraftCarriers1940 = new List<AircraftCarrier1940>(2);

		this.antiAircraftArtillery = new List<AntiAircraftArtillery>(2);

		this.interceptors = new List<Fighter>(2);

		this.AttackerOutcomeText.text = "";
		this.DefenderOutcomeText.text = "";

		this.DecimalsText.text = this.decimals.ToString();
	}

	// Set to land mode
	public void LandBattle() {
		this.theater = Theater.Land;
		this.Land1940.SetActive(true);
		this.Sea1940.SetActive(false);
		this.Air1940.SetActive(false);
		this.Land1941.SetActive(true);
		this.Sea1941.SetActive(false);
		this.Land1942.SetActive(true);
		this.Sea1942.SetActive(false);
		this.Air1942.SetActive(false);
		this.Land1940.GetComponent<Image>().color = new Color (255, 255, 255, 255);
		this.Land1941.GetComponent<Image>().color = new Color (255, 255, 255, 255);
		this.Land1942.GetComponent<Image>().color = new Color (255, 255, 255, 255);
		this.reset();
	}

	// Set to sea mode
	public void SeaBattle() {
		this.theater = Theater.Sea;
		this.Land1940.SetActive(false);
		this.Sea1940.SetActive(true);
		this.Air1940.SetActive(false);
		this.Land1941.SetActive(false);
		this.Sea1941.SetActive(true);
		this.Land1942.SetActive(false);
		this.Sea1942.SetActive(true);
		this.Air1942.SetActive(false);
		this.Sea1940.GetComponent<Image>().color = new Color (255, 255, 255, 255);
		this.Sea1941.GetComponent<Image>().color = new Color (255, 255, 255, 255);
		this.Sea1942.GetComponent<Image>().color = new Color (255, 255, 255, 255);
		this.reset();
	}

	// Set to strategic bombing mode
	public void AirBattle() {
		this.theater = Theater.Air;
		this.Land1940.SetActive(false);
		this.Sea1940.SetActive(false);
		this.Air1940.SetActive(true);
		this.Land1941.SetActive(false);
		this.Sea1941.SetActive(false);
		this.Land1942.SetActive(false);
		this.Sea1942.SetActive(false);
		this.Air1942.SetActive(true);
		this.Air1940.GetComponent<Image>().color = new Color (255, 255, 255, 255);
		this.Air1942.GetComponent<Image>().color = new Color (255, 255, 255, 255);
		this.reset();
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

	public void RulesChange() {
		if (this.RulesDropdown.value == 0) {
			this.rules = (int)RuleSet.AA1940;
			this.AA1940.SetActive(true);
			this.AA1941.SetActive(false);
			this.AA1942.SetActive(false);
		} else if (this.RulesDropdown.value == 1) {
			this.rules = (int)RuleSet.AA1941;
			this.AA1940.SetActive(false);
			this.AA1941.SetActive(true);
			this.AA1942.SetActive(false);
		} else if (this.RulesDropdown.value == 2) {
			this.rules = (int)RuleSet.AA1942;
			this.AA1940.SetActive(false);
			this.AA1941.SetActive(false);
			this.AA1942.SetActive(true);
		}
		this.reset();
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
			this.attackerTacticalBombersLand.Count +
			this.attackerTacticalBombersSea.Count +
			this.attackerBombersLand.Count +
			this.attackerBombersSea.Count +
			this.attackerBattleships.Count +
			this.attackerCruisers.Count +
			this.attackerDestroyers.Count +
			this.attackerSubmarines.Count +
			this.attackerAircraftCarriers.Count +
			this.attackerAircraftCarriers1940.Count
		);
		List<Unit> defenders = new List<Unit>(
			this.defenderInfantry.Count +
			this.defenderArtillery.Count +
			this.defenderTanks.Count +
			this.defenderFightersLand.Count +
			this.defenderFightersSea.Count +
			this.defenderTacticalBombersLand.Count +
			this.defenderTacticalBombersSea.Count +
			this.defenderBombersLand.Count +
			this.defenderBattleships.Count +
			this.defenderCruisers.Count +
			this.defenderDestroyers.Count +
			this.defenderSubmarines.Count +
			this.defenderAircraftCarriers.Count +
			this.defenderAircraftCarriers1940.Count
		);
		List<Unit> bombarders = new List<Unit>(
			this.bombardingBattleships.Count + 
			this.bombardingCruisers.Count
		);
		List<Unit> raiders = new List<Unit>(
			this.escortFighters.Count +
			this.escortedTacticalBombers.Count +
			this.escortedBombers.Count
		);
		List<Unit> interceptors = new List<Unit>(this.interceptors.Count);

		switch (this.theater) {
			case Theater.Land:
			
				this.attackerInfantry.ForEach(x => attackers.Add(x));
				this.attackerArtillery.ForEach(x => attackers.Add(x));
				this.attackerTanks.ForEach(x => attackers.Add(x));
				this.attackerFightersLand.ForEach(x => attackers.Add(x));
			    this.attackerTacticalBombersLand.ForEach(x => attackers.Add(x));
			    this.attackerBombersLand.ForEach(x => attackers.Add(x));

				this.bombardingBattleships.ForEach (x => bombarders.Add(x));
				this.bombardingCruisers.ForEach (x => bombarders.Add(x));

				this.defenderInfantry.ForEach(x => defenders.Add(x));
				this.defenderArtillery.ForEach(x => defenders.Add(x));
				this.defenderTanks.ForEach(x => defenders.Add(x));
				this.defenderFightersLand.ForEach(x => defenders.Add(x));
		    	this.defenderTacticalBombersLand.ForEach(x => defenders.Add(x));
			    this.defenderBombersLand.ForEach(x => defenders.Add(x));

				break;

			case Theater.Sea:
			
				this.attackerFightersSea.ForEach(x => attackers.Add(x));
			    this.attackerTacticalBombersSea.ForEach(x => attackers.Add(x));
			    this.attackerBombersSea.ForEach(x => attackers.Add(x));
				this.attackerBattleships.ForEach(x => attackers.Add(x));
				this.attackerCruisers.ForEach(x => attackers.Add(x));
				this.attackerDestroyers.ForEach(x => attackers.Add(x));
				this.attackerSubmarines.ForEach(x => attackers.Add(x));
			    this.attackerAircraftCarriers.ForEach(x => attackers.Add(x));
			    this.attackerAircraftCarriers1940.ForEach(x => attackers.Add(x));
				
			    this.defenderFightersSea.ForEach(x => defenders.Add(x));
			    this.defenderTacticalBombersSea.ForEach(x => defenders.Add(x));
				this.defenderBattleships.ForEach(x => defenders.Add(x));
				this.defenderCruisers.ForEach(x => defenders.Add(x));
				this.defenderDestroyers.ForEach(x => defenders.Add(x));
				this.defenderSubmarines.ForEach(x => defenders.Add(x));
			    this.defenderAircraftCarriers.ForEach(x => defenders.Add(x));
			    this.defenderAircraftCarriers1940.ForEach(x => defenders.Add(x));

				break;

			case Theater.Air:
				
				this.escortFighters.ForEach(x => raiders.Add(x));
		     	this.escortedTacticalBombers.ForEach(x => raiders.Add(x));
			    this.escortedBombers.ForEach(x => raiders.Add(x));
					
				this.interceptors.ForEach(x => interceptors.Add(x));

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

	private void reset() {
		this.attackerInfantry.Clear();
		this.attackerArtillery.Clear();
		this.attackerTanks.Clear();
		this.attackerFightersLand.Clear();
		this.attackerFightersSea.Clear();
		this.attackerBombersLand.Clear();
		this.attackerBombersSea.Clear();
		this.attackerBattleships.Clear();
		this.attackerCruisers.Clear();
		this.attackerDestroyers.Clear();
		this.attackerSubmarines.Clear();
		this.attackerAircraftCarriers.Clear();
		this.attackerAircraftCarriers1940.Clear();
		this.defenderInfantry.Clear();
		this.defenderArtillery.Clear();
		this.defenderTanks.Clear();
		this.defenderFightersLand.Clear();
		this.defenderFightersSea.Clear();
		this.defenderBombersLand.Clear();
		this.defenderBattleships.Clear();
		this.defenderCruisers.Clear();
		this.defenderDestroyers.Clear();
		this.defenderSubmarines.Clear();
		this.defenderAircraftCarriers.Clear();
		this.defenderAircraftCarriers1940.Clear();
		this.bombardingBattleships.Clear();
		this.bombardingCruisers.Clear();
		this.escortFighters.Clear();
		this.escortedBombers.Clear();
		this.interceptors.Clear();

		this.AttackerInfantryText1940.text = "0";
		this.DefenderInfantryText1940.text = "0";
		this.AttackerInfantryText1941.text = "0";
		this.DefenderInfantryText1941.text = "0";
		this.AttackerInfantryText1942.text = "0";
		this.DefenderInfantryText1942.text = "0";

		this.AttackerArtilleryText1940.text = "0";
		this.DefenderArtilleryText1940.text = "0";
		this.AttackerArtilleryText1942.text = "0";
		this.DefenderArtilleryText1942.text = "0";

		this.AttackerTanksText1940.text = "0";
		this.DefenderTanksText1940.text = "0";
		this.AttackerTanksText1941.text = "0";
		this.DefenderTanksText1941.text = "0";	
		this.AttackerTanksText1942.text = "0";
		this.DefenderTanksText1942.text = "0";

		this.AttackerFightersLandText1940.text = "0";
		this.DefenderFightersLandText1940.text = "0";
		this.AttackerFightersLandText1941.text = "0";
		this.DefenderFightersLandText1941.text = "0";
		this.AttackerFightersLandText1942.text = "0";
		this.DefenderFightersLandText1942.text = "0";

		this.AttackerFightersSeaText1940.text = "0";
		this.DefenderFightersSeaText1940.text = "0";
		this.AttackerFightersSeaText1941.text = "0";
		this.DefenderFightersSeaText1941.text = "0";
		this.AttackerFightersSeaText1942.text = "0";
		this.DefenderFightersSeaText1942.text = "0";

		this.AttackerBombersLandText1940.text = "0";
		this.DefenderBombersLandText1940.text = "0";
		this.AttackerBombersLandText1941.text = "0";
		this.DefenderBombersLandText1941.text = "0";
		this.AttackerBombersLandText1942.text = "0";
		this.DefenderBombersLandText1942.text = "0";

		this.AttackerBombersSeaText1940.text = "0";
		this.AttackerBombersSeaText1941.text = "0";
		this.AttackerBombersSeaText1942.text = "0";

		this.AttackerBattleshipsText1940.text = "0";
		this.DefenderBattleshipsText1940.text = "0";
		this.AttackerBattleshipsText1941.text = "0";
		this.DefenderBattleshipsText1941.text = "0";
		this.AttackerBattleshipsText1942.text = "0";
		this.DefenderBattleshipsText1942.text = "0";

		this.AttackerCruisersText1940.text = "0";
		this.DefenderCruisersText1940.text = "0";
		this.AttackerCruisersText1942.text = "0";
		this.DefenderCruisersText1942.text = "0";

		this.AttackerDestroyersText1940.text = "0";
		this.DefenderDestroyersText1940.text = "0";
		this.AttackerDestroyersText1941.text = "0";
		this.DefenderDestroyersText1941.text = "0";
		this.AttackerDestroyersText1942.text = "0";
		this.DefenderDestroyersText1942.text = "0";

		this.AttackerSubmarinesText1940.text = "0";
		this.DefenderSubmarinesText1940.text = "0";
		this.AttackerSubmarinesText1941.text = "0";
		this.DefenderSubmarinesText1941.text = "0";
		this.AttackerSubmarinesText1942.text = "0";
		this.DefenderSubmarinesText1942.text = "0";

		this.AttackerAircraftCarriersText1940.text = "0";
		this.DefenderAircraftCarriersText1940.text = "0";
		this.AttackerAircraftCarriersText1941.text = "0";
		this.DefenderAircraftCarriersText1941.text = "0";
		this.AttackerAircraftCarriersText1942.text = "0";
		this.DefenderAircraftCarriersText1942.text = "0";

		this.BombardingBattleshipsText1940.text = "0";
		this.BombardingCruisersText1940.text = "0";
		this.BombardingBattleshipsText1942.text = "0";
		this.BombardingCruisersText1942.text = "0";

		this.AntiAircraftArtilleryText1940.text = "0";
		this.AntiAircraftArtilleryText1942.text = "0";

		this.EscortFightersText1940.text = "0";
		this.EscortedBombersText1940.text = "0";	
		this.EscortFightersText1942.text = "0";
		this.EscortedBombersText1942.text = "0";

		this.InterceptorsText1940.text = "0";
		this.InterceptorsText1942.text = "0";	
	}

	// Increment and decrement functions for all units

    // Infantry

	public void IncrementAttackerInfantry() {
		this.attackerInfantry.Add(new Infantry());
		string count = this.attackerInfantry.Count.ToString();
		this.AttackerInfantryText1940.text = count;
		this.AttackerInfantryText1941.text = count;
		this.AttackerInfantryText1942.text = count;
	}
		
	public void DecrementAttackerInfantry() {
		if (this.attackerInfantry.Any()) {
			this.attackerInfantry.RemoveAt(0);
		}
		string count = this.attackerInfantry.Count.ToString();
		this.AttackerInfantryText1940.text = count;
		this.AttackerInfantryText1941.text = count;
		this.AttackerInfantryText1942.text = count;
	}

	public void IncrementDefenderInfantry() {
		this.defenderInfantry.Add(new Infantry());
		string count = this.defenderInfantry.Count.ToString();
		this.DefenderInfantryText1940.text = count;
		this.DefenderInfantryText1941.text = count;
		this.DefenderInfantryText1942.text = count;
	}

	public void DecrementDefenderInfantry() {
		if (this.defenderInfantry.Any()) {
			this.defenderInfantry.RemoveAt(0);
		}
		string count = this.defenderInfantry.Count.ToString();
		this.DefenderInfantryText1940.text = count;
		this.DefenderInfantryText1941.text = count;
		this.DefenderInfantryText1942.text = count;	
	}
		
	// Artillery
		
	public void IncrementAttackerArtillery() {
		this.attackerArtillery.Add(new Artillery());
		string count = this.attackerArtillery.Count.ToString();
		this.AttackerArtilleryText1940.text = count;
		this.AttackerArtilleryText1942.text = count;
	}

	public void DecrementAttackerArtillery() {
		if (this.attackerArtillery.Any()) {
			this.attackerArtillery.RemoveAt(0);
		}
		string count = this.attackerArtillery.Count.ToString();
		this.AttackerArtilleryText1940.text = count;
		this.AttackerArtilleryText1942.text = count;
	}

	public void IncrementDefenderArtillery() {
		this.defenderArtillery.Add(new Artillery());
		string count = this.defenderArtillery.Count.ToString();
		this.DefenderArtilleryText1940.text = count;
		this.DefenderArtilleryText1942.text = count;
	}
		
	public void DecrementDefenderArtillery() {
		if (this.defenderArtillery.Any()) {
			this.defenderArtillery.RemoveAt(0);
		}
		string count = this.defenderArtillery.Count.ToString();
		this.DefenderArtilleryText1940.text = count;
		this.DefenderArtilleryText1942.text = count;
	}
		
	// Tanks

	public void IncrementAttackerTanks() {
		this.attackerTanks.Add(new Tank());
		string count = this.attackerTanks.Count.ToString();
		this.AttackerTanksText1940.text = count;
		this.AttackerTanksText1941.text = count;
		this.AttackerTanksText1942.text = count;
	}
		
	public void DecrementAttackerTanks() {
		if (this.attackerTanks.Any()) {
			this.attackerTanks.RemoveAt(0);
		}
		string count = this.attackerTanks.Count.ToString();
		this.AttackerTanksText1940.text = count;
		this.AttackerTanksText1941.text = count;
		this.AttackerTanksText1942.text = count;
	}

	public void IncrementDefenderTanks() {
		this.defenderTanks.Add(new Tank());
		string count = this.defenderTanks.Count.ToString();
		this.DefenderTanksText1940.text = count;
		this.DefenderTanksText1941.text = count;
		this.DefenderTanksText1942.text = count;
	}
		
	public void DecrementDefenderTanks() {
		if (this.defenderTanks.Any()) {
			this.defenderTanks.RemoveAt(0);
		}
		string count = this.defenderTanks.Count.ToString();
		this.DefenderTanksText1940.text = count;
		this.DefenderTanksText1941.text = count;
		this.DefenderTanksText1942.text = count;
	}

	// Fighters

	public void IncrementAttackerFightersLand() {
		this.attackerFightersLand.Add(new Fighter());
		string count = this.attackerFightersLand.Count.ToString();
		this.AttackerFightersLandText1940.text = count;
		this.AttackerFightersLandText1941.text = count;
		this.AttackerFightersLandText1942.text = count;
	}
		
	public void DecrementAttackerFightersLand() {
		if (this.attackerFightersLand.Any()) {
			this.attackerFightersLand.RemoveAt(0);
		}
		string count = this.attackerFightersLand.Count.ToString();
		this.AttackerFightersLandText1940.text = count;
		this.AttackerFightersLandText1941.text = count;
		this.AttackerFightersLandText1942.text = count;
	}

	public void IncrementDefenderFightersLand() {
		this.defenderFightersLand.Add(new Fighter());
		string count = this.defenderFightersLand.Count.ToString();
		this.DefenderFightersLandText1940.text = count;
		this.DefenderFightersLandText1941.text = count;
		this.DefenderFightersLandText1942.text = count;
	}
		
	public void DecrementDefenderFightersLand() {
		if (this.defenderFightersLand.Any()) {
			this.defenderFightersLand.RemoveAt(0);
		}
		string count = this.defenderFightersLand.Count.ToString();
		this.DefenderFightersLandText1940.text = count;
		this.DefenderFightersLandText1941.text = count;
		this.DefenderFightersLandText1942.text = count;
	}

	public void IncrementAttackerFightersSea() {
		this.attackerFightersSea.Add(new Fighter());
		string count = this.attackerFightersSea.Count.ToString();
		this.AttackerFightersSeaText1940.text = count;
		this.AttackerFightersSeaText1941.text = count;
		this.AttackerFightersSeaText1942.text = count;
	}
		
	public void DecrementAttackerFightersSea() {
		if (this.attackerFightersSea.Any()) {
			this.attackerFightersSea.RemoveAt(0);
		}
		string count = this.attackerFightersSea.Count.ToString();
		this.AttackerFightersSeaText1940.text = count;
		this.AttackerFightersSeaText1941.text = count;
		this.AttackerFightersSeaText1942.text = count;
	}
		
	public void IncrementDefenderFightersSea() {
		this.defenderFightersSea.Add(new Fighter());
		string count = this.defenderFightersSea.Count.ToString();
		this.DefenderFightersSeaText1940.text = count;
		this.DefenderFightersSeaText1941.text = count;
		this.DefenderFightersSeaText1942.text = count;
	}
		
	public void DecrementDefenderFightersSea() {
		if (this.defenderFightersSea.Any()) {
			this.defenderFightersSea.RemoveAt(0);
		}
		string count = this.defenderFightersSea.Count.ToString();
		this.DefenderFightersSeaText1940.text = count;
		this.DefenderFightersSeaText1941.text = count;
		this.DefenderFightersSeaText1942.text = count;
	}
		
	// Bombers

	public void IncrementAttackerBombersLand() {
		this.attackerBombersLand.Add(new Bomber());
		string count = this.attackerBombersLand.Count.ToString();
		this.AttackerBombersLandText1940.text = count;
		this.AttackerBombersLandText1941.text = count;
		this.AttackerBombersLandText1942.text = count;
	}
		
	public void DecrementAttackerBombersLand() {
		if (this.attackerBombersLand.Any()) {
			this.attackerBombersLand.RemoveAt(0);
		}
		string count = this.attackerBombersLand.Count.ToString();
		this.AttackerBombersLandText1940.text = count;
		this.AttackerBombersLandText1941.text = count;
		this.AttackerBombersLandText1942.text = count;
	}

	public void IncrementDefenderBombersLand() {
		this.defenderBombersLand.Add(new Bomber());
		string count = this.defenderBombersLand.Count.ToString();
		this.DefenderBombersLandText1940.text = count;
		this.DefenderBombersLandText1941.text = count;
		this.DefenderBombersLandText1942.text = count;
	}

	public void DecrementDefenderBombersLand() {
		if (this.defenderBombersLand.Any()) {
			this.defenderBombersLand.RemoveAt(0);
		}
		string count = this.defenderBombersLand.Count.ToString();
		this.DefenderBombersLandText1940.text = count;
		this.DefenderBombersLandText1941.text = count;
		this.DefenderBombersLandText1942.text = count;
	}
		
	public void IncrementAttackerBombersSea() {
		this.attackerBombersSea.Add(new Bomber());
		string count = this.attackerBombersSea.Count.ToString();
		this.AttackerBombersSeaText1940.text = count;
		this.AttackerBombersSeaText1941.text = count;
		this.AttackerBombersSeaText1942.text = count;
	}
		
	public void DecrementAttackerBombersSea() {
		if (this.attackerBombersSea.Any()) {
			this.attackerBombersSea.RemoveAt(0);
		}
		string count = this.attackerBombersSea.Count.ToString();
		this.AttackerBombersSeaText1940.text = count;
		this.AttackerBombersSeaText1941.text = count;
		this.AttackerBombersSeaText1942.text = count;
	}
		
	// Battleships

	public void IncrementAttackerBattleships() {
		this.attackerBattleships.Add(new Battleship());
		string count = this.attackerBattleships.Count.ToString();
		this.AttackerBattleshipsText1940.text = count;
		this.AttackerBattleshipsText1941.text = count;
		this.AttackerBattleshipsText1942.text = count;
	}

	public void DecrementAttackerBattleships() {
		if (this.attackerBattleships.Any()) {
			this.attackerBattleships.RemoveAt(0);
		}
		string count = this.attackerBattleships.Count.ToString();
		this.AttackerBattleshipsText1940.text = count;
		this.AttackerBattleshipsText1941.text = count;
		this.AttackerBattleshipsText1942.text = count;	
	}
		
	public void IncrementDefenderBattleships() {
		this.defenderBattleships.Add(new Battleship());
		string count = this.defenderBattleships.Count.ToString();
		this.DefenderBattleshipsText1940.text = count;
		this.DefenderBattleshipsText1941.text = count;
		this.DefenderBattleshipsText1942.text = count;	
	}
		
	public void DecrementDefenderBattleships() {
		if (this.defenderBattleships.Any()) {
			this.defenderBattleships.RemoveAt(0);
		}
		string count = this.defenderBattleships.Count.ToString();
		this.DefenderBattleshipsText1940.text = count;
		this.DefenderBattleshipsText1941.text = count;
		this.DefenderBattleshipsText1942.text = count;	
	}
		
	// Cruisers

	public void IncrementAttackerCruisers() {
		this.attackerCruisers.Add(new Cruiser());
		string count = this.attackerCruisers.Count.ToString();
		this.AttackerCruisersText1940.text = count;
		this.AttackerCruisersText1942.text = count;	
	}
		
	public void DecrementAttackerCruisers() {
		if (this.attackerCruisers.Any()) {
			this.attackerCruisers.RemoveAt(0);
		}
		string count = this.attackerCruisers.Count.ToString();
		this.AttackerCruisersText1940.text = count;
		this.AttackerCruisersText1942.text = count;	
	}
		
	public void IncrementDefenderCruisers() {
		this.defenderCruisers.Add(new Cruiser());
		string count = this.defenderCruisers.Count.ToString();
		this.DefenderCruisersText1940.text = count;
		this.DefenderCruisersText1942.text = count;	
	}

	public void DecrementDefenderCruisers() {
		if (this.defenderCruisers.Any()) {
			this.defenderCruisers.RemoveAt(0);
		}
		string count = this.defenderCruisers.Count.ToString();
		this.DefenderCruisersText1940.text = count;
		this.DefenderCruisersText1942.text = count;	
	}
		
	// Destroyers

	public void IncrementAttackerDestroyers() {
		this.attackerDestroyers.Add(new Destroyer());
		string count = this.attackerDestroyers.Count.ToString();
		this.AttackerDestroyersText1940.text = count;
		this.AttackerDestroyersText1941.text = count;
		this.AttackerDestroyersText1942.text = count;
	}
		
	public void DecrementAttackerDestroyers() {
		if (this.attackerDestroyers.Any()) {
			this.attackerDestroyers.RemoveAt(0);
		}
		string count = this.attackerDestroyers.Count.ToString();
		this.AttackerDestroyersText1940.text = count;
		this.AttackerDestroyersText1941.text = count;
		this.AttackerDestroyersText1942.text = count;
	}

	public void IncrementDefenderDestroyers() {
		this.defenderDestroyers.Add(new Destroyer());
		string count = this.defenderDestroyers.Count.ToString();
		this.DefenderDestroyersText1940.text = count;
		this.DefenderDestroyersText1941.text = count;
		this.DefenderDestroyersText1942.text = count;
	}

	public void DecrementDefenderDestroyers() {
		if (this.defenderDestroyers.Any()) {
			this.defenderDestroyers.RemoveAt(0);
		}
		string count = this.defenderDestroyers.Count.ToString();
		this.DefenderDestroyersText1940.text = count;
		this.DefenderDestroyersText1941.text = count;
		this.DefenderDestroyersText1942.text = count;
	}
		
	// Submarines

	public void IncrementAttackerSubmarines() {
		this.attackerSubmarines.Add(new Submarine());
		string count = this.attackerSubmarines.Count.ToString();
		this.AttackerSubmarinesText1940.text = count;
		this.AttackerSubmarinesText1941.text = count;
		this.AttackerSubmarinesText1942.text = count;
	}
		
	public void DecrementAttackerSubmarines() {
		if (this.attackerSubmarines.Any()) {
			this.attackerSubmarines.RemoveAt(0);
		}
		string count = this.attackerSubmarines.Count.ToString();
		this.AttackerSubmarinesText1940.text = count;
		this.AttackerSubmarinesText1941.text = count;
		this.AttackerSubmarinesText1942.text = count;
	}

	public void IncrementDefenderSubmarines() {
		this.defenderSubmarines.Add(new Submarine());
		string count = this.defenderSubmarines.Count.ToString();
		this.DefenderSubmarinesText1940.text = count;
		this.DefenderSubmarinesText1941.text = count;
		this.DefenderSubmarinesText1942.text = count;
	}
		
	public void DecrementDefenderSubmarines() {
		if (this.defenderSubmarines.Any()) {
			this.defenderSubmarines.RemoveAt(0);
		}
		string count = this.defenderSubmarines.Count.ToString();
		this.DefenderSubmarinesText1940.text = count;
		this.DefenderSubmarinesText1941.text = count;
		this.DefenderSubmarinesText1942.text = count;
	}

	// Aircraft Carriers

	public void IncrementAttackerAircraftCarriers() {
		if (this.rules == (int)RuleSet.AA1940) {
			this.attackerAircraftCarriers1940.Add(new AircraftCarrier1940());
			this.AttackerAircraftCarriersText1940.text = this.attackerAircraftCarriers1940.Count.ToString();
		}
		else if (this.rules == (int)RuleSet.AA1941) {
			this.attackerAircraftCarriers.Add(new AircraftCarrier());
			this.AttackerAircraftCarriersText1941.text = this.attackerAircraftCarriers.Count.ToString();
		}
		else if (this.rules == (int)RuleSet.AA1942) {
			this.attackerAircraftCarriers.Add(new AircraftCarrier());
			this.AttackerAircraftCarriersText1942.text = this.attackerAircraftCarriers.Count.ToString();
		}
	}

	public void DecrementAttackerAircraftCarriers() {
		if (this.rules == (int)RuleSet.AA1940) {
			if (this.attackerAircraftCarriers1940.Any()) {
				this.attackerAircraftCarriers1940.RemoveAt(0);
			}
			this.AttackerAircraftCarriersText1940.text = this.attackerAircraftCarriers1940.Count.ToString();
		}
		else if (this.rules == (int)RuleSet.AA1941) {
			if (this.attackerAircraftCarriers.Any()) {
				this.attackerAircraftCarriers.RemoveAt(0);
			}
			this.AttackerAircraftCarriersText1941.text = this.attackerAircraftCarriers.Count.ToString();
		}
		else if (this.rules == (int)RuleSet.AA1942) {
			if (this.attackerAircraftCarriers.Any()) {
				this.attackerAircraftCarriers.RemoveAt(0);
			}			
			this.AttackerAircraftCarriersText1942.text = this.attackerAircraftCarriers.Count.ToString();
		}
	}

	public void IncrementDefenderAircraftCarriers() {
		if (this.rules == (int)RuleSet.AA1940) {
			this.defenderAircraftCarriers1940.Add(new AircraftCarrier1940());
			this.DefenderAircraftCarriersText1940.text = this.defenderAircraftCarriers1940.Count.ToString();
		}
		else if (this.rules == (int)RuleSet.AA1941) {
			this.attackerAircraftCarriers.Add(new AircraftCarrier());
			this.DefenderAircraftCarriersText1941.text = this.defenderAircraftCarriers.Count.ToString();
		}
		else if (this.rules == (int)RuleSet.AA1942) {
			this.attackerAircraftCarriers.Add(new AircraftCarrier());
			this.DefenderAircraftCarriersText1942.text = this.defenderAircraftCarriers.Count.ToString();
		}
	}
		
	public void DecrementDefenderAircraftCarriers1940() {
		if (this.rules == (int)RuleSet.AA1940) {
			if (this.defenderAircraftCarriers1940.Any()) {
				this.defenderAircraftCarriers1940.RemoveAt(0);
			}
			this.DefenderAircraftCarriersText1940.text = this.defenderAircraftCarriers1940.Count.ToString();
		}
		else if (this.rules == (int)RuleSet.AA1941) {
			if (this.defenderAircraftCarriers.Any()) {
				this.defenderAircraftCarriers.RemoveAt(0);
			}
			this.DefenderAircraftCarriersText1941.text = this.defenderAircraftCarriers.Count.ToString();
		}
		else if (this.rules == (int)RuleSet.AA1942) {
			if (this.defenderAircraftCarriers.Any()) {
				this.defenderAircraftCarriers.RemoveAt(0);
			}			
			this.DefenderAircraftCarriersText1942.text = this.defenderAircraftCarriers.Count.ToString();
		}
	}

	// Bombarding Battleships

	public void IncrementBombardingBattleships() {
		this.bombardingBattleships.Add(new Battleship());
		string count = this.bombardingBattleships.Count.ToString();
		this.BombardingBattleshipsText1940.text = count;
		this.BombardingBattleshipsText1942.text = count;
	}
		
	public void DecrementBombardingBattleships() {
		if (this.bombardingBattleships.Any()) {
			this.bombardingBattleships.RemoveAt(0);
		}
		string count = this.bombardingBattleships.Count.ToString();
		this.BombardingBattleshipsText1940.text = count;
		this.BombardingBattleshipsText1942.text = count;
	}

	// Bombarding Cruisers

	public void IncrementBombardingCruisers() {
		this.bombardingCruisers.Add(new Cruiser());
		string count = this.bombardingCruisers.Count.ToString();
		this.BombardingCruisersText1940.text = count;
		this.BombardingCruisersText1942.text = count;
	}

	public void DecrementBombardingCruisers() {
		if (this.bombardingCruisers.Any()) {
			this.bombardingCruisers.RemoveAt(0);
		}
		string count = this.bombardingCruisers.Count.ToString();
		this.BombardingCruisersText1940.text = count;
		this.BombardingCruisersText1942.text = count;
	}

	// Anti Aircraft Artillery

	public void IncrementAntiAircraftArtillery() {
		this.antiAircraftArtillery.Add(new AntiAircraftArtillery());
		string count = this.antiAircraftArtillery.Count.ToString();
		this.AntiAircraftArtilleryText1940.text = count;
		this.AntiAircraftArtilleryText1942.text = count;
	}

	public void DecrementAntiAircraftArtillery() {
		if (this.antiAircraftArtillery.Any()) {
			this.antiAircraftArtillery.RemoveAt(0);
		}
		string count = this.antiAircraftArtillery.Count.ToString();
		this.AntiAircraftArtilleryText1940.text = count;
		this.AntiAircraftArtilleryText1942.text = count;
	}
		
	// Escort Fighters

	public void IncrementEscortFighters() {
		this.escortFighters.Add(new Fighter());
		string count = this.escortFighters.Count.ToString();
		this.EscortFightersText1940.text = count;
		this.EscortFightersText1942.text = count;
	}

	public void DecrementEscortFighters() {
		if (this.escortFighters.Any()) {
			this.escortFighters.RemoveAt(0);
		}
		string count = this.escortFighters.Count.ToString();
		this.EscortFightersText1940.text = count;
		this.EscortFightersText1942.text = count;
	}

	// Interceptors

	public void IncrementInterceptorFighters1940() {
		this.interceptors.Add(new Fighter());
		string count = this.interceptors.Count.ToString();
		this.InterceptorsText1940.text = count;
		this.InterceptorsText1942.text = count;
	}

	public void DecrementInterceptorFighters1940() {
		if (this.interceptors.Any()) {
			this.interceptors.RemoveAt(0);
		}
		string count = this.interceptors.Count.ToString();
		this.InterceptorsText1940.text = count;
		this.InterceptorsText1942.text = count;
	}

	// Escorted Bombers

	public void IncrementEscortedBombers1940() {
		this.escortedBombers.Add(new Bomber());
		string count = this.escortedBombers.Count.ToString();
		this.EscortedBombersText1940.text = count;
		this.EscortedBombersText1942.text = count;
	}

	public void DecrementEscortedBombers1940() {
		if (this.escortedBombers.Any()) {
			this.escortedBombers.RemoveAt(0);
		}
		string count = this.escortedBombers.Count.ToString();
		this.EscortedBombersText1940.text = count;
		this.EscortedBombersText1942.text = count;
	}

	// Decimals

	public void IncrementDecimals() {
		this.decimals = Mathf.Clamp (this.decimals + 1, 0, 6);
		this.DecimalsText.text = this.decimals.ToString();
	}

	public void DecrementDecimals() {
		this.decimals = Mathf.Clamp (this.decimals - 1, 0, 6);
		this.DecimalsText.text = this.decimals.ToString();
	}
}
