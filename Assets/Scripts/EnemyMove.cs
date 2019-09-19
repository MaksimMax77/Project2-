using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
	[SerializeField] Transform target;
	float Raydistance;

	[SerializeField]bool patrul;
	public float speed ;
	Vector2 velocity;
	Vector3 direction;
	[SerializeField] float X;
	[SerializeField] float Y;
	void Start()
    {
		patrul = true;
		speed = 10f;
		Raydistance = 10;
		direction = Vector3.right;
	}

    // Update is called once per frame
    void Update()
    {
		 transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, Time.deltaTime * speed);

		//transform.position+=(Vector3)velocity.normalized * Time.deltaTime * speed;
		//velocity = new Vector2(1, 2);

		RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(X, Y), Raydistance);
		Debug.DrawRay(transform.position, new Vector2(X, Y), Color.blue);



		if (hit.collider)
		{
			if (hit.collider.gameObject.tag == "Player")
			{
				patrul = false;
			}
		}
		 
		  

	}
}
