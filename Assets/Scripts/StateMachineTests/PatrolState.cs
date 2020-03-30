using System.Collections;
using System.Collections.Generic;
using EnemySystem;
using Sound;
using UnityEngine;

namespace FSM
{
	class PatrolState : State
	{

		private Transform transform;
		 
		CharacterMovementModel characterMovement;
		AbstractEnemy currentEnemy;
		private ChangeMusic changeMusic;
		 
		public PatrolState(Transform transform, AbstractEnemy currentEnemy,GameObject gameObject)
		{
			this.currentEnemy = currentEnemy;
			this.transform = transform;
			changeMusic=gameObject.GetComponent<ChangeMusic>();
		}

	 
		public override void OnEnter()
		{
			changeMusic.isBattleMusic = false;
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
