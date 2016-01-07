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
		for (int i = 0; i < hits; i++) {
			this.Odds[i].Active = true;
		}
		do {
			Debug.Log (this.ToString());
			float subAccumulator = 1;
			foreach (var odds in Odds) {
				subAccumulator *= odds.GetOdds();
			}
			accumulator += subAccumulator;
		} while(!this.ShiftOdds());
		return accumulator;
	}
	
	public bool ShiftOdds() {
		// Done if all zeroes because there is nothing to shift
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
			int swap = -1;
			// The active one furthest right with an inactive one to its right gets shifted to that position
			int lastInactive = this.Odds.FindLastIndex(x => !x.Active);
			int lastPossibleActive = lastInactive - 1;
			int lastActive = this.Odds.FindLastIndex(lastPossibleActive, x => x.Active);
			for (int i = lastActive; i < this.Odds.Count && !found; i++) {
				if (!Odds[i].Active) {
					swap = i;
					found = true;
				}
			}
			this.Odds[lastActive].Active = false;
			this.Odds[swap].Active = true;
		}
		return done;
	}

	public override string ToString() {
		return string.Join(string.Empty, this.Odds.Select(x => x.ToString()).ToArray());
	}
}