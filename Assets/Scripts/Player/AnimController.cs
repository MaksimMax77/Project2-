using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimController : MonoBehaviour
{
	Animator animator;
	CharacterMovement movement;
	CharBehavior charBehavior;
 
	Health health;
	[SerializeField] GameObject animatorObj;
	 
    void Awake()
    {
		 
		health = GetComponent<Health>();
		animator = animatorObj.GetComponent<Animator>();
		movement = GetComponent<CharacterMovement>();
		charBehavior = GetComponent<CharBehavior>();
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
		 
		if (charBehavior.IsAttack)
		{
			animator.SetBool("AttackSide", true);
		}
		else if (!charBehavior.IsAttack)
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
