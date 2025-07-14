using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
	[SerializeField] Collider m_collider;

	public void OnAttack()
	{ 
		m_collider.enabled = true;
	}

	public void OnAttackEnd()
	{
		m_collider.enabled = false;
	}
}
