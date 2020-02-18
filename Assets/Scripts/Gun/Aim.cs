using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GunSystem
{
	public class Aim : MonoBehaviour
	{
		[SerializeField] GameObject player;
		[SerializeField] private GameObject[] Enemies;
		[SerializeField] private string enemyTag;
		[SerializeField] public GameObject enemyInTarget;
		public bool isAiming;
		private float minDistance = 20;
		private float distance = Mathf.Infinity;
		[SerializeField] private float lookSpeed = 500;
		private Vector3 direction;
		private float angle;


		private void Awake()
		{
			isAiming = false;
			Enemies = GameObject.FindGameObjectsWithTag(enemyTag);
		}

		void Update()
		{
			FindTargetToAim();
			AutoAimInTarget();
		}


		void AutoAimInTarget()
		{
			if (enemyInTarget != null)
			{
				var headding = enemyInTarget.transform.position - transform.position;
				if (headding.sqrMagnitude < 15 * 15)
				{
					GunAiming(enemyInTarget);
				}
				else
				{
					isAiming = false;
				}
			}
		}

		void FindTargetToAim()
		{

			for (int i = 0; i < Enemies.Length; i++)
			{
				var headding = Enemies[i].transform.position - transform.position;
				float curDistance = headding.sqrMagnitude;
				if (curDistance < minDistance * minDistance)
				{
					enemyInTarget = Enemies[i];
					distance = curDistance;
				}
			}
		}

		void GunAiming(GameObject enemy)
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

	}
}
