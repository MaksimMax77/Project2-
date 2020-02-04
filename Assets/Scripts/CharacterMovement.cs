using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.Requests;
using UnityEngine;


public class CharacterMovement : MonoBehaviour
{
    public Vector2 vecocity;
    [SerializeField] private float speed;
    [SerializeField] private bool isPlayer;
    private Health charHealth;
	public bool WalkSide; // переменные для AnimController

	void Awake()
	{
		charHealth = GetComponent<Health>();
	}
 
	void Update()
	{
		if (isPlayer)
		{
			PlayerMoving();
		}

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

	void PlayerMoving()
	{
		if (charHealth.death == false)
		{
             vecocity = new Vector2(
			Input.GetAxis("Horizontal") * Time.deltaTime,
			Input.GetAxis("Vertical") * Time.deltaTime);
		}
	}
}
