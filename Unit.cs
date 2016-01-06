public class Unit {

	public int Attack { get; }
	public int Defense { get; }
	public int Move { get; }
	public int Cost { get; }

	public Unit(int a, int d, int m, int c) {
		this.Attack = a;
		this.Defense = d;
		this.Move = m;
		this.Cost = c;
	}
}