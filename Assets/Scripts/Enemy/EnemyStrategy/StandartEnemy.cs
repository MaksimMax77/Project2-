using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandartEnemy : AbstractEnemy // методы данного класса юзаются в стейтмашине
{
	[field: SerializeField] public override bool IsAttack { get; set; }// для аниматора
	 

	private void Awake()
	{
		randomSpot = Random.Range(0, patrolSpots.Length);
		_collider = GetComponent<Collider2D>();
		player = GameObject.FindGameObjectWithTag("Player");
		playerHealth = player.GetComponent<Health>();
		characterMovement = GetComponent<CharacterMovement>();
	}

	 

	override public void EnemyAttack()
	{
		characterMovement.vecocity = new Vector2(0, 0);
		timer += Time.deltaTime;
		if (timer >= 2)
		{
			timer = 0;
		}
		if (timer <= 0)
		{
			playerHealth.GetDamage(enemyDamage, damageType);
			IsAttack = true;
		}
		else
		{
			 IsAttack = false;
		}
	}
 

	public override void EnemyDeath()
	{
		characterMovement.vecocity = new Vector2(0, 0);
		_collider.enabled = false;
	}
 
}

