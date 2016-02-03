using System.Collections.Generic;
using System.Linq;

public class Battle { 

	public List<Unit> Attackers { get; private set; }
	public List<Unit> Defenders { get; private set; }
	public List<Unit> Bombarders { get; private set; }
	public CombatOdds AttackerOdds { get; private set; }
	public CombatOdds DefenderOdds { get; private set; }
	public CombatOdds BombarderOdds { get; private set; }

	public Battle(List<Unit> a, List<Unit> d, List<Unit> b) {
		this.Attackers = a;
		this.Defenders = d;
		this.Bombarders = b;
		this.ApplyBonuses();
		this.AttackerOdds = new CombatOdds(this.Attackers, true);
		this.DefenderOdds = new CombatOdds(this.Defenders, false);
		this.BombarderOdds = new CombatOdds(this.Bombarders, true);
	}

	public void ApplyBonuses() {
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