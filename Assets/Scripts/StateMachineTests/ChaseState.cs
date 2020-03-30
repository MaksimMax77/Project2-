using System.Collections;
using System.Collections.Generic;
using EnemySystem;
using Sound;
using UnityEngine;

namespace FSM
{

	class ChaseState : State
	{
		AbstractEnemy currentEnemy;
		private ChangeMusic changeMusic;

		public ChaseState(AbstractEnemy currentEnemy,GameObject gameObject)
		{
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
