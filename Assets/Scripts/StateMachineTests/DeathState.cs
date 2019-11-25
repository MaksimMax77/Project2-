﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{

	public class DeathState : State
	{
		 
		private Health health;
		IEnemy currentEnemy;
		public DeathState(Health health ,IEnemy currentEnemy)
		{
			this.health = health;
			this.currentEnemy =currentEnemy; 
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
				return true;
			}
			return false;
		}

	}

}

