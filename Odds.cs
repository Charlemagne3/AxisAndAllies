public class Odds {
	
	public float Success { get; }
	public float Failure { get; }
	public bool Active { get; set: }

	public Odds(int roll) {
		this.Success = this.roll / 6.0f;
		this.Failure = (6 - this.roll) / 6.0f;
		this.Active = false;
	}

	public float GetOdds() { 
		return this.Active ? this.Success : this.Failure;
	}

	public string ToString() {
		return this.Active ? "1" : "0";
	}
}