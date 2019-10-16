using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
	public abstract int damage { get; set; }
	 
	public void Attack(Health enemyHealth)
	{
		DoAttack( enemyHealth );
	}
	protected abstract void DoAttack(Health EnemyHp );
 
}
 
