public class Odds {
	
	public double Success { get; private set; }
	public double Failure { get; private set; }
	public bool Active { get; set; }

	public Odds(int roll) {
		this.Success = roll / 6.0;
		this.Failure = (6 - roll) / 6.0;
		this.Active = false;
	}

	public double GetOdds() { 
		return this.Active ? this.Success : this.Failure;
	}

	public override string ToString() {
		return this.Active ? "1" : "0";
	}
}