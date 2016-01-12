using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using System.Linq;

public class Controller : MonoBehaviour {

	// The battle to run odds on
	private Battle battle;

	// Whether or not it is land or naval
	private bool land;

	private List<Infantry> attackerInfantry;
	private List<Artillery> attackerArtillery;
	private List<Tank> attackerTanks;
	private List<Fighter> attackerFighters;
	private List<Bomber> attackerBombers;
	private List<AntiAircraftArtillery> attackerAntiAircraftArtillery;
	private List<Battleship> attackerBattleships;
	private List<Cruiser> attackerCruisers;
	private List<Destroyer> attackerDestroyers;
	private List<Submarine> attackerSubmarines;
	private List<AircraftCarrier> attackerAircraftCarriers;

	private List<Infantry> defenderInfantry;
	private List<Artillery> defenderArtillery;
	private List<Tank> defenderTanks;
	private List<Fighter> defenderFighters;
	private List<Bomber> defenderBombers;
	private List<AntiAircraftArtillery> defenderAntiAircraftArtillery;
	private List<Battleship> defenderBattleships;
	private List<Cruiser> defenderCruisers;
	private List<Destroyer> defenderDestroyers;
	private List<Submarine> defenderSubmarines;
	private List<AircraftCarrier> defenderAircraftCarriers;

	public Text AttackerInfantryText;
	public Text DefenderInfantryText;

	public Text AttackerArtilleryText;
	public Text DefenderArtilleryText;

	public Text AttackerTanksText;
	public Text DefenderTanksText;

	public Text AttackerFightersText;
	public Text DefenderFightersText;

	public Text AttackerBombersText;
	public Text DefenderBombersText;

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

	// Use this for initialization
	void Start () {
		this.attackerInfantry = new List<Infantry>(2);
		this.attackerArtillery = new List<Artillery>(2);
		this.attackerTanks = new List<Tank>(2);
		this.attackerFighters = new List<Fighter>(2);
		this.attackerBombers = new List<Bomber>(2);
		this.attackerAntiAircraftArtillery = new List<AntiAircraftArtillery>(2);
		this.attackerBattleships = new List<Battleship>(2);
		this.attackerCruisers = new List<Cruiser>(2);
		this.attackerDestroyers = new List<Destroyer>(2);
		this.attackerSubmarines = new List<Submarine>(2);
		this.attackerAircraftCarriers = new List<AircraftCarrier>(2);

		this.defenderInfantry = new List<Infantry>(2);
		this.defenderArtillery = new List<Artillery>(2);
		this.defenderTanks = new List<Tank>(2);
		this.defenderFighters = new List<Fighter>(2);
		this.defenderBombers = new List<Bomber>(2);
		this.defenderAntiAircraftArtillery = new List<AntiAircraftArtillery>(2);
		this.defenderBattleships = new List<Battleship>(2);
		this.defenderCruisers = new List<Cruiser>(2);
		this.defenderDestroyers = new List<Destroyer>(2);
		this.defenderSubmarines = new List<Submarine>(2);
		this.defenderAircraftCarriers = new List<AircraftCarrier>(2);

		this.AttackerInfantryText.text = "0";
		this.DefenderInfantryText.text = "0";

		this.AttackerArtilleryText.text = "0";
		this.DefenderArtilleryText.text = "0";

		this.AttackerTanksText.text = "0";
		this.DefenderTanksText.text = "0";

		this.AttackerFightersText.text = "0";
		this.DefenderFightersText.text = "0";

		this.AttackerBombersText.text = "0";
		this.DefenderBombersText.text = "0";

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

		this.land = true;
	}
		
	// Update is called once per frame
	void Update () {
		var scroll = Input.GetAxis("Mouse ScrollWheel");
	}

	public void LandBattle() {
		this.land = true;
	}

	public void SeaBattle() {
		this.land = false;
	}

	public void Battle() {
	    List<Unit> attackers = new List<Unit>(
		    this.attackerInfantry.Count +
			this.attackerArtillery.Count +
			this.attackerTanks.Count +
			this.attackerFighters.Count +
			this.attackerBombers.Count +
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
			this.defenderFighters.Count +
			this.defenderBombers.Count +
			this.defenderAntiAircraftArtillery.Count +
			this.defenderBattleships.Count +
			this.defenderCruisers.Count +
			this.defenderDestroyers.Count +
			this.defenderSubmarines.Count +
			this.defenderAircraftCarriers.Count
		);
		this.battle = new Battle(attackers, defenders);
		for (int i = 0; i <= attackers.Count; i++) {
			Debug.Log("Odds of " + i + " hits: " + this.battle.AttackerOdds.OddsOf(i));
		}
		this.battle.Reset();
	}

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

	public void IncrementAttackerFighters() {
		this.attackerFighters.Add(new Fighter());
		this.AttackerFightersText.text = this.attackerFighters.Count.ToString();
	}

	public void DecrementAttackerFighters() {
		if (this.attackerFighters.Any()) {
			this.attackerFighters.RemoveAt(0);
		}
		this.AttackerFightersText.text = this.attackerFighters.Count.ToString();
	}

	public void IncrementDefenderFighters() {
		this.defenderFighters.Add(new Fighter());
		this.DefenderFightersText.text = this.defenderFighters.Count.ToString();
	}

	public void DecrementDefenderFighters() {
		if (this.defenderFighters.Any()) {
			this.defenderFighters.RemoveAt(0);
		}
		this.DefenderFightersText.text = this.defenderFighters.Count.ToString();
	}

	public void IncrementAttackerBombers() {
		this.attackerBombers.Add(new Bomber());
		this.AttackerBombersText.text = this.attackerBombers.Count.ToString();
	}

	public void DecrementAttackerBombers() {
		if (this.attackerBombers.Any()) {
			this.attackerBombers.RemoveAt(0);
		}
		this.AttackerBombersText.text = this.attackerBombers.Count.ToString();
	}

	public void IncrementDefenderBombers() {
		this.defenderBombers.Add(new Bomber());
		this.DefenderBombersText.text = this.defenderBombers.Count.ToString();
	}

	public void DecrementDefenderBombers() {
		if (this.defenderBombers.Any()) {
			this.defenderBombers.RemoveAt(0);
		}
		this.DefenderBombersText.text = this.defenderBombers.Count.ToString();
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
}
