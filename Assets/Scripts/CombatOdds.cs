using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class CombatOdds {
	
	public List<Odds> Odds { get; private set; }
	
	public CombatOdds(List<Unit> units, bool attacking) {
		this.Odds = attacking ? units.Select(x => new Odds(x.Attack)).ToList() : units.Select(x => new Odds(x.Defense)).ToList();
	}
	
	public float OddsOf(int hits) {
		float accumulator = 0;
		foreach (var odds in Odds) {
			odds.Active = false;
		}
		for (int i = hits; i < hits; i++) {
			this.Odds[i].Active = true;
		}
		Debug.Log (this.ToString());
		do {
			float subAccumulator = 1;
			foreach (var odds in Odds) {
				subAccumulator *= odds.GetOdds();
			}
			accumulator += subAccumulator;
		} while(this.ShiftOdds());
		return accumulator;
	}
	
	public bool ShiftOdds() {
		// Done if all zeroes
		bool done = this.Odds.All(x => !x.Active);
		// Check if done (not done if the last bit is inactive and some are active)
		if (!done && this.Odds.Last().Active) {
			// Done if all the active are on the right
			int firstActive = this.Odds.FindIndex(x => x.Active);
			int lastInactive = this.Odds.FindLastIndex(x => !x.Active);
			done = lastInactive < firstActive;
		}
		// If not done actually shift
		if (!done) {
			// Found an inactive one
			bool found = false;
			int swapActive = -1;
			int swapInactive = -1;
			for (int i = Odds.Count - 1; i >= 0; i--) {
				if (found && Odds[i].Active) {
					swapActive = i;
				}
				if (!Odds[i].Active) {
					found = true;	
					swapInactive = i;			
				}
			}
			this.Odds[swapActive].Active = false;
			this.Odds[swapInactive].Active = true;
		}
		return done;
	}
	
	public override string ToString() {
		return string.Join(string.Empty, this.Odds.Select(x => x.ToString()).ToArray());
	}
}