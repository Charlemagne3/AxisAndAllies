public class MechanizedInfantry : Unit {

	public MechanizedInfantry() : base(1, 2, 2, 4) { }

	public override void Reset() {
		this.Attack = 1;
	}
}