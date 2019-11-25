using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{

	class ChaseState : State
	{
		IEnemy currentEnemy;

		public ChaseState(IEnemy currentEnemy)
		{
			this.currentEnemy = currentEnemy;
		}

		public override void OnEnter() { }
		public override void OnExit() { }

		public override void OnUpdate()
		{
			currentEnemy.EnemyChase();
		}

		public bool CanChase()
		{
			if (currentEnemy.ChaseDistance())
			{
				return true;
			}
			return false;
		}
	}
}
