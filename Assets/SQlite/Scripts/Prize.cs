using SQLite4Unity3d;

public class Prize
{
	[PrimaryKey, AutoIncrement]
	public int id { get; set; }
	public string name { get; set; }
	//ƒŒƒA“x
	public string rarity { get; set; }
	//o‚â‚·‚³
	public float emissionRate { get; set; }

	public override string ToString()
	{
		return string.Format("[Person: Id={0}, Name={1}, Rarity={3}, emissionRate={4}]", id, name, rarity, emissionRate);
	}
}
