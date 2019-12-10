using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpulsAbility2 : AbstractAbility,IAbbility2
{
	public int damage;
	public DamageType damageType;
	private RaycastHit2D hit;
	ButtonManager buttonManager;

	void Awake()
	{
		buttonManager = GetComponent<ButtonManager>();
	}

	void Update()
	{
		AbilityTimer();
		if (Input.GetKeyDown(buttonManager.useAbilityButton2))
		{
			UseAbility();
		}
	}

	public void UseAbility()
	{

		if (mana.mana >= neadMana && abilityUse == false)
		{
			abilityUse = true;
			hit = Physics2D.Raycast( transform.position, Vector2.left *  transform.localScale.x, 10);
			if (hit.collider != null)
			{
				PushEnemy();
			}
			mana.TakeMana(neadMana); 
		}
	}

	void PushEnemy()
	{
		var enemy = hit.collider.gameObject;
		var _enemyHealth = enemy.GetComponent<Health>();
		_enemyHealth.GetDamage(damage, damageType);
		if (transform.position.x < enemy.transform.position.x)
		{
			enemy.transform.position += Vector3.right * 10;
		}
		else if (transform.position.x > enemy.transform.position.x)
		{
			enemy.transform.position += Vector3.left * 10;
		}
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.cyan;
		Gizmos.DrawLine(transform.position, Vector2.left * transform.localScale.x * 10);
	}
}
