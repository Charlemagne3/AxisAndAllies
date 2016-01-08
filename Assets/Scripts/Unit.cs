public abstract class Unit {

	public int Attack { get; set; }
	public int Defense { get; private set; }
	public int Move { get; private set; }
	public int Cost { get; private set; }

	public Unit(int a, int d, int m, int c) {
		this.Attack = a;
		this.Defense = d;
		this.Move = m;
		this.Cost = c;
	}

	public virtual void Reset() { }
}