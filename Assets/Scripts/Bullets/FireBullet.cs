using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : AbstractBullet
{
	 
	Health enemyHealth;
	[SerializeField]GameObject explosion;

	void Start()
    {
		Destroy(gameObject, 4);
		 speed = 15;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Enemy")
		{
			enemyHealth = collision.GetComponent<Health>();
			enemyHealth.GetDamage(damage, damageType);
			Explosion(); 
 		}
		if(collision.gameObject.tag == "Platform")
		{
			Explosion();
		}
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Enemy")
		{
			enemyHealth = collision.GetComponent<Health>();
			enemyHealth.GetDamage(damage, damageType);
		}
	}

	void Explosion()
	{
		Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
}
