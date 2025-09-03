using SQLite4Unity3d;

public class Prize
{
	[PrimaryKey, AutoIncrement]
	public int id { get; set; }
	public string name { get; set; }
	//ƒŒƒA“x
	public string rarity { get; set; }
	//UŒ‚—Í‚Ì•â³’l
	public int correctionValue { get; set; }

	public override string ToString()
	{
		return string.Format("[Prize: Id={0}, Name={1}, Rarity={2}," +
			"CorrectionValue={3}", id, name, rarity, correctionValue);
	}
}
