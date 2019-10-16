using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
	class AttackState : State
	{
		 public float _timer;
		float _AttackDistance;
		int _EnemyDamage;
		GameObject _target;
		private Transform _transform;
		Health _PlayerHp;
		CharacterMovement _characterMovement;
		DamageType _damageType;
		public bool _IsAttack;

		EnemyStateMachine stateMachine = new EnemyStateMachine();
		public AttackState() { }
		public AttackState(  float AtacckDistance, int enemyDamage, GameObject target, Transform transform, Health PlayerHp, CharacterMovement characterMovement,DamageType damageType)
		{
			_damageType = damageType;
		   _AttackDistance = AtacckDistance;
			_EnemyDamage = enemyDamage;
			_target = target;
			_transform = transform;
			_PlayerHp = PlayerHp;
			_characterMovement = characterMovement;

		}

		public override void OnEnter() { }

		public override void OnExit() { }

		public override void OnUpdate()
		{
			_timer += Time.deltaTime;
			if (_timer >=2)
			{
				 _timer = 0;
				_PlayerHp.GetDamage(_EnemyDamage,_damageType);
				_IsAttack = true;
			}
			else
			{
				_IsAttack = false;
			}
		 
			 
			_characterMovement.vecocity = new Vector2(0, 0);
			
		}

		public bool CanAttack()
		{
			var heading = _transform.position - _target.transform.position;
			if (heading.sqrMagnitude < 4  * 4)
			{
				return true;
			}
			return false;
		}
	}
}