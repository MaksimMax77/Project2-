using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFacing : MonoBehaviour
{
	private CharacterMovement characterMovement;
	private bool facing;

	void Awake()
    {
		characterMovement = GetComponent<CharacterMovement>();
	}

	void Update()
	{
		FacingRightLeft();
	}
	#region //методы 
	private void Flip()
	{
		facing = !facing;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	void FacingRightLeft()
	{
		if (characterMovement.vecocity.x> 0 && !facing)
		{
			Flip();
		}
		else if (characterMovement.vecocity.x < 0 && facing)
		{
			Flip();
		}
	}
	#endregion
}