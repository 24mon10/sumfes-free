using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using static UnityEditor.PlayerSettings;

public class EnemyController : MonoBehaviour
{
	//[SerializeField] GameObject player;
	//[SerializeField] Slider slider;
	//[SerializeField] AudioClip[] m_clips;
	//[SerializeField] GameObject effect;
	
	[SerializeField] GameObject target;
	[SerializeField] float myPosition;
    [SerializeField] int dbNumber;
	private float waitTime;
	private NavMeshAgent agent;
	private int damage = 0;
	private bool Down = false;
	private Enemies enemies;
	Animator animator;

	[SerializeField] GameObject playerStatus;
	private PlayerStateInfo playerStateInfo;

	DataService ds = new DataService("DataBase.db");
	[SerializeField] int id;
	[SerializeField] string m_name;
	[SerializeField] int hp;
	[SerializeField] public int strength;
	[SerializeField] int guard;
	[SerializeField] int expg;
	[SerializeField] Slider slider;


	// Start is called before the first frame update
	void Start()
    {
		target = GameObject.FindGameObjectWithTag("Player");
		playerStatus = GameObject.FindGameObjectWithTag("PlayerStatus");
		playerStateInfo = playerStatus.GetComponent<PlayerStateInfo>();
		agent = GetComponent<NavMeshAgent>();
		animator = GetComponent<Animator>();
		enemies = ds.GetEnemiesData(dbNumber);
		m_name = enemies.name;
		hp = enemies.hp;
		strength = enemies.strength;
		guard = enemies.guard;
		expg = enemies.expg;
		
	}

    // Update is called once per frame
    void FixedUpdate()
    {
		slider.value = hp;
		if(hp <= 0)
		{
			animator.SetTrigger("Die");
		}

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
			waitTime += Time.deltaTime;
			
			if (waitTime >= 5)
			{
				animator.SetTrigger("Attack");
				waitTime = 0;
			}
		}
		else
		{
			animator.SetTrigger("Move");
		}

		if(agent.speed == 0)
		{
			animator.SetTrigger("Idle");
		}
    }

	public void HitAttack()
	{
		damage = playerStateInfo.strength - guard;
		if (damage < 0) return;
		else
		{
			hp -= damage;
		}

	}

	public void Die() 
	{
		Destroy(gameObject);
	}
}
