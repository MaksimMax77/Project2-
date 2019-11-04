using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFacing : MonoBehaviour
{
	private CharacterMovement _characterMovement;
	public bool facing;

	void Awake()
    {
		_characterMovement = GetComponent<CharacterMovement>();
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
		if (_characterMovement.vecocity.x > 0 && !facing)
		{
			Flip();
		}
		else if (_characterMovement.vecocity.x < 0 && facing)
		{
			Flip();
		}
	}
	#endregion
}