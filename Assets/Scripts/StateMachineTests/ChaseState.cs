using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{

	class ChaseState : State
	{
		private Transform transform;
		float MaxRange;
		Transform _player;
		CharacterMovement _characterMovement;


		public ChaseState(Transform transform, Transform Player, CharacterMovement characterMovement)
		{
			this._characterMovement = characterMovement;
			this.transform = transform;
			this._player = Player;
		}

		public override void OnEnter() { }
		public override void OnExit() { }

		public override void OnUpdate()
		{
			_characterMovement.vecocity = _player.position - transform.position;
		}

		public bool CanChase()
		{
			var heading = transform.position - _player.position;
			if (heading.sqrMagnitude < 15 * 15&& heading.sqrMagnitude>6)
				return true;
			return false;
		}
	}
}
