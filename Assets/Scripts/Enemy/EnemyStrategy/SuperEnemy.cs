using UnityEngine;

public class SuperEnemy : IEnemy
{
	Health health;
	[SerializeField] int enemyDamage;
	[SerializeField] float distaceToPla;
	[SerializeField] Transform gun;
	[SerializeField] GameObject fire;
	[SerializeField] float timer;
	[SerializeField] DamageType damageType;
	GameObject player;
	CharacterMovement characterMovement;
	int randomSpot;
	[SerializeField] Transform[] patrolSpots;
	[SerializeField] float patrolTimer;
	 
	CharacterMovement plaCharMove;
	RaycastHit2D hit;
	Collider2D _collider;
	[SerializeField] GameObject bullet;
	[SerializeField] Transform gunPoint;
	[SerializeField] GameObject Gun;
	public AbstractBullet currentBullet;
	private void Awake()
	{
		_collider = GetComponent<Collider2D>();
		randomSpot = Random.Range(0, patrolSpots.Length);
		player = GameObject.FindGameObjectWithTag("Player");
		characterMovement = GetComponent<CharacterMovement>();
		health = player.GetComponent<Health>();
		plaCharMove = player.GetComponent<CharacterMovement>();
		 
	}


	public SuperEnemy(Health health)
	{
		this.health = health;
	}

	public override bool IsAttack { get; set; }

	public override bool AttackDistance()
	{
		var heading = transform.position - player.transform.position;
		if (heading.sqrMagnitude < distaceToPla * distaceToPla)
		{
			return true;
		}
		return false;
	}

	public override bool PatrolDistance()
	{
		var heading = transform.position - player.transform.position;
		if (heading.sqrMagnitude > 25 * 25)
			return true;
		return false;
	}

	public override bool ChaseDistance()
	{
		var heading = transform.position - player.transform.position;
		if (heading.sqrMagnitude < 20 * 20 && heading.sqrMagnitude > 15*15)
			return true;
		return false;
	}

	override public void EnemyAttack()
	{
		 
		var heading = transform.position - player.transform.position;
		if(heading.sqrMagnitude < distaceToPla * distaceToPla)
		{
          characterMovement.vecocity = new Vector2(0, 0);
		}
		timer += Time.deltaTime;
		if (timer >= 2)
		{
			timer = 0;
		}
		if (timer <= 0)
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
	}

	public override void EnemyChase()
	{
		characterMovement.vecocity = player.transform.position - transform.position;
	}

	public override void EnemyDeath()
	{
		characterMovement.vecocity = new Vector2(0, 0);
		_collider.enabled = false;
		Destroy(Gun);
	}

	public override void EnemyPatrol()
	{
		characterMovement.vecocity = patrolSpots[randomSpot].transform.position - transform.position;
		if (Vector2.Distance(transform.position, patrolSpots[randomSpot].position) < 0.2f)
		{
			if (patrolTimer <= 0)
			{
				patrolTimer = 2;
				randomSpot = Random.Range(0, patrolSpots.Length);
			}
			else
			{
				patrolTimer -= Time.deltaTime;
				characterMovement.vecocity.x = 0;
				characterMovement.vecocity.y = 0;
			}
		}
	}
}
