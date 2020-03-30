using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnemySystem
{
	public class StandartEnemy : AbstractEnemy // методы данного класса юзаются в стейтмашине
	{
		CharBehavior charBehavior; // для аниматора


		private void Awake()
		{
			charBehavior = GetComponent<CharBehavior>();
			randomSpot = Random.Range(0, patrolSpots.Length);
			_collider = GetComponent<Collider2D>();
			player = GameObject.FindGameObjectWithTag("Player");
			playerHealth = player.GetComponent<HealthModel>();
			characterMovement = GetComponent<CharacterMovementModel>();
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
				playerHealth.health -= enemyDamage;
				charBehavior.IsAttack = true;
			}
			else
			{
				charBehavior.IsAttack = false;
			}
		}


		public override void EnemyDeath()
		{
			//characterMovement.vecocity = new Vector2(0, 0);
			//_collider.enabled = false;
			gameObject.SetActive(false);
			Instantiate(enemyDeathBody, transform.position, Quaternion.identity);
		}
	}
}

