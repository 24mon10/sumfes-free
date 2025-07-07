using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDrawController : MonoBehaviour
{
	[SerializeField] GameObject MainMenuPlayer;

	private string NowScene;
	private void Update()
	{
		if (SceneChangeManager.currentSceneName == "MainManu")
		{
			MainMenuPlayer.SetActive(true);
		}
		else
		{
			MainMenuPlayer.SetActive(false);
		}
	}
}
