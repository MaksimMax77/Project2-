using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
	class PatrolState : State
	{
		 
		 
		private Transform transform;
		Transform _player;
		CharacterMovement _characterMovement;
		public PatrolState(Transform transform, Transform player, CharacterMovement characterMovement)
		{
			_characterMovement = characterMovement;
			this._player = player;
			this.transform = transform;
		}
		public override void OnEnter()
		{
			// speed = 0.0F;
		}

		public override void OnUpdate()
		{
			_characterMovement.vecocity.x = 0;
			 
			 
		}

		public override void OnExit()
		{
			// speed = 0.0F;
		}
		public bool CanPatrol()
		{
			var heading = transform.position - _player.position;
			if (heading.sqrMagnitude > 15 * 15)
				return true;
			return false;
		}
	}
}
