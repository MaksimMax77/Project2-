using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
	[SerializeField] GameObject target;
    [SerializeField] float AttackDistance;
	[SerializeField] int EnemyDamage;
	 public bool IsAttack;

	Health PlayerHp;

	public float timeBetweenAttacks;
	public float timer;

	private void Awake()
	{
		PlayerHp = target.GetComponent<Health>();
		 
	}

	void Update()
    {
		timer += Time.deltaTime;
		if (timer >= timeBetweenAttacks)
		{
           Attack();
		 
		}
		if(timer <= timeBetweenAttacks)
		{
			 
		}
		
    }


	void Attack()
	{
		timer = 0;
		float distance = Vector3.Distance(target.transform.position, transform.position);
		if (distance < AttackDistance)
		{
			IsAttack = true;	 
			PlayerHp.GetDamage(EnemyDamage);
		}
		else
		{
			IsAttack = false;
		}
	}

	IEnumerator enumeratorAttack()
	{
		yield return new WaitForSeconds(3);
		timer = 0f;
	}
	
}
