using System.Collections;
using System.Collections.Generic;
using EnemySystem;
using UnityEngine;

namespace FSM
{
	public class EnemyStateMachine : MonoBehaviour
	{
		
		private StateMachine stateMachine;
		CharacterMovementModel characterMovement;
		[SerializeField] AbstractEnemy currentEnemy ;//
		HealthModel enemyHealth;
		Collider2D _collider;
		private GameObject player;

		[SerializeField] string enemyTag;


		void Start()
		{
			player=GameObject.FindGameObjectWithTag(enemyTag);
			_collider = GetComponent<Collider2D>();
			enemyHealth = GetComponent<HealthModel>();
			characterMovement = GetComponent<CharacterMovementModel>();
			var patrol = new PatrolState(transform,  currentEnemy,player);
			var Chase = new ChaseState(currentEnemy,player);
			var  Attack = new AttackState(characterMovement, currentEnemy,player);
			var Death = new DeathState(enemyHealth, currentEnemy,player);

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