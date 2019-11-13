using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeThisGun : AbstractTakeGun
{
	public bool _holdGun;
 
	RaycastHit2D _hit;

	private void Update()
	{
		TakeGun();
	}

	public override void TakeGun()
	{

		if (Input.GetKeyDown(KeyCode.G))
		{
			if (!_holdGun)
			{
				Physics2D.queriesStartInColliders = false;
				_hit = Physics2D.Raycast(transform.position, Vector2.left * transform.localScale.x, _distance);
				if (_hit.collider != null && _hit.collider.tag == "TakeGun")
				{
					_holdGun = true;
				}
			}
			else
			{
				_holdGun = false;
				if (_hit.collider.gameObject.GetComponent<Rigidbody2D>() != null)
				{
					_hit.collider.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.localScale.x, 1) * _throwObj;
				}
			}
		}

		if (_holdGun)
		{
			_hit.collider.gameObject.transform.position = holdPoint.position;
			if (holdPoint.position.x > transform.position.x && _holdGun == true)
			{
				_hit.collider.gameObject.transform.localScale = new Vector2(transform.localScale.x, transform.localScale.y);
			}
			else if (holdPoint.position.x < transform.position.x && _holdGun == true)
			{
				_hit.collider.gameObject.transform.localScale = new Vector2(transform.localScale.x, transform.localScale.y);
			}
		}
	}

}
