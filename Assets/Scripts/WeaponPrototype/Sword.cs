using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Weapon
{
	[SerializeField] DamageType damageType;
	[SerializeField] GameObject BloodObj;
	[SerializeField] Transform BloodPos;
	[field:SerializeField]public override int damage { get; set; } = 15;
	 
	private Health enemyHealth;
	CharBehavior charBehavior;
	private void Awake()
	{
		var Player = GameObject.FindGameObjectWithTag("Player");
		charBehavior = Player.GetComponent<CharBehavior>();
	}


	protected override void DoAttack( Health EnemyHp )
	{
	 	EnemyHp.GetDamage(damage, damageType);//
	}

	 
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (charBehavior.IsAttack)
		{
			if (collision.gameObject.tag == "Enemy")
			{
				enemyHealth = collision.GetComponent<Health>();
				Attack(enemyHealth);
				Instantiate(BloodObj, BloodPos.position, Quaternion.identity);
				Debug.Log("попал");
			}
		}
	}
	 
}
 