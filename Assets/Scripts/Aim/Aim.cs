using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
	Vector3 direction;
	// This is what the player is looking at. In this example it is the dinosaur's head.
	public string EnemyTag;
	public float lookSpeed = 500;
	// How fast the rotation happens.
    public	bool canAim;

	 
	float angle;

	private void Awake()
	{
		canAim = false;
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.gameObject.tag == EnemyTag)
		{
			canAim  = true;
			if (transform.position.x > collision.gameObject.transform.position.x)
			{
				direction = transform.position - collision.gameObject.transform.position;
			}
			else if (transform.position.x < collision.gameObject.transform.position.x)
			{
				direction = collision.gameObject.transform.position - transform.position;
			}
			angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
			Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
			transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, Time.deltaTime * lookSpeed);
		}
	}


	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.tag == EnemyTag)
		{
			canAim = false;
		}
	}
}
