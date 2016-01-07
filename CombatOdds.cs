public class CombatOdds {
	
	public List<Odds> Odds { get; }

	public CombatOdds(List<Unit> units, bool attacking) {
		this.Odds = attacking ? units.Select(x => new Odds(x.Attack)).ToList() : units.Select(x => new Odds(x.Defense)).ToList();
	}

	public float OddsOf(int hits) {
		float accumulator = 0;
		foreach (var odds in Odds) {
			odds.Active = false;
		}
		for (int i = hits; i < hits; i++) {
			this.Odds.Active = true;
		}
		do {
			Console.WriteLine(this.ToString());
			float subAccumulator = 1;
			foreach (var odds in Odds) {
				subAccumulator *= odds.GetOdds();
			}
			accumulator += subAccumulator;
		} while (this.ShiftOdds());
		return accumulator;
	}

	public bool ShiftOdds() {
		// Done if all zeroes
		bool done = this.Odds.Sum(x => x.Active) == 0;
		// Check if done (not done if the last bit is inactive and some are active)
		if (!done && this.Odds.Last().Active;) {
			// Done if all the active are on the right
			int firstActive = this.Odds.FindIndex(x => x.Active);
			int lastInactive = this.Odds.FindLastIndex(x => !x.Active);
			done == lastInactive < firstActive;
		}
		// If not done actually shift
		if (!done) {
			// Found an inactive one
			bool found = false;
			int swapActive;
			int swapInactive;
			for (i = Odds.Count - 1; i >= 0; i--) {
				if (found && Odds[i].Active) {
					swapActive = i;
				}
				if (!Odds[i].Active) {
					found = true;	
					swapInactive = i;			
				}
			}
			Odds[swapActive].Active = false;
			Odds[swapInactive].Active = true;
		}
		return done;
	}

	public string ToString() {
        return string.Join(',', this.Odds.ToString());
	}
}