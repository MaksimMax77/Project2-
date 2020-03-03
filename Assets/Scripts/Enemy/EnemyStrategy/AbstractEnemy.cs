using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace EnemySystem
{

	public abstract class AbstractEnemy : MonoBehaviour
	{
		protected HealthModel playerHealth;
		protected CharacterMovementModel characterMovement;
		protected int randomSpot;
		protected GameObject player;
		protected Collider2D _collider;
		[SerializeField] protected Transform[] patrolSpots;
		[SerializeField] protected int enemyDamage;
		[SerializeField] protected DamageType damageType;
		[SerializeField] protected float timer;
		[SerializeField] protected float patrolTimer;
		[SerializeField] protected float attackdistanceToPlayer;
		[SerializeField] protected float chaseDistanceToPlayer;


		abstract public void EnemyAttack();

		abstract public void EnemyDeath();

		public void EnemyPatrol()
		{
			if (patrolSpots != null)
			{
				characterMovement.vecocity = patrolSpots[randomSpot].transform.position - transform.position;
				if (Vector2.Distance(transform.position, patrolSpots[randomSpot].position) < 0.2f)
				{
					if (patrolTimer <= 0)
					{
						patrolTimer = 2;
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
		}


		public void EnemyChase()
		{
			characterMovement.vecocity = player.transform.position - transform.position; //метод приследования игрока
		}



		public bool AttackDistance()
		{
			float dist =
				Vector3.Distance(player.transform.position, transform.position); // c какой дистанции начинается атака

			if (dist < attackdistanceToPlayer)
			{

				return true;

			}

			return false;
		}


		public bool ChaseDistance()
		{
			float dist =
				Vector3.Distance(player.transform.position,
					transform.position); // с какой дистанции начинается приследование 
			if (dist < chaseDistanceToPlayer && dist > attackdistanceToPlayer)
			{

				return true;
			}

			return false;
		}


		public bool PatrolDistance()
		{
			float dist =
				Vector3.Distance(player.transform.position,
					transform.position); //насколько далеко или близко нужно быть чтоб враг патрулировал
			if (dist > chaseDistanceToPlayer)
			{

				return true;
			}

			return false;
		}

	}
}