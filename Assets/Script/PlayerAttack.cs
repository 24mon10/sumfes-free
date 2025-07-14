using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
	[SerializeField] Collider m_collider;
    public void AttackStart()
	{
		m_collider.enabled = true;
	}

	public void AttackEnd()
	{
		m_collider.enabled = false;
	}
}
