using UnityEngine;

public class SuperEnemy : IEnemy
{
	Health _health;
	[SerializeField] int EnemyDamage;
	[SerializeField] float distaceToPla;
	[SerializeField] Transform gun;
	[SerializeField] GameObject fire;
	[SerializeField] float _timer;
	[SerializeField] DamageType damageType;
	GameObject Player;
	CharacterMovement _characterMovement;
	int RandomSpot;
	[SerializeField] Transform[] patrolSpots;
	[SerializeField] float patrolTimer;
	 
	CharacterMovement PlaCharMove;
	RaycastHit2D _hit;
	Collider2D _collider;
	[SerializeField] GameObject bullet;
	[SerializeField] Transform gunPoint;
	[SerializeField] GameObject Gun;
	public AbstractBullet currentBullet;
	private void Awake()
	{
		_collider = GetComponent<Collider2D>();
		 RandomSpot = Random.Range(0, patrolSpots.Length);
		Player = GameObject.FindGameObjectWithTag("Player");
		_characterMovement = GetComponent<CharacterMovement>();
		_health = Player.GetComponent<Health>();
		PlaCharMove = Player.GetComponent<CharacterMovement>();
		 
	}


	public SuperEnemy(Health health)
	{
		_health = health;
	}

	public override bool _IsAttack { get; set; }

	public override bool AttackDistance()
	{
		var heading = transform.position - Player.transform.position;
		if (heading.sqrMagnitude < distaceToPla * distaceToPla)
		{
			return true;
		}
		return false;
	}

	public override bool PatrolDistance()
	{
		var heading = transform.position - Player.transform.position;
		if (heading.sqrMagnitude > 25 * 25)
			return true;
		return false;
	}

	public override bool ChaseDistance()
	{
		var heading = transform.position - Player.transform.position;
		if (heading.sqrMagnitude < 20 * 20 && heading.sqrMagnitude > 15*15)
			return true;
		return false;
	}

	override public void EnemyAttack()
	{
		 
		var heading = transform.position - Player.transform.position;
		if(heading.sqrMagnitude < distaceToPla * distaceToPla)
		{
          _characterMovement.vecocity = new Vector2(0, 0);
		}
		_timer += Time.deltaTime;
		if (_timer >= 2)
		{
			_timer = 0;
		}
		if (_timer <= 0)
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
		_characterMovement.vecocity = Player.transform.position - transform.position;
	}

	public override void EnemyDeath()
	{
		_characterMovement.vecocity = new Vector2(0, 0);
		_collider.enabled = false;
		Destroy(Gun);
	}

	public override void EnemyPatrol()
	{
		_characterMovement.vecocity = patrolSpots[RandomSpot].transform.position - transform.position;
		if (Vector2.Distance(transform.position, patrolSpots[RandomSpot].position) < 0.2f)
		{
			if (patrolTimer <= 0)
			{
				patrolTimer = 2;
				RandomSpot = Random.Range(0, patrolSpots.Length);
			}
			else
			{
				patrolTimer -= Time.deltaTime;
				_characterMovement.vecocity.x = 0;
				_characterMovement.vecocity.y = 0;
			}
		}
	}
}
