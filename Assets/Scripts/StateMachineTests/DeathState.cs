using System.Collections;
using System.Collections.Generic;
using EnemySystem;
using Sound;
using UnityEngine;

namespace FSM
{

	public class DeathState : State
	{
		 
		private HealthModel health;
		private AbstractEnemy currentEnemy;

		private ChangeMusic changeMusic;

		public DeathState(HealthModel health , AbstractEnemy currentEnemy,GameObject gameObject)
		{
			this.health = health;
			this.currentEnemy =currentEnemy;
			changeMusic=new ChangeMusic();
			changeMusic = gameObject.GetComponent<ChangeMusic>();
		}

		public override void OnEnter()
		{
			 
		}

		public override void OnExit()
		{
			
		}

		public override void OnUpdate()
		{
			currentEnemy.EnemyDeath();
		}
		public bool CanDeath()
		{
			if (health.death == true)
			{
				changeMusic.isBattleMusic = false;
				return true;
			}
			return false;
		}

	}

}

