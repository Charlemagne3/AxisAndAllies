using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Battle { 

	public List<Unit> Attackers { get; private set; }
	public List<Unit> Defenders { get; private set; }
	public List<Unit> Bombarders { get; private set; }
	public List<AntiAircraftArtillery> AntiAircraftArtillery { get; private set; }
	public List<Unit> Raiders { get; private set; }
	public List<Unit> Interceptors { get; private set; }
	public CombatOdds AttackerOdds { get; private set; }
	public CombatOdds DefenderOdds { get; private set; }
	public CombatOdds BombarderOdds { get; private set; }
	public AntiAircraftOdds AntiAircraftOdds { get; private set; }
	public CombatOdds RaiderOdds { get; private set; }
	public CombatOdds InterceptorOdds { get; private set; }
	public StrategicOdds StrategicOdds { get; private set; }
	public IndustrialComplexOdds IndustrialComplexOdds { get; private set; }

	public Battle(List<Unit> a, List<Unit> d, List<Unit> b, List<AntiAircraftArtillery> aaa, List<Unit> raiders, List<Unit> interceptors) {
		this.Attackers = a;
		this.Defenders = d;
		this.Bombarders = b;
		this.AntiAircraftArtillery = aaa;
		this.Raiders = raiders;
		this.Interceptors = interceptors;
		this.applyBonuses();
		foreach (var ship in this.Bombarders) {
			ship.Attack = ship.Attack - 1;
		}
		foreach (var raider in this.Raiders) {
			raider.Attack = 1;
		}
		foreach (Fighter interceptor in this.Interceptors) {
			interceptor.Defense = 2;
		}
		this.AttackerOdds = new CombatOdds(this.Attackers, true);
		this.DefenderOdds = new CombatOdds(this.Defenders, false);
		this.BombarderOdds = new CombatOdds(this.Bombarders, true);
		this.AntiAircraftOdds = new AntiAircraftOdds(this.AntiAircraftArtillery, this.Attackers.Count(x => x is Fighter || x is Bomber));
		this.RaiderOdds = new CombatOdds(this.Raiders, true);
		this.InterceptorOdds = new CombatOdds(this.Interceptors, false);
		int bombers = this.Raiders.Count (x => x is Bomber);
		this.StrategicOdds = new StrategicOdds(bombers);
		this.IndustrialComplexOdds = new IndustrialComplexOdds(bombers);
	}

	private void applyBonuses() {
		// Apply artillery bonus to infantry
		var artillery = this.Attackers.Count(x => x is Artillery);
		foreach (var unit in Attackers) {
			if (artillery == 0) {
				break;
			}
			else if (unit is Infantry) {
				artillery--;
				unit.Attack++;
			}
		}
	}
}
