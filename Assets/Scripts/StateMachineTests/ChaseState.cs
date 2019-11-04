using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{

	class ChaseState : State
	{
		IEnemy _currentEnemy;

		public ChaseState( IEnemy currentEnemy)
		{
			_currentEnemy = currentEnemy;
		}

		public override void OnEnter() { }
		public override void OnExit() { }

		public override void OnUpdate()
		{
			_currentEnemy.EnemyChase();
		}

		public bool CanChase()
		{
			if (_currentEnemy.ChaseDistance())
			{
				return true;
			}
			return false;
		}
	}
}
