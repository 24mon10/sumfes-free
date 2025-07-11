using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasDraw : MonoBehaviour
{
	[SerializeField] GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneChangeManager.currentSceneName == "BattleScene")
		{
			canvas.SetActive(false);
		}
		else
		{
			canvas.SetActive(true);
		}
    }
}
