using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FSM
{
	public class EnemyStateMachine : MonoBehaviour
	{
		
		private StateMachine stateMachine;
		CharacterMovement characterMovement;
		[SerializeField] IEnemy currentEnemy ;//
		Health enemyHealth;
		Collider2D _collider;

		void Start()
		{
			_collider = GetComponent<Collider2D>();
			enemyHealth = GetComponent<Health>();
			characterMovement = GetComponent<CharacterMovement>();
			var patrol = new PatrolState(transform,  currentEnemy);
			var Chase = new ChaseState(currentEnemy);
			var  Attack = new AttackState(characterMovement, currentEnemy);
			var Death = new DeathState(enemyHealth, currentEnemy);

			patrol.Add(new Transition(Chase, () => Chase.CanChase()));
			patrol.Add(new Transition( Death, () => Death.CanDeath())); 

			Chase.Add(new Transition(patrol, () => patrol.CanPatrol()));
			Chase.Add(new Transition(Attack, () => Attack.CanAttack()));
			Chase.Add(new Transition(Death, () => Death.CanDeath()));

			Attack.Add(new Transition(Chase, () => Chase.CanChase()));
			Attack.Add(new Transition(Death, () => Death.CanDeath()));

			stateMachine = new StateMachine(patrol);
		}

	 
		void Update()
		{
			stateMachine.OnUpdate();
		}
	}
}