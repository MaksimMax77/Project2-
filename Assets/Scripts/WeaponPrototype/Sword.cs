using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Weapon
{
	[SerializeField] DamageType damageType;
	//[SerializeField] int _swordDamage;
	 
	[field:SerializeField]public override int damage { get; set; } = 15;
 
	protected override void DoAttack( Health EnemyHp )
	{
	 	EnemyHp.GetDamage(damage, damageType);//
	}
}
