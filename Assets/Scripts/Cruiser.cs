public class Cruiser : Unit {

	public Cruiser() : base(3, 3, 2, 12) { }

	public override void Reset() {
		this.Attack = 3;
	}
}