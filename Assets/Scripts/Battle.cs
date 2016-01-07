using System.Collections.Generic;

public class Battle { 

	public List<Unit> Attackers { get; private set; }
	public List<Unit> Defenders { get; private set; }
	public CombatOdds AttackerOdds { get; private set; }
	public CombatOdds DefenderOdds { get; private set; }

	public Battle(List<Unit> a, List<Unit> d) {
		this.Attackers = a;
		this.Defenders = d;
		this.AttackerOdds = new CombatOdds(Attackers, true);
		this.DefenderOdds = new CombatOdds(Defenders, false);
	}
}