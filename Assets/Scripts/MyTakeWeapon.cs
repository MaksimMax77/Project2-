using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTakeWeapon : MonoBehaviour
{
	public bool _hold;
	public float _distance = 5f;
	RaycastHit2D _hit;
	[SerializeField] Transform holdPoint;
	public float _throwObj = 0.5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.G))
		{
			if (!_hold)
			{
				Physics2D.queriesStartInColliders = false;
				_hit = Physics2D.Raycast(transform.position, Vector2.left * transform.localScale.x, _distance);
				if (_hit.collider != null && _hit.collider.tag=="CanTake")
				{
					_hold = true;
				}
			}
			else
			{
				_hold = false;
				if (_hit.collider.gameObject.GetComponent<Rigidbody2D>() != null)
				{
					 _hit.collider.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.localScale.x, 1)*_throwObj;
				}
			}
		}

		if (_hold)
		{
			_hit.collider.gameObject.transform.position = holdPoint.position;
			if(holdPoint.position.x>transform.position.x && _hold== true)
			{
				_hit.collider.gameObject.transform.localScale = new Vector2( transform.localScale.x,  transform.localScale.y);
			}
			else if(holdPoint.position.x < transform.position.x && _hold == true)
			{
				_hit.collider.gameObject.transform.localScale = new Vector2(  transform.localScale.x,  transform.localScale.y);
			}
		}
    }

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.blue;
		Gizmos.DrawLine(transform.position, transform.position + Vector3.left * transform.localScale.x * _distance);
	}

}
