public class Battle { 

	public List<Unit> Attackers { get; }
	public List<Unit> Defenders { get; }

	public Battle(List<Unit> a, List<Unit> d) {
		this.Attackers = a;
		this.Defenders = d;
	}

	public List<float> AttackerOdds() {
		float denominator = Attackers.Count;
		int numerator = Attackers.Aggregate(x, y => x * y);
		return numerator / denominator;
	}

	public List<float> DefenderOdds() {
		float denominator = Defenders.Count;
		int numerator = Defenders.Aggregate(x, y => x * y);		
		return numerator / denominator;
	}
}