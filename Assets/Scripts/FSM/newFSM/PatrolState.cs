using UnityEngine;

/// Этот класс двигает заданный объект.
public class PatrolState : NewState
{
	CharacterMovement _characterMovement;
	[SerializeField]  GameObject Enemy;//объект который двигать нада


	private void Awake()
	{
		_characterMovement = Enemy.GetComponent<CharacterMovement>();
	}
	void Update()
	{
		 
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
	 
			_characterMovement.vecocity.x = 1;
			if (collision.gameObject.tag == "RightPlatform")
			{
				Debug.Log("правая");
				_characterMovement.vecocity.x = -1;
			}

			else if (collision.gameObject.tag == "LeftPlatform")
			{
				Debug.Log("левая");
				_characterMovement.vecocity.x = 1;
			}
		 
	}
}
