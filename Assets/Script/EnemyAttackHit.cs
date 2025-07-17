using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class EnemyAttackHit : MonoBehaviour
{
	EnemyController controller;
	
    // Start is called before the first frame update
    void Start()
    {
		controller = GetComponentInParent<EnemyController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnTriggerEnter(Collider other)
	{
		if(other.TryGetComponent<BattlePlayerAction>(out var bp))
		{
			bp.DamageHit(controller.strength);
		}
	}
}
