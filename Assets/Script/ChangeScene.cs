using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class ChangeScene : MonoBehaviour
{
	[SerializeField] public string sceneName;

	public void StartSceneChange()
	{
		if (sceneName == SceneChangeManager.currentSceneName) return;

		SceneChangeManager.ChangeScene(sceneName);
		
	}
}
