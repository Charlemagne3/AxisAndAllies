public class Odds {
	
	public float Success { get; private set; }
	public float Failure { get; private set; }
	public bool Active { get; set; }

	public Odds(int roll) {
		this.Success = roll / 6.0f;
		this.Failure = (6 - roll) / 6.0f;
		this.Active = false;
	}

	public float GetOdds() { 
		return this.Active ? this.Success : this.Failure;
	}

	public override string ToString() {
		return this.Active ? "1" : "0";
	}
}