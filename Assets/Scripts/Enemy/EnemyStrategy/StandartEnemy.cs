using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandartEnemy : IEnemy // методы данного класса юзаются в стейтмашине
{
	Health _health;
	CharacterMovement _characterMovement;
	[SerializeField]Transform[] patrolSpots;
	int RandomSpot;
	[SerializeField] int EnemyDamage;
	[SerializeField] DamageType damageType;
	[SerializeField] float _timer;
	[SerializeField] float patrolTimer;
	GameObject Player;
	[SerializeField] float distaceToPla = 4.5f;
	[field: SerializeField] public override bool _IsAttack { get; set; }// для аниматора
	Collider2D _collider;
	 
	private void Awake()
	{
	 
		RandomSpot = Random.Range(0, patrolSpots.Length);
		_collider = GetComponent<Collider2D>();
		Player = GameObject.FindGameObjectWithTag("Player");
		_health = Player.GetComponent<Health>();
		_characterMovement = GetComponent<CharacterMovement>();
	}

	public StandartEnemy(Health health)
	{
		_health = health;
	}

	override public void EnemyAttack()
	{
		_characterMovement.vecocity = new Vector2(0, 0);
		_timer += Time.deltaTime;
		if (_timer >= 2)
		{
			_timer = 0;
		}
		if (_timer <= 0)
		{
			_health.GetDamage(EnemyDamage, damageType);
			_IsAttack = true;
		}
		else
		{
			_IsAttack = false;
		}
	}

	public override bool AttackDistance()//необходимая дистанция чтоб враг начал бить
	{
		var heading = transform.position - Player.transform.position;
		if (heading.sqrMagnitude < distaceToPla * distaceToPla)
		{
			return true;
		}
		return false;
	}
	public override bool ChaseDistance()//необходимая дистанция чтоб враг начал преследование
	{
		var heading = transform.position - Player.transform.position;
		if (heading.sqrMagnitude < 15 * 15 && heading.sqrMagnitude > 6)
			return true;
		return false;
	}

	public override void EnemyPatrol()
	{
		_characterMovement.vecocity = patrolSpots[RandomSpot].transform.position - transform.position;
		if (Vector2.Distance(transform.position, patrolSpots[RandomSpot].position)<0.2f)
		{
			if (patrolTimer <= 0)
			{
				patrolTimer =2;
				RandomSpot = Random.Range(0, patrolSpots.Length);
			}
			else
			{
				patrolTimer -= Time.deltaTime;
				_characterMovement.vecocity.x = 0;
				_characterMovement.vecocity.y = 0;
			}
			_characterMovement.speed = 5;
		}
	}

	public override void EnemyChase()
	{
		_characterMovement.vecocity = Player.transform.position - transform.position;
		//_characterMovement.speed = 10;
	}

	public override void EnemyDeath()
	{
		_characterMovement.vecocity = new Vector2(0, 0);
		_collider.enabled = false;
	}

	public override bool PatrolDistance()//насколько далеко или близко нужно быть чтоб враг патрулировал
	{
		var heading = transform.position - Player.transform.position;
		if (heading.sqrMagnitude > 15 * 15)
			return true;
		return false;
	}
}

