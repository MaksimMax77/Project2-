using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandartEnemy : IEnemy // методы данного класса юзаются в стейтмашине
{
	Health health;
	CharacterMovement characterMovement;
	[SerializeField]Transform[] patrolSpots;
	int randomSpot;
	[SerializeField] int enemyDamage;
	[SerializeField] DamageType damageType;
	[SerializeField] float timer;
	[SerializeField] float patrolTimer;
	GameObject player;
	[SerializeField] float distaceToPla;
	[field: SerializeField] public override bool IsAttack { get; set; }// для аниматора
	Collider2D _collider;
	[SerializeField] float distanceToPlayer;
	 
	private void Awake()
	{
	 
		randomSpot = Random.Range(0, patrolSpots.Length);
		_collider = GetComponent<Collider2D>();
		player = GameObject.FindGameObjectWithTag("Player");
		health = player.GetComponent<Health>();
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
			health.GetDamage(enemyDamage, damageType);
			IsAttack = true;
		}
		else
		{
			 IsAttack = false;
		}
	}

	public override bool AttackDistance()//необходимая дистанция чтоб враг начал бить
	{
		float dist = Vector3.Distance(player.transform.position, transform.position);
		//var heading = transform.position - Player.transform.position;
		if (dist < 5f )
		{
			return true;
		}
		return false;
	}
	public override bool ChaseDistance()//необходимая дистанция чтоб враг начал преследование
	{

		float dist = Vector3.Distance(player.transform.position, transform.position);
		if (dist < 20f  && dist >5f)
			return true;
		return false;
	}

	public override void EnemyPatrol()
	{
		characterMovement.vecocity = patrolSpots[randomSpot].transform.position - transform.position;
		if (Vector2.Distance(transform.position, patrolSpots[randomSpot].position)<0.2f)
		{
			if (patrolTimer <= 0)
			{
				patrolTimer =2;
				randomSpot = Random.Range(0, patrolSpots.Length);
			}
			else
			{
				patrolTimer -= Time.deltaTime;
				characterMovement.vecocity.x = 0;
				characterMovement.vecocity.y = 0;
			}
		 
		}
	}

	public override void EnemyChase()
	{
		characterMovement.vecocity = player.transform.position - transform.position;
		//_characterMovement.speed = 10;
	}

	public override void EnemyDeath()
	{
		characterMovement.vecocity = new Vector2(0, 0);
		_collider.enabled = false;
	}

	public override bool PatrolDistance()//насколько далеко или близко нужно быть чтоб враг патрулировал
	{
		float dist = Vector3.Distance(player.transform.position, transform.position);
		if (dist > 20f )
			return true;
		return false;
	}
}

