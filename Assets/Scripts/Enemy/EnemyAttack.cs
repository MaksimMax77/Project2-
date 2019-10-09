using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
public class EnemyAttack : MonoBehaviour
{
	[SerializeField] GameObject target;
    [SerializeField] float AttackDistance;
	[SerializeField] public int EnemyDamage;
	 public bool IsAttack;//хрень для сробатывания анимаций 

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
	

}
