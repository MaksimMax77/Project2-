using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
	class PatrolState : State
	{
		 
		 
		private Transform transform;
		 
		CharacterMovement _characterMovement;
		IEnemy _currentEnemy;
		public PatrolState(Transform transform,  IEnemy currentEnemy)
		{
			_currentEnemy = currentEnemy;
			 
			this.transform = transform;
		}
		public override void OnEnter()
		{
			// speed = 0.0F;
		}

		public override void OnUpdate()
		{
			// _characterMovement.vecocity.x = 0;
			 _currentEnemy.EnemyPatrol();
		}

		public override void OnExit()
		{
			// speed = 0.0F;
		}
		public bool CanPatrol()
		{
			if (_currentEnemy.PatrolDistance())
			{
				return true;
			}
			return false;
		}
	}
}
