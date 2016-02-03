public class Battleship : Unit {

	public Battleship() : base(4, 4, 2, 20) { }

	public override void Reset() {
		this.Attack = 4;
	}
}