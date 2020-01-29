using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyAnimator
{

	public class AnimatePlayer : IAnimate
	{
		Animator animator;
		CharacterMovement movement;
		Health health;


		public override void AnimateObj()
		{
			if (movement.WalkSide)
			{
				animator.SetBool("WalkSide", true);
			}
			else if (!movement.WalkSide)
			{
				animator.SetBool("WalkSide", false);
			}
			if (health.Hit == true)
			{
				animator.SetBool("Hit", true);
			}
			else if (health.Hit == false)
			{
				animator.SetBool("Hit", false);
			}
		}

		public override void AnimatorStart(GameObject gameObject)
		{
			movement = gameObject.GetComponent<CharacterMovement>();
			animator = gameObject.GetComponent<Animator>();
			health = gameObject.GetComponent<Health>();
		}

	}
}
