using System.Collections;
using System.Collections.Generic;
using EnemySystem;
using Sound;
using UnityEngine;

namespace FSM
{
	class AttackState : State
	{
		CharacterMovementModel characterMovement;
		AbstractEnemy currentEnemy;//
		private ChangeMusic changeMusic; 

		public AttackState() { }

		public AttackState(CharacterMovementModel characterMovement, AbstractEnemy currentEnemy,GameObject gameObject)
		{
			this.characterMovement = characterMovement;
			this.currentEnemy = currentEnemy;   
			changeMusic=new ChangeMusic();
			changeMusic = gameObject.GetComponent<ChangeMusic>();
		}

		public override void OnEnter()
		{
			changeMusic.isBattleMusic = true;
		}

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