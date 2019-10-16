using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{

	public class DeathState : State
	{
		private CharacterMovement _characterMovement;
		private Health _health;
		Collider2D _collider;
		public DeathState(CharacterMovement characterMovement,Health health , Collider2D collider)
		{
			_characterMovement = characterMovement;
			_health = health;
			_collider = collider;
		}
		public override void OnEnter()
		{
			 
		}

		public override void OnExit()
		{
			
		}

		public override void OnUpdate()
		{
			 _characterMovement.vecocity = new Vector2(0, 0);
			_collider.enabled = false;
		}
		public bool CanDeath()
		{
			if (_health.death == true)
			{
				return true;
			}
			return false;
		}

	}

}

