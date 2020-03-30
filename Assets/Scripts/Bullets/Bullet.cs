using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : AbstractBullet
{
	[SerializeField] private DamageType damageType;

	public override void AffectTheCharacter(GameObject enemy)
	{
		var enemyHealth = enemy.GetComponent<HealthModel>();
		enemyHealth.GetDamage(damageOrHeal, damageType);
	}
}
