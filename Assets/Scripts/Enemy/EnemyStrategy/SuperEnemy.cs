using System;
using UnityEngine;
using Random = UnityEngine.Random;


public class SuperEnemy : AbstractEnemy
{
 
	[SerializeField] GameObject fire;
	RaycastHit2D hit;
	[SerializeField] GameObject bullet;
	[SerializeField] Transform gunPoint;
	[SerializeField] GameObject Gun;
	public  Bullet currentBullet;

	private void Awake()
	{
		 
		_collider = GetComponent<Collider2D>();
		randomSpot = Random.Range(0, patrolSpots.Length);
		player = GameObject.FindGameObjectWithTag("Player");
		characterMovement = GetComponent<CharacterMovement>();
		playerHealth = player.GetComponent<Health>();
	}	

	override public void EnemyAttack()
	{
		 
		var heading = transform.position - player.transform.position;
		if(heading.sqrMagnitude < distanceToPlayer * distanceToPlayer)
		{
          //characterMovement.vecocity = new Vector2(0, 0);
		  AttackMovement();
		}
		timer += Time.deltaTime;
		if (timer >= 2)
		{
			timer = 0;
		}
		if (timer <= 0)
		{
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
		int randomValue = Random.Range(1, 2);
		Vector2 point;
		if (randomValue > 1)
		{
			 point = new Vector2(0, transform.position.y + 5);
		}
		else
		{
			 point=new Vector2(0,transform.position.y-5);
		}
		
		characterMovement.vecocity.y = point.y;

	}
}
