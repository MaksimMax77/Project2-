using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyAnimator
{
	public class AnimateEnemy : IAnimate
	{
		CharacterMovement movement;
		Health health;
		Animator animator;
		CharBehavior currentCharBehavior;

		public override void AnimateObj()
		{
			if (currentCharBehavior.IsAttack == true)
			{
				animator.SetBool("AttackSide", true);
			}
			else
			{
				animator.SetBool("AttackSide", false);
			}
			if (movement.WalkSide)
			{
				animator.SetBool("WalkSide", true);
			}
			else if (!movement.WalkSide)
			{
				animator.SetBool("WalkSide", false);
			}
			if (health.death)
			{
				animator.SetBool("Die", true);
			}
			if (health.Hit)
			{
				animator.SetBool("Hit", true);
			}
			else if (!health.Hit)
			{
				animator.SetBool("Hit", false);
			}

		}

		public override void AnimatorStart(GameObject gameObject)
		{
			health = gameObject.GetComponent<Health>();
			movement = gameObject.GetComponent<CharacterMovement>();
			animator = gameObject.transform.GetChild(0).GetComponent<Animator>();
			currentCharBehavior = gameObject.GetComponent<CharBehavior>();
		}
	}
}
