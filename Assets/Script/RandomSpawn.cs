using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{


	[SerializeField] GameObject[] randomEnemy;
	[SerializeField] GameObject enemySpawnPos;
	[SerializeField] float timeOut;
	private float elapsedTime;
	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		elapsedTime += Time.deltaTime;
		if(elapsedTime >= timeOut)
		{
			RandomLottery();
			elapsedTime = 0;
		}
	}

	private void RandomLottery()
	{
		DataService ds = new DataService("DataBase.db");

		int randomValue = Random.Range(0, 101);
		if (randomValue < 0)
		{
			Instantiate(randomEnemy[0], enemySpawnPos.transform.position, enemySpawnPos.transform.rotation);

		}
		else if (randomValue < 100)
		{
			Instantiate(randomEnemy[1], enemySpawnPos.transform.position, enemySpawnPos.transform.rotation, enemySpawnPos.transform);

		}
		else if(randomValue < 91)
		{
			Instantiate(randomEnemy[2], enemySpawnPos.transform.position, enemySpawnPos.transform.rotation);

		}
		else
		{
			Instantiate(randomEnemy[3], enemySpawnPos.transform.position, enemySpawnPos.transform.rotation);

		}
	}
}
