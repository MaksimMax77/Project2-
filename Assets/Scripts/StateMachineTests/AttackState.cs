using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
	class AttackState : State
	{
		CharacterMovement _characterMovement;
		IEnemy _currentEnemy;//
		 
		public AttackState() { }

		public AttackState(CharacterMovement characterMovement, IEnemy currentEnemy)
		{
			_characterMovement = characterMovement;
			_currentEnemy = currentEnemy; // 
		}

		public override void OnEnter() { }

		public override void OnExit() { }

		public override void OnUpdate()
		{
				_currentEnemy.EnemyAttack();
			 
		}

		public bool CanAttack()
		{
			if (_currentEnemy.AttackDistance())
			{
				return true;
			}
			return false;
		}
	}
}