using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
	class AttackState : State
	{
		CharacterMovement characterMovement;
		IEnemy currentEnemy;//
		 
		public AttackState() { }

		public AttackState(CharacterMovement characterMovement, IEnemy currentEnemy)
		{
			this.characterMovement = characterMovement;
			this.currentEnemy = currentEnemy;   
		}

		public override void OnEnter() { }

		public override void OnExit() { }

		public override void OnUpdate()
		{
				 currentEnemy.EnemyAttack();
		}

		public bool CanAttack()
		{
			if (currentEnemy.AttackDistance())
			{
				return true;
			}
			return false;
		}
	}
}