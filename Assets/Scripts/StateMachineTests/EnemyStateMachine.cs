using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FSM
{
	public class EnemyStateMachine : MonoBehaviour
	{
		[SerializeField] Transform player;
		private StateMachine _stateMachine;
		CharacterMovement _characterMovement;

		 
		[SerializeField] float AttackDictance;
		[SerializeField] int EnemyDamage;
		[SerializeField] GameObject AttackTarget;

		public bool IsAttack;

		AttackState Attack;
		Health PlayerHp;
		void Start()
		{
			 
		   PlayerHp = AttackTarget.GetComponent<Health>();
			_characterMovement = GetComponent<CharacterMovement>();
			var patrol = new PatrolState(transform, player,_characterMovement);
			var Chase = new ChaseState(transform, player, _characterMovement);
			  Attack = new AttackState(  AttackDictance, EnemyDamage, AttackTarget, transform, PlayerHp, _characterMovement);
			Attack._IsAttack = IsAttack;
			patrol.Add(new Transition(Chase, () => Chase.CanChase()));
			Chase.Add(new Transition(patrol, () => patrol.CanPatrol()));
			Chase.Add(new Transition(Attack, () => Attack.CanAttack()));
			Attack.Add(new Transition(Chase, () => Chase.CanChase()));
			 
			_stateMachine = new StateMachine(patrol);
		}

	 
		void Update()
		{
			_stateMachine.OnUpdate();
			if (Attack._IsAttack)
			{
				IsAttack = true;
				StartCoroutine(AttackFalse());
			}
		 
		}
		IEnumerator AttackFalse()
		{
			yield return new WaitForSeconds(1);
			IsAttack = false;
		}
	}
}