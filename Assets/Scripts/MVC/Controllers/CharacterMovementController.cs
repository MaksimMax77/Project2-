using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementController: BaseController
{
	private HealthModel charHealth;
	private CharacterMovementModel characterMovement;
	private GameObject character;
	 

	public CharacterMovementController(CharacterMovementModel characterMovement, GameObject character)
	{
		this.characterMovement = characterMovement;
		this.character = character;
		charHealth = character.GetComponent<HealthModel>();
	}

	public override void ControllerUpdate()
	{
		if (characterMovement.isPlayer)
		{
			PlayerMoving();
		}

		character.transform.position += (Vector3)characterMovement.vecocity.normalized * Time.deltaTime * characterMovement.speed;
		 

		if (characterMovement.vecocity.x != 0)
		{
			characterMovement.WalkSide = true;
		}
		else
		{
			characterMovement.WalkSide = false;
		}
	}

	void PlayerMoving()
	{
		if (charHealth.death == false)
		{
			characterMovement.vecocity = new Vector2(
		   Input.GetAxis("Horizontal") * Time.deltaTime,
		   Input.GetAxis("Vertical") * Time.deltaTime);
		}
	}
}
