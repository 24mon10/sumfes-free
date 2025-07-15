using SQLite4Unity3d;

public class Player
{

	[PrimaryKey, AutoIncrement]
	public int level { get; set; }
	public int n_exp {  get; set; }
	public int hp {  get; set; }
	public int mp { get; set; }
	public int strength { get; set; }
	public int guard { get; set; }

	public override string ToString()
	{
		return string.Format("[Player: Level={0}, n_Exp={2}, Hp={3}, Mp={4}," +
			"Strength{5}, Guard{6},]", level, n_exp, hp, mp, strength, guard);
	}
}
