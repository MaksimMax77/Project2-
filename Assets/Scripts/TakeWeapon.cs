using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class TakeWeapon : MonoBehaviour
{
	[SerializeField] Transform PlayerHand;

	[SerializeField] GameObject TakeSword;//геймобжект лежащего оружия на полу
	[SerializeField] GameObject TakeAxe;
	[SerializeField] Transform DropWeapon;// точка куда выкидывается заменяемое оружие 

	[SerializeField] GameObject PlayerSword;//геймобжекты оружие в руке
	[SerializeField] GameObject PlayerAxe;
	[SerializeField] private KeyCode TakeButton = KeyCode.G;

	public bool _playerAxeActiv;
	public bool _playerSwordActiv;


	private void OnTriggerStay2D(Collider2D collision)
	{
		if (Input.GetKeyDown(TakeButton))
		{ 

			if (collision.gameObject.tag == "Sword")
			{
				var obj = collision.gameObject;
				obj.SetActive(false);
				_playerSwordActiv = true;
				if (_playerAxeActiv)
				{
					_playerAxeActiv = false;
					TakeAxe.SetActive(true);
					TakeAxe.transform.position = DropWeapon.position;
				}
			}

			else if (collision.gameObject.tag == "Axe")
			{
				var obj = collision.gameObject;
				obj.SetActive(false);
				_playerAxeActiv = true;
				if (_playerSwordActiv)
				{
					_playerSwordActiv = false;
					TakeSword.SetActive(true);
					TakeSword.transform.position = DropWeapon.position;
				}
			}

		}
	}


	private void Update()
	{ 
			if (_playerAxeActiv)
		{
			PlayerSword.SetActive(false);
			PlayerAxe.SetActive(true);
			_playerSwordActiv = false;
		}

		if (_playerSwordActiv)
		{
			PlayerSword.SetActive(true);
			PlayerAxe.SetActive(false);
			_playerAxeActiv = false;
		}
	}
}
