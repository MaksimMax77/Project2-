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
	RaycastHit2D _hit;

	float angle;

	private void Awake()
	{
		canAim = false;
	}

	private void Update()
	{
		
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.gameObject.tag == EnemyTag)
		{
			Aiming(collision);
			RedCircleOffOn(collision);
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.tag == EnemyTag)
		{
			canAim = false;
		}
	}

	#region //отвечает за автоприцел пушки
	void Aiming(Collider2D collision)
	{
		canAim = true;
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
		_hit = Physics2D.Raycast(transform.position, -transform.right * transform.localScale.x, 12);
		var circle = collision.gameObject.GetComponent<RedCircleOnnOff>();

		if (_hit.collider != null && _hit.collider.tag == EnemyTag)
		{
			var redCircle = _hit.collider.GetComponent<RedCircleOnnOff>();
			redCircle.RedCircleOn = true;
		}

		if (_hit.collider == null)
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
		Gizmos.DrawLine(transform.position, transform.position + -transform.right * transform.localScale.x * 12);
	}
}
