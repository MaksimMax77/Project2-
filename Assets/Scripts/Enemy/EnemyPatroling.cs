using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatroling : MonoBehaviour
{
	private CharacterMovement _characterMovement;
	EnemyAi enemyAi;

	bool facing;
	void Awake()
	{
		enemyAi = GetComponent<EnemyAi>();
	  _characterMovement = GetComponent<CharacterMovement>();
	}

	// Update is called once per frame
	void Update()
	{
		FacingRightLeft();
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (enemyAi.patrol == true)
		{
			_characterMovement.vecocity.x = 1;
			if (collision.gameObject.tag == "RightPlatform")
			{
				Debug.Log("правая");
				_characterMovement.vecocity.x = -1;
			}

			else if (collision.gameObject.tag == "LeftPlatform")
			{
				Debug.Log("левая");
				_characterMovement.vecocity.x = 1;
			}
		}
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
