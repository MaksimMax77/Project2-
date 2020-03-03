using System;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

namespace EnemySystem
{

	public class SuperEnemy : AbstractEnemy
	{
		[SerializeField] GameObject bullet;
		[SerializeField] Transform gunPoint;
		[SerializeField] GameObject Gun;
		[SerializeField] private float dodgeTimer;

		[SerializeField] private bool enemyIsWizard;
		private CharBehavior charBehavior;


		public Bullet currentBullet;

		private void Awake()
		{
			charBehavior = GetComponent<CharBehavior>();
			_collider = GetComponent<Collider2D>();
			randomSpot = Random.Range(0, patrolSpots.Length);
			player = GameObject.FindGameObjectWithTag("Player");
			characterMovement = GetComponent<CharacterMovementModel>();
			playerHealth = player.GetComponent<HealthModel>();
		}

		override public void EnemyAttack()
		{

			var heading = transform.position - player.transform.position;

			if (heading.sqrMagnitude < attackdistanceToPlayer * attackdistanceToPlayer)
			{
				AttackMovement();
			}

			timer += Time.deltaTime;

			if (timer >= 2)
			{
				if (enemyIsWizard) charBehavior.IsAttack = true; //
				timer = 0;
			}

			if (timer <= 0)
			{
				if (!enemyIsWizard) charBehavior.IsAttack = false;
				Shoot();
			}
		}



		public override void EnemyDeath()
		{
			characterMovement.vecocity = new Vector2(0, 0);
			_collider.enabled = false;
			Destroy(Gun);
		}

		#region Shoot

		void Shoot()
		{

			GameObject newBullet = Instantiate(bullet, gunPoint.position, Quaternion.identity);
			if (gunPoint.position.x < transform.position.x)
			{
				newBullet.GetComponent<Rigidbody2D>().velocity = -Gun.transform.right * currentBullet.speed;
			}
			else if (gunPoint.position.x > transform.position.x)
			{
				newBullet.GetComponent<Rigidbody2D>().velocity = Gun.transform.right * currentBullet.speed;
			}
		}

		#endregion

		void AttackMovement()
		{

			if (dodgeTimer <= 0)
			{
				dodgeTimer = 3;
				characterMovement.vecocity = Vector2.right;
				var heading = player.transform.position - transform.position;
				if (heading.sqrMagnitude > attackdistanceToPlayer - 1 * attackdistanceToPlayer - 1 || heading.sqrMagnitude < 2 * 2)
				{
					characterMovement.vecocity = Vector2.left;
				}
			}
			else
			{
				dodgeTimer -= Time.deltaTime;
			}
		}

	}
}
