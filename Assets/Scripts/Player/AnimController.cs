using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimController : MonoBehaviour
{
	Animator animator;
	CharacterMovement movement;
	PlayerController player;
	Health health;
	[SerializeField] GameObject animatorObj;
	 
    void Awake()
    {
		 
		health = GetComponent<Health>();
		animator = animatorObj.GetComponent<Animator>();
		movement = GetComponent<CharacterMovement>();
		player = GetComponent<PlayerController>();
    }

    
    void Update()
    {
		if (movement.WalkSide )
		{
			animator.SetBool("WalkSide", true);
		}
		else if(!movement.WalkSide )
		{
			animator.SetBool("WalkSide", false);
		}
		 
		if (player.IsAttack)
		{
			animator.SetBool("AttackSide", true);
		}
		else if (!player.IsAttack)
		{
				animator.SetBool("AttackSide", false);	 
		}
		if (health.death)
		{
			animator.SetBool("Die", true);
		}
		else if (!health.death)
		{
			animator.SetBool("Die", false);
		}
		if (health.Hit == true)
		{
			animator.SetBool("Hit", true);
		}
		 else if (health.Hit ==false)
		 {
	 	 	animator.SetBool("Hit", false);
	 	 }

	 
	}
}
