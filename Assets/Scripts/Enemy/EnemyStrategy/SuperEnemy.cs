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
	Rigidbody2D _rigidbody;
	CharacterMovement PlaCharMove;
	RaycastHit2D _hit;
	Collider2D _collider;

	private void Awake()
	{
		_collider = GetComponent<Collider2D>();
		 RandomSpot = Random.Range(0, patrolSpots.Length);
		Player = GameObject.FindGameObjectWithTag("Player");
		_characterMovement = GetComponent<CharacterMovement>();
		_health = Player.GetComponent<Health>();
		PlaCharMove = Player.GetComponent<CharacterMovement>();
		_rigidbody = Player.GetComponent<Rigidbody2D>();
	}


	public SuperEnemy(Health health)
	{
		_health = health;
	}

	public override bool _IsAttack { get; set; }

	public override bool AttackDistance()
	{
		var heading = transform.position - Player.transform.position;
		if (heading.sqrMagnitude < 8 * 8)
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
		if (heading.sqrMagnitude < 20 * 20 && heading.sqrMagnitude > 12*12)
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
			Physics2D.queriesStartInColliders = false;
			_hit = Physics2D.Raycast(transform.position, Vector2.left * transform.localScale.x, 25);
			if (_hit.collider != null && _hit.collider.tag == "Player")
			{
				_health.GetDamage(EnemyDamage, damageType);
				if (transform.position.x < Player.transform.position.x)
				{
					Player.transform.position += Vector3.right * 2;
				}
				else if (transform.position.x > Player.transform.position.x)
				{
					Player.transform.position += Vector3.left * 2;
				}
			}
             Instantiate(fire, gun.position, Quaternion.identity);	 
		}
	}

	public override void EnemyChase()
	{
		_characterMovement.vecocity = Player.transform.position - transform.position;
		_characterMovement.speed = 10;
	}

	public override void EnemyDeath()
	{
		_characterMovement.vecocity = new Vector2(0, 0);
		_collider.enabled = false;
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
			_characterMovement.speed = 5;
		}
	}
	private void OnDrawGizmos()
	{
		Gizmos.color = Color.blue;
		Gizmos.DrawLine(transform.position, transform.position + Vector3.left * transform.localScale.x *25);
	}
}
