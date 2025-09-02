using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateInfo : MonoBehaviour
{
	[SerializeField] public int level;
	[SerializeField] public int n_exp;
	[SerializeField] public int hp;
	[SerializeField] public int mp;
	[SerializeField] public int strength;
	[SerializeField] public int guard;

	DataService ds = new DataService("DataBase.db");

	public int f_hp;
	private Player player;

	// Start is called before the first frame update
	void Start()
    {
		player = ds.GetPlayer(1);
		level = player.level;
		n_exp = player.n_exp;
		hp = player.hp;
		mp = player.mp;
		strength = player.strength;
		guard = player.guard;

		f_hp = player.hp;
	}

    // Update is called once per frame
    void Update()
    {
        
    }

	public void DrawNextStatus(int nlv)
	{
		player = ds.GetPlayer(nlv);
		level = player.level;
		n_exp = player.n_exp;
		hp = player.hp;
		mp = player.mp;
		strength = player.strength;
		guard = player.guard;

		f_hp = player.hp;
	}
}
