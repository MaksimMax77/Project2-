using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class  Bullet : MonoBehaviour
{
	public GameObject bulletPrefab;
	Health enemyHealth;
	public float speed;
	[SerializeField] protected int damage;
	[SerializeField] protected DamageType damageType;
	public GameObject explosion;
	public string enemyTag;

	private void Awake()
	{
		bulletPrefab = this.gameObject;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == enemyTag)
		{
			enemyHealth = collision.GetComponent<Health>();
			enemyHealth.GetDamage(damage, damageType);
			Explosion();
		}
		if (collision.gameObject.tag == "Platform")
		{
			Explosion();
		}
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.gameObject.tag == enemyTag)
		{
			enemyHealth = collision.GetComponent<Health>();
			enemyHealth.GetDamage(damage, damageType);
		}
	}

	void Explosion()
	{
		Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
		GetComponent<PoolObject>().ReturnToPool(); ;
	}
}
