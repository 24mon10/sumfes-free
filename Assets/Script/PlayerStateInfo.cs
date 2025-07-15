using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateInfo : MonoBehaviour
{
	[SerializeField] int level;
	[SerializeField] int n_exp;
	[SerializeField] int hp;
	[SerializeField] int mp;
	[SerializeField] int strength;
	[SerializeField] int guard;

	DataService ds = new DataService("DataBase.db");

	public Player player;

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
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
