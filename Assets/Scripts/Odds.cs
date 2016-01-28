public class Odds {
	
	public int Success { get; private set; }
	public int Failure { get; private set; }
	public bool Active { get; set; }

	public Odds(int roll) {
		this.Success = roll;
		this.Failure = (6 - roll);
		this.Active = false;
	}

	public int GetOdds() { 
		return this.Active ? this.Success : this.Failure;
	}

	public override string ToString() {
		return this.Active ? "1" : "0";
	}
}