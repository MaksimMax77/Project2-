using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
	class PatrolState : State
	{
		 
		 
		private Transform transform;
		 
		CharacterMovement characterMovement;
		AbstractEnemy currentEnemy;
		public PatrolState(Transform transform, AbstractEnemy currentEnemy)
		{
			this.currentEnemy = currentEnemy;
			this.transform = transform;
		}
		public override void OnEnter()
		{
			// speed = 0.0F;
		}

		public override void OnUpdate()
		{
			 currentEnemy.EnemyPatrol();
		}

		public override void OnExit()
		{
			// speed = 0.0F;
		}
		public bool CanPatrol()
		{
			if (currentEnemy.PatrolDistance())
			{
				return true;
			}
			return false;
		}
	}
}
