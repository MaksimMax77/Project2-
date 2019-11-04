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
	private PlayerController playerController;
	private void Awake()
	{
		var Player = GameObject.FindGameObjectWithTag("Player");
		playerController = Player.GetComponent<PlayerController>();
	}


	protected override void DoAttack( Health EnemyHp )
	{
	 	EnemyHp.GetDamage(damage, damageType);//
	}

	 
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (playerController.PlayerAttack)
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
 