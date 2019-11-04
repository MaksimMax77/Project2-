using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{

	public class DeathState : State
	{
		 
		private Health _health;
		IEnemy _currentEnemy;
		public DeathState( Health health ,IEnemy  currentEnemy )
		{
			_health = health;
			_currentEnemy=currentEnemy; ;
		}
		public override void OnEnter()
		{
			 
		}

		public override void OnExit()
		{
			
		}

		public override void OnUpdate()
		{
			_currentEnemy.EnemyDeath();
		}
		public bool CanDeath()
		{
			if (_health.death == true)
			{
				return true;
			}
			return false;
		}

	}

}

