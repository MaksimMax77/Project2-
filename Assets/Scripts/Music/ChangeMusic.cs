using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;

 
	public class ChangeMusic : MonoBehaviour
	{
		[SerializeField] MusicManagerComponent battleMusicCompanent;
		[SerializeField] MusicManagerComponent fonMusicCompanent;


		[SerializeField] List<GameObject> enemies;
		RaycastHit2D hit;
		[SerializeField] Health enemyHealth;


		private void Start()
		{
			fonMusicCompanent.enabled = true;
		}

		private void Update()
		{
			ChangeWorldMusic();
		}

		private void ChangeWorldMusic()
		{
		 
			if (enemies.Count != 0)
			{
				battleMusicCompanent.enabled = true;
				fonMusicCompanent.enabled = false;
				foreach (var enemy in enemies)
				{
					var enemyHealth = enemy.GetComponent<Health>();
					if (enemyHealth.death)
					{
						RemoveEnemyFromList(enemy);
					}
				}
			}

			if (enemies.Count == 0)
			{
				battleMusicCompanent.enabled = false;
				fonMusicCompanent.enabled = true;
			}
 
		}

		private void AddEnemyToList(GameObject enemyObj)
		{
			enemies.Add(enemyObj);
		}

		private void RemoveEnemyFromList(GameObject enemyObj)
		{
			enemies.Remove(enemyObj);
		}

		private void OnDrawGizmos()
		{
			Gizmos.color = Color.red;
			Gizmos.DrawLine(transform.position, transform.position + -transform.right * transform.localScale.x * 20);
		}

		private void OnTriggerEnter2D(Collider2D collision)
		{
			if (collision.gameObject.tag == "Enemy")
			{
				var enemy = collision.gameObject;
				AddEnemyToList(enemy);

			}
		}
	}
 
