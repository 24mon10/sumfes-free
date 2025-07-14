using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static UnityEditor.PlayerSettings;

public class EnemyController : MonoBehaviour
{
	//[SerializeField] GameObject player;
	//[SerializeField] Slider slider;
	//[SerializeField] AudioClip[] m_clips;
	//[SerializeField] GameObject effect;
	[SerializeField] GameObject target;
	[SerializeField] float myPosition;
	private NavMeshAgent agent;

	[SerializeField] int Hp;
	private bool Down = false;

	Animator animator;

	// Start is called before the first frame update
	void Start()
    {
		target = GameObject.FindGameObjectWithTag("Player");
		agent = GetComponent<NavMeshAgent>();
		animator = GetComponent<Animator>();
		
	}

    // Update is called once per frame
    void FixedUpdate()
    {
		/* ターゲットのポジションを取得 */
		Vector3 targetPos = target.transform.position;

		/* プレイヤーのポジションを取得 */
		Vector3 myPos = this.gameObject.transform.position;
		myPosition = Vector3.Distance(targetPos, myPos);

        if(target)
		{
			agent.destination = target.transform.position;
		}

		if(myPosition <= agent.stoppingDistance)
		{
			animator.SetTrigger("Attack");
		}
		else
		{
			animator.SetTrigger("Idle");
		}
    }
}
