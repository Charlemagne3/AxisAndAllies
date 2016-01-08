public class Infantry : Unit {

	public Infantry() : base(1, 2, 1, 3) { }

	public override void Reset() {
		this.Attack = 1;
	}
}