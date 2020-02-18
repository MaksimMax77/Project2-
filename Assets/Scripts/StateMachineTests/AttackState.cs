using System.Collections;
using System.Collections.Generic;
using EnemySystem;
using Sound;
using UnityEngine;

namespace FSM
{
	class AttackState : State
	{
		CharacterMovement characterMovement;
		AbstractEnemy currentEnemy;//
		private ChangeMusic changeMusic; 

		public AttackState() { }

		public AttackState(CharacterMovement characterMovement, AbstractEnemy currentEnemy,GameObject gameObject)
		{
			this.characterMovement = characterMovement;
			this.currentEnemy = currentEnemy;   
			changeMusic=new ChangeMusic();
			changeMusic = gameObject.GetComponent<ChangeMusic>();
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
				changeMusic.isBattleMusic = true;
				return true;
			}

			return false;
		}
	}
}