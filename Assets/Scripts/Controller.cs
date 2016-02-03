using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using System.Linq;

public class Controller : MonoBehaviour {

	// The battle to run odds on
	private Battle battle;

	// Land and Sea containers
	public GameObject Land;
	public GameObject Sea;

	// Main containers
	public GameObject Setup;
	public GameObject Outcome;

	// Attacker units
	private List<Infantry> attackerInfantry;
	private List<Artillery> attackerArtillery;
	private List<Tank> attackerTanks;
	private List<Fighter> attackerFightersLand;
	private List<Fighter> attackerFightersSea;
	private List<Bomber> attackerBombersLand;
	private List<Bomber> attackerBombersSea;
	private List<AntiAircraftArtillery> attackerAntiAircraftArtillery;
	private List<Battleship> attackerBattleships;
	private List<Cruiser> attackerCruisers;
	private List<Destroyer> attackerDestroyers;
	private List<Submarine> attackerSubmarines;
	private List<AircraftCarrier> attackerAircraftCarriers;
	private List<Battleship> bombardingBattleships;
	private List<Cruiser> bombardingCruisers;

	// Defender units
	private List<Infantry> defenderInfantry;
	private List<Artillery> defenderArtillery;
	private List<Tank> defenderTanks;
	private List<Fighter> defenderFightersLand;
	private List<Fighter> defenderFightersSea;
	private List<Bomber> defenderBombersLand;
	private List<Bomber> defenderBombersSea;
	private List<AntiAircraftArtillery> defenderAntiAircraftArtillery;
	private List<Battleship> defenderBattleships;
	private List<Cruiser> defenderCruisers;
	private List<Destroyer> defenderDestroyers;
	private List<Submarine> defenderSubmarines;
	private List<AircraftCarrier> defenderAircraftCarriers;

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

	public Text AttackerAntiAircraftArtilleryText;
	public Text DefenderAntiAircraftArtilleryText;

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

	public Text AttackerOutcomeText;
	public Text DefenderOutcomeText;

	public Text BombardingBattleshipsText;
	public Text BombardingCruisersText;

	// Use this for initialization
	void Start () {
		this.attackerInfantry = new List<Infantry>(2);
		this.attackerArtillery = new List<Artillery>(2);
		this.attackerTanks = new List<Tank>(2);
		this.attackerFightersLand = new List<Fighter>(2);
		this.attackerFightersSea = new List<Fighter>(2);
		this.attackerBombersLand = new List<Bomber>(2);
		this.attackerBombersSea = new List<Bomber>(2);
		this.attackerAntiAircraftArtillery = new List<AntiAircraftArtillery>(2);
		this.attackerBattleships = new List<Battleship>(2);
		this.attackerCruisers = new List<Cruiser>(2);
		this.attackerDestroyers = new List<Destroyer>(2);
		this.attackerSubmarines = new List<Submarine>(2);
		this.attackerAircraftCarriers = new List<AircraftCarrier>(2);
		this.bombardingBattleships = new List<Battleship>(2);
		this.bombardingCruisers = new List<Cruiser>(2);

		this.defenderInfantry = new List<Infantry>(2);
		this.defenderArtillery = new List<Artillery>(2);
		this.defenderTanks = new List<Tank>(2);
		this.defenderFightersLand = new List<Fighter>(2);
		this.defenderFightersSea = new List<Fighter>(2);
		this.defenderBombersLand = new List<Bomber>(2);
		this.defenderBombersSea = new List<Bomber>(2);
		this.defenderAntiAircraftArtillery = new List<AntiAircraftArtillery>(2);
		this.defenderBattleships = new List<Battleship>(2);
		this.defenderCruisers = new List<Cruiser>(2);
		this.defenderDestroyers = new List<Destroyer>(2);
		this.defenderSubmarines = new List<Submarine>(2);
		this.defenderAircraftCarriers = new List<AircraftCarrier>(2);

		// Start with no units
		this.AttackerInfantryText.text = "0";
		this.DefenderInfantryText.text = "0";

		this.AttackerArtilleryText.text = "0";
		this.DefenderArtilleryText.text = "0";

		this.AttackerTanksText.text = "0";
		this.DefenderTanksText.text = "0";

		this.AttackerFightersLandText.text = "0";
		this.DefenderFightersLandText.text = "0";

		this.AttackerFightersSeaText.text = "0";
		this.DefenderFightersSeaText.text = "0";

		this.AttackerBombersLandText.text = "0";
		this.DefenderBombersLandText.text = "0";

		this.AttackerBombersSeaText.text = "0";
		this.DefenderBombersSeaText.text = "0";

		this.AttackerAntiAircraftArtilleryText.text = "0";
		this.DefenderAntiAircraftArtilleryText.text = "0";

		this.AttackerBattleshipsText.text = "0";
		this.DefenderBattleshipsText.text = "0";

		this.AttackerCruisersText.text = "0";
		this.DefenderCruisersText.text = "0";

		this.AttackerDestroyersText.text = "0";
		this.DefenderDestroyersText.text = "0";

		this.AttackerSubmarinesText.text = "0";
		this.DefenderSubmarinesText.text = "0";

		this.AttackerAircraftCarriersText.text = "0";
		this.DefenderAircraftCarriersText.text = "0";

		this.BombardingBattleshipsText.text = "0";
		this.BombardingCruisersText.text = "0";

		this.AttackerOutcomeText.text = "";
		this.DefenderOutcomeText.text = "";
	}
		
	// Update is called once per frame
	void Update () {

	}

	// Set to land mode
	public void LandBattle() {
		this.Land.SetActive(true);
		this.Sea.SetActive(false);
	}

	// Set to sea mode
	public void SeaBattle() {
		this.Land.SetActive(false);
		this.Sea.SetActive(true);
	}

	// Start a battle
	public void Battle() {
	    List<Unit> attackers = new List<Unit>(
		    this.attackerInfantry.Count +
			this.attackerArtillery.Count +
			this.attackerTanks.Count +
			this.attackerFightersLand.Count +
			this.attackerFightersSea.Count +
			this.attackerBombersLand.Count +
			this.attackerBombersSea.Count +
			this.attackerAntiAircraftArtillery.Count +
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
			this.defenderAntiAircraftArtillery.Count +
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

		this.attackerInfantry.ForEach(x => attackers.Add(x));
		this.attackerArtillery.ForEach(x => attackers.Add(x));
		this.attackerTanks.ForEach(x => attackers.Add(x));
		this.attackerFightersLand.ForEach(x => attackers.Add(x));
		this.attackerFightersSea.ForEach(x => attackers.Add(x));
		this.attackerBombersLand.ForEach(x => attackers.Add(x));
		this.attackerBombersSea.ForEach(x => attackers.Add(x));
		this.attackerAntiAircraftArtillery.ForEach(x => attackers.Add(x));
		this.attackerBattleships.ForEach(x => attackers.Add(x));
		this.attackerCruisers.ForEach(x => attackers.Add(x));
		this.attackerDestroyers.ForEach(x => attackers.Add(x));
		this.attackerSubmarines.ForEach(x => attackers.Add(x));
		this.attackerAircraftCarriers.ForEach(x => attackers.Add(x));

		this.defenderInfantry.ForEach(x => defenders.Add(x));
		this.defenderArtillery.ForEach(x => defenders.Add(x));
		this.defenderTanks.ForEach(x => defenders.Add(x));
		this.defenderFightersLand.ForEach(x => defenders.Add(x));
		this.defenderFightersSea.ForEach(x => defenders.Add(x));
		this.defenderBombersLand.ForEach(x => defenders.Add(x));
		this.defenderBombersSea.ForEach(x => defenders.Add(x));
		this.defenderAntiAircraftArtillery.ForEach(x => defenders.Add(x));
		this.defenderBattleships.ForEach(x => defenders.Add(x));
		this.defenderCruisers.ForEach(x => defenders.Add(x));
		this.defenderDestroyers.ForEach(x => defenders.Add(x));
		this.defenderSubmarines.ForEach(x => defenders.Add(x));
		this.defenderAircraftCarriers.ForEach(x => defenders.Add(x));

		this.bombardingBattleships.ForEach (x => bombarders.Add (x));
		this.bombardingCruisers.ForEach (x => bombarders.Add (x));

		this.battle = new Battle(attackers, defenders, bombarders);

		if (bombarders.Any ()) {
			this.AttackerOutcomeText.text += "Odds of bombarding hits:\n";
		}
		for (int i = 0; i <= bombarders.Count; i++) {
			this.AttackerOutcomeText.text += i + " bombarding hits: " + System.Math.Round(this.battle.BombarderOdds.OddsOf(i) * 100) + "%\n";
		}
		this.AttackerOutcomeText.text += "Odds of hits:\n";
		for (int i = 0; i <= attackers.Count; i++) {
			this.AttackerOutcomeText.text += i + " hits: " + System.Math.Round(this.battle.AttackerOdds.OddsOf(i) * 100) + "%\n";
		}
		this.DefenderOutcomeText.text += "Odds of hits:\n";
		for (int i = 0; i <= defenders.Count; i++) {
			this.DefenderOutcomeText.text += "Odds of " + i + " hits: " + System.Math.Round(this.battle.DefenderOdds.OddsOf(i) * 100) + "%\n";
		}

		this.battle.Reset();
		this.Setup.SetActive(false);
		this.Outcome.SetActive(true);
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

	public void IncrementAttackerAntiAircraftArtillery() {
		this.attackerAntiAircraftArtillery.Add(new AntiAircraftArtillery());
		this.AttackerAntiAircraftArtilleryText.text = this.attackerAntiAircraftArtillery.Count.ToString();
	}

	public void DecrementAttackerAntiAircraftArtillery() {
		if (this.attackerAntiAircraftArtillery.Any()) {
			this.attackerAntiAircraftArtillery.RemoveAt(0);
		}
		this.AttackerAntiAircraftArtilleryText.text = this.attackerAntiAircraftArtillery.Count.ToString();
	}

	public void IncrementDefenderAntiAircraftArtillery() {
		this.defenderAntiAircraftArtillery.Add(new AntiAircraftArtillery());
		this.DefenderAntiAircraftArtilleryText.text = this.defenderAntiAircraftArtillery.Count.ToString();
	}

	public void DecrementDefenderAntiAircraftArtillery() {
		if (this.defenderAntiAircraftArtillery.Any()) {
			this.defenderAntiAircraftArtillery.RemoveAt(0);
		}
		this.DefenderAntiAircraftArtilleryText.text = this.defenderAntiAircraftArtillery.Count.ToString();
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

	public void IncrementBombarderBattleships() {
		this.bombardingBattleships.Add(new Battleship());
		this.BombardingBattleshipsText.text = this.bombardingBattleships.Count.ToString();
	}

	public void DecrementBombarderBattleships() {
		if (this.bombardingBattleships.Any()) {
			this.bombardingBattleships.RemoveAt(0);
		}
		this.BombardingBattleshipsText.text = this.bombardingBattleships.Count.ToString();
	}

	public void IncrementBombarderCruisers() {
		this.bombardingCruisers.Add(new Cruiser());
		this.BombardingCruisersText.text = this.bombardingCruisers.Count.ToString();
	}

	public void DecrementBombarderCruisers() {
		if (this.bombardingCruisers.Any()) {
			this.bombardingCruisers.RemoveAt(0);
		}
		this.BombardingCruisersText.text = this.bombardingCruisers.Count.ToString();
	}
}
