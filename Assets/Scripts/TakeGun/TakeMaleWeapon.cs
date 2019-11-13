using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeMaleWeapon : AbstractTakeGun
{
	public bool _holdMaleeWeapon;
	RaycastHit2D _hit;

	void Update()
	{
		TakeGun();
	}


	public override void TakeGun()
	{
		if (Input.GetKeyDown(KeyCode.G))
		{
			if (!_holdMaleeWeapon)
			{
				Physics2D.queriesStartInColliders = false;
				_hit = Physics2D.Raycast(transform.position, Vector2.left * transform.localScale.x, _distance);
				if (_hit.collider != null && _hit.collider.tag == "CanTake")
				{
					_holdMaleeWeapon = true;
				}
			}
			else
			{
				_holdMaleeWeapon = false;
				if (_hit.collider.gameObject.GetComponent<Rigidbody2D>() != null)
				{
					_hit.collider.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.localScale.x, 1) * _throwObj;
				}
			}
		}

		if (_holdMaleeWeapon)
		{
			_hit.collider.gameObject.transform.position = holdPoint.position;
			if (holdPoint.position.x > transform.position.x && _holdMaleeWeapon == true)
			{
				_hit.collider.gameObject.transform.localScale = new Vector2(transform.localScale.x, transform.localScale.y);
			}
			else if (holdPoint.position.x < transform.position.x && _holdMaleeWeapon == true)
			{
				_hit.collider.gameObject.transform.localScale = new Vector2(transform.localScale.x, transform.localScale.y);
			}
		}
	}
}
 