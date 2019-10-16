using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FSM
{
	public class EnemyStateMachine : MonoBehaviour
	{
		
		private StateMachine _stateMachine;
		CharacterMovement _characterMovement;

		 
		[SerializeField] float AttackDictance;
		[SerializeField] int EnemyDamage;
		[SerializeField] GameObject AttackTarget;
        [SerializeField] Transform player;
		[SerializeField] DamageType damageType;
		public bool IsAttack;

		AttackState Attack;
		Health PlayerHp;
		Health EnemyHealth;
		Collider2D _collider;
		void Start()
		{
			_collider = GetComponent<Collider2D>();
			AttackTarget = GameObject.FindGameObjectWithTag("Player");//
			EnemyHealth = GetComponent<Health>();
		   PlayerHp = AttackTarget.GetComponent<Health>();
			_characterMovement = GetComponent<CharacterMovement>();
			var patrol = new PatrolState(transform, player,_characterMovement);
			var Chase = new ChaseState(transform, player, _characterMovement);
			  Attack = new AttackState(  AttackDictance, EnemyDamage, AttackTarget, transform, PlayerHp, _characterMovement,damageType);
			var Death = new DeathState(_characterMovement, EnemyHealth,_collider);
			Attack._IsAttack = IsAttack;
			patrol.Add(new Transition(Chase, () => Chase.CanChase()));
			patrol.Add(new Transition( Death, () => Death.CanDeath())); 

			Chase.Add(new Transition(patrol, () => patrol.CanPatrol()));
			Chase.Add(new Transition(Attack, () => Attack.CanAttack()));
			Chase.Add(new Transition(Death, () => Death.CanDeath()));

			Attack.Add(new Transition(Chase, () => Chase.CanChase()));
			Attack.Add(new Transition(Death, () => Death.CanDeath()));

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