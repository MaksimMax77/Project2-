using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
	[SerializeField] GameObject player;
	Vector3 direction;
	// This is what the player is looking at. In this example it is the dinosaur's head.
	[SerializeField] string enemyTag;
	[SerializeField] float lookSpeed = 500;
	// How fast the rotation happens.
    public	bool isAiming;
	RaycastHit2D hit;

	float angle;

	private void Awake()
	{
		isAiming = false;
	}


	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.gameObject.tag == enemyTag)   							
		{
			GunAiming(collision);
			RedCircleOffOn(collision);
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.tag == enemyTag)
		{
			isAiming = false;
		}
	}

	#region //отвечает за автоприцел пушки
	void GunAiming(Collider2D collision)
	{
		isAiming = true;
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
	#endregion

	#region // метит цель, которая в прицеле красным кругом, если в нее попадает луч из оружия
	void RedCircleOffOn(Collider2D collision)
	{

		Physics2D.queriesStartInColliders = false;//
		//hit = Physics2D.Raycast(transform.position, -transform.right * transform.localScale.x, 12);
		if (player != null)
		{
			if (transform.position.x < player.transform.position.x)
			{
				hit = Physics2D.Raycast(transform.position, -transform.right * transform.localScale.x, 12);
			}
			if (transform.position.x > player.transform.position.x)
			{
				hit = Physics2D.Raycast(transform.position, transform.right * transform.localScale.x, 12);
			}
		}


		var circle = collision.gameObject.GetComponent<RedCircleOnnOff>();

		if (hit.collider != null && hit.collider.tag == enemyTag)
		{
			var redCircle = hit.collider.GetComponent<RedCircleOnnOff>();
			if (redCircle != null)
			{
                  redCircle.RedCircleOn = true;
			}	
		}

		if (hit.collider == null)
		{
			if (circle != null)
			{
				circle.RedCircleOn = false;
			}
		}
	}
	#endregion

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.black;
		//Gizmos.DrawLine(transform.position, transform.position + -transform.right * transform.localScale.x * 12);
		if (player != null)
		{
			if (transform.position.x < player.transform.position.x)
			{
				Gizmos.DrawLine(transform.position, transform.position + -transform.right * transform.localScale.x * 12);
			}
			if (transform.position.x > player.transform.position.x)
			{
				Gizmos.DrawLine(transform.position, transform.position + transform.right * transform.localScale.x * 12);
			}
		}
	}
}
