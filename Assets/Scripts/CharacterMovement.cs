using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterMovement : MonoBehaviour
{
    public Vector2 vecocity;
    [SerializeField] private float speed;
    
  
	public bool WalkSide; // переменные для AnimController

 
 
	void Update()
	{
		transform.position += (Vector3) vecocity.normalized * Time.deltaTime * speed;
		 
		if (vecocity.x != 0)
		{
			WalkSide = true;
		}
		else
		{
			WalkSide = false;
		}
	}
}
