using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : AbstractBullet
{
	 
	Health enemyHealth;

	private void Start()
	{
		Destroy(gameObject, 4);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Enemy")
		{
			Destroy(gameObject);
			enemyHealth = collision.GetComponent<Health>();
			enemyHealth.GetDamage(damage, damageType);

			Debug.Log("попал");
		}
	}
}
 