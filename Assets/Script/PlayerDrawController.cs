using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDrawController : MonoBehaviour
{
	[SerializeField] GameObject MainMenuPlayer;

	float waitTime = 0f;

	private string NowScene;
	private void Update()
	{
		if (SceneChangeManager.currentSceneName == "MainMenu")
		{
			waitTime += Time.deltaTime;
			if(waitTime >= 1.0f)
			{
				MainMenuPlayer.SetActive(true);
			}
			
		}
		else
		{
			MainMenuPlayer.SetActive(false);
		}
	}
}
