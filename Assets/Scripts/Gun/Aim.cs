using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 


namespace GunSystem
{
	public class Aim : MonoBehaviour
	{
		[SerializeField] private string enemyTag;
		[SerializeField] private string enemyHealerTag;
		[SerializeField] private List<GameObject> enemies;
		[SerializeField] public GameObject enemyInTarget;
		[SerializeField] private float lookSpeed = 500;
		private Vector3 direction;
		private float angle;
		public float findTargetToAimTimer;
        public bool isAiming;
		[SerializeField] private StartScript startScript;
		[SerializeField] private bool isPlayer;

		private void Awake()
		{
			isAiming = false;

			if (isPlayer)
			{
				enemies = startScript.enemies;
			}

			else
			{
              FindEnemies();
			}
			
		}

		void Update()
		{
			FindTargetToAim();
			AutoAimInTarget();
		}

		private void AutoAimInTarget()
		{

			foreach (var enemy in enemies)
			{
				var headding = enemy.transform.position - transform.position;
				enemyInTarget = enemy;
				if (headding.sqrMagnitude < 20 * 20)
				{
					GunAiming(enemy);
				}
				else
				{
					isAiming = false;
				}
			}
		}

		private void FindTargetToAim()
		{
			findTargetToAimTimer += Time.deltaTime;
			if (findTargetToAimTimer >= 3)
			{
				findTargetToAimTimer = 0;
				enemies.Sort((enemy1, enemy2) =>
				{
					var distance1 = (transform.position - enemy1.transform.position).sqrMagnitude;
					var distance2 = (transform.position - enemy2.transform.position).sqrMagnitude;

					if (distance1 > distance2) return -1;
					else return 1;
				});
			}
		}

		private void GunAiming(GameObject enemy)
		{
			isAiming = true;
			LookAtEnemy(enemy);

			angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
			Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
			transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, Time.deltaTime * lookSpeed);
		}

		private void LookAtEnemy(GameObject enemy)
		{
			if (transform.position.x > enemy.gameObject.transform.position.x)
			{
				direction = transform.position - enemy.gameObject.transform.position;
			}

			else if (transform.position.x < enemy.gameObject.transform.position.x)
			{
				direction = enemy.gameObject.transform.position - transform.position;
			}
		}

		public void FindEnemies()
		{
			var enemiesMassiv = GameObject.FindGameObjectsWithTag(enemyTag);

			foreach (var enemy in enemiesMassiv)
			{
				enemies.Add(enemy);
			}

			if (!string.IsNullOrEmpty(enemyHealerTag))
			{
				var enemiesHealers = GameObject.FindGameObjectsWithTag(enemyHealerTag);

				foreach (var enemy in enemiesHealers)
				{
					enemies.Add(enemy);
				}
			}
		}

	}
}
