using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealBullet : AbstractBullet
{
	public override void AffectTheCharacter(GameObject enemy)
	{
		var enemyHealth = enemy.GetComponent<HealthModel>();
		enemyHealth.AddHeal(damageOrHeal);
	}
}
