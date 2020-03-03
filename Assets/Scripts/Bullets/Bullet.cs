
using UnityEngine;
using ObjPool;

public class  Bullet : MonoBehaviour
{
	public GameObject bulletPrefab;
	HealthModel enemyHealth;
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
			//enemyHealth = collision.GetComponent<Health>();
			DamageTheCharacter(collision);
			//enemyHealth.GetDamage(damage, damageType);
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
			enemyHealth = collision.GetComponent<HealthModel>();
			enemyHealth.GetDamage(damage, damageType);
		}
	}

	void DamageTheCharacter(Collider2D collision)
	{
		var enemyHealth = collision.GetComponent<HealthModel>();
		enemyHealth.GetDamage(damage, damageType);
	}

	void Explosion()
	{
		Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
		GetComponent<PoolObject>().ReturnToPool(); ;
	}
}
