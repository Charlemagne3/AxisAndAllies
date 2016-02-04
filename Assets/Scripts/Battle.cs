using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Battle { 

	public List<Unit> Attackers { get; private set; }
	public List<Unit> Defenders { get; private set; }
	public List<Unit> Bombarders { get; private set; }
	public List<AntiAircraftArtillery> AntiAircraftArtillery { get; private set; }
	public CombatOdds AttackerOdds { get; private set; }
	public CombatOdds DefenderOdds { get; private set; }
	public CombatOdds BombarderOdds { get; private set; }
	public AntiAircraftOdds AntiAircraftOdds { get; private set; }

	public Battle(List<Unit> a, List<Unit> d, List<Unit> b, List<AntiAircraftArtillery> aaa) {
		this.Attackers = a;
		this.Defenders = d;
		this.Bombarders = b;
		this.AntiAircraftArtillery = aaa;
		this.applyBonuses();
		foreach (var ship in this.Bombarders) {
			ship.Attack = ship.Attack - 1;
		}
		this.AttackerOdds = new CombatOdds(this.Attackers, true);
		this.DefenderOdds = new CombatOdds(this.Defenders, false);
		this.BombarderOdds = new CombatOdds(this.Bombarders, true);
		this.AntiAircraftOdds = new AntiAircraftOdds(this.AntiAircraftArtillery, this.Attackers.Count(x => x is Fighter || x is Bomber));
	}

	private void applyBonuses() {
		// Apply artillery bonus to infantry
		var artillery = this.Attackers.Count(x => x is Artillery);
		foreach (var unit in Attackers) {
			if (artillery == 0) {
				break;
			}
			else if (unit is Infantry) {
				artillery--;
				unit.Attack++;
			}
		}
	}

	public void Reset() {
		this.Attackers.ForEach(x => x.Reset());
		this.Defenders.ForEach(x => x.Reset());
		this.Bombarders.ForEach(x => x.Reset());
		this.AttackerOdds = new CombatOdds(this.Attackers, true);
		this.DefenderOdds = new CombatOdds(this.Defenders, false);
		this.BombarderOdds = new CombatOdds(this.Bombarders, true);
	}
}