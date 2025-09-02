using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
	[SerializeField] Collider m_collider;

	private void Start()
	{
		m_collider.enabled = false;
	}

	public void OnAttack()
	{ 
		m_collider.enabled = true;
	}

	public void OnAttackEnd()
	{
		m_collider.enabled = false;
	}
}
