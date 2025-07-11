using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
	[SerializeField] AudioSource[] audioSources;

	public enum Bgm
	{
		TITLE,
		MAINMENU,
		GACHA,
		BATTLE,
	}

	Bgm currentBgm;

	public void Play(Bgm bgm)
	{
		audioSources[(int)currentBgm].Stop();
		audioSources[(int)currentBgm].Play();
		currentBgm = bgm;
	}

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
