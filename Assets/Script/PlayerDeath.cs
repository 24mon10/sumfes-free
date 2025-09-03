using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
	[SerializeField] GameObject battlePlayer;
	Animator animator;
	// Start is called before the first frame update
	void Start()
    {
		animator = GetComponent<Animator>();
	}

    // Update is called once per frame
    void Update()
    {
        
    }
	public void Death()
	{
		Debug.Log("�Ă΂ꂽ");
		animator.SetBool("Death", false);
		battlePlayer.SetActive(false);
	}

}
