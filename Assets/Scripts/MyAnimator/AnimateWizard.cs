using System.Collections;
using System.Collections.Generic;
using MyAnimator;
using UnityEngine;

public class AnimateWizard : IAnimate
{
	private CharBehavior charBehavior;
	private Animator animator;



    public override void AnimatorStart(GameObject gameObject)
    {
	    charBehavior = gameObject.GetComponent<CharBehavior>();
	    animator = gameObject.GetComponent<Animator>();
    }

    public override void AnimateObj()
    {
	    if (charBehavior.IsAttack)
	    {
			animator.SetBool("AttackSide",true);
	    }
	    else
	    {
		    animator.SetBool("AttackSide",false);
	    }
    }
}
