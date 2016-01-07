public class Battle { 

	public List<Unit> Attackers { get; }
	public List<Unit> Defenders { get; }
	public CombatOdds AttackerOdds { get; }
	public CombatOdds DefenderOdds { get; }

	public Battle(List<Unit> a, List<Unit> d) {
		this.Attackers = a;
		this.Defenders = d;
		this.AttackerOdds = new CombatOdds(Attackers, true);
		this.DefenderOdds = new CombatOdds(Defenders, false);
	}
}