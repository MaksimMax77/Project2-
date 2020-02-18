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

		private RaycastHit2D hit;

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
			DistanceToAim();
			AutoAimInTarget();
		}

		#region // метит цель, которая в прицеле красным кругом, если в нее попадает луч из оружия

		void RedCircleOffOn(Collider2D collision)
		{

			Physics2D.queriesStartInColliders = false; //
			//hit = Physics2D.Raycast(transform.position, -transform.right * transform.localScale.x, 12);
			if (player != null)
			{
				if (transform.position.x < player.transform.position.x)
				{
					hit = Physics2D.Raycast(transform.position, -transform.right * transform.localScale.x, 12);
				}

				if (transform.position.x > player.transform.position.x)
				{
					hit = Physics2D.Raycast(transform.position, transform.right * transform.localScale.x, 12);
				}
			}


			var circle = hit.collider.gameObject.GetComponent<RedCircleOnnOff>();

			if (hit.collider != null && hit.collider.tag == enemyTag)
			{
				var redCircle = hit.collider.GetComponent<RedCircleOnnOff>();
				if (redCircle != null)
				{
					redCircle.RedCircleOn = true;
				}
			}

			if (hit.collider == null)
			{
				if (circle != null)
				{
					circle.RedCircleOn = false;
				}
			}
		}

		#endregion

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

		void DistanceToAim()
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
			if (transform.position.x > enemy.gameObject.transform.position.x)
			{
				direction = transform.position - enemy.gameObject.transform.position;
			}

			else if (transform.position.x < enemy.gameObject.transform.position.x)
			{
				direction = enemy.gameObject.transform.position - transform.position;
			}

			angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
			Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
			transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, Time.deltaTime * lookSpeed);
		}


		private void OnDrawGizmos()
		{
			Gizmos.color = Color.white;
			if (player != null)
			{
				if (transform.position.x < player.transform.position.x)
				{
					Gizmos.DrawLine(transform.position,
						transform.position + -transform.right * transform.localScale.x * 12);
				}

				if (transform.position.x > player.transform.position.x)
				{
					Gizmos.DrawLine(transform.position,
						transform.position + transform.right * transform.localScale.x * 12);
				}
			}
		}


	}
}
