using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
	private CharacterMovement _characterMovement;

    public float xDir;

	bool facing;
	void Awake()
	{
		 // xDir = +1;
		_characterMovement = GetComponent<CharacterMovement>();
	}

	// Update is called once per frame
	void Update()
	{

		Move();
		FacingRightLeft();

	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "RightPlatform")
		{
			//  xDir = -1;
		}
		else if (collision.gameObject.tag == "LeftPlatform")
		{
			//  xDir = +1;
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
	void Move()
	{
		//_characterMovement.vecocity = new Vector2(xDir * Time.deltaTime, 0);
	}

	void FacingRightLeft()
	{
		if (transform.position.x > 0 && !facing)
		{
			Flip();
		}
		else if (transform.position.x < 0 && facing)
		{
			Flip();
		}

	}
	#endregion

}
