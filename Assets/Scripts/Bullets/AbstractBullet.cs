using ObjPool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractBullet: MonoBehaviour
{
	public GameObject bulletPrefab;
	public float speed;
	public int damageOrHeal;
	public GameObject explosion;
	public string enemyTag;
	public string enemyHealerTag;
	public bool bulletIsSpawner;


	public virtual void AffectTheCharacter(GameObject enemy)
	{
		print("базовая реализация");
	}

	public virtual void SpawnCharacter()
	{
		print("базовая реализация");
	} //два метода надо переопределить в конкретных классах 


	private void Awake()
	{
		bulletPrefab = this.gameObject;
	}

	private void Update()
	{
		if (bulletIsSpawner)
		{
			SpawnCharacter();
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (!bulletIsSpawner)
		{
			if (!string.IsNullOrEmpty(enemyHealerTag))
			{

				if (collision.gameObject.tag == enemyHealerTag)
				{
					AffectTheCharacter(collision.gameObject);
					Explosion();
				}

			}

			if (collision.gameObject.tag == enemyTag)
			{
				AffectTheCharacter(collision.gameObject);
				Explosion();
			}

			if (collision.gameObject.tag == "Platform")
			{
				Explosion();
			}
		}
	}


	public void Explosion()
	{
		GameObject.Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
		gameObject.GetComponent<PoolObject>().ReturnToPool();  
	}
}
