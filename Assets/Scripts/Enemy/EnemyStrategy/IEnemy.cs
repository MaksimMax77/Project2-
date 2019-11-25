using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IEnemy :MonoBehaviour
{


	abstract public void EnemyAttack();
	abstract public bool IsAttack { get; set; }
	abstract public void EnemyPatrol();
	abstract public void EnemyChase();
	abstract public void EnemyDeath();
	abstract public bool AttackDistance();// c какой дистанции начинается атака
	abstract public bool ChaseDistance();// с какой дистанции начинается приследование 
	abstract public bool PatrolDistance();//насколько далеко или близко нужно быть чтоб враг патрулировал
	 
}
