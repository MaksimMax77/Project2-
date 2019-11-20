using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeWeapons : MonoBehaviour
{
	public int wpn;
	public List<WeaponHolder> weapons; // здесь всё оружие лежит
	public  int currentWeapon = 0; // текущее оружие

	int nextweapon;
[SerializeField] GameObject[]  canTakeWeapons;
	private void Awake()
	{
		  canTakeWeapons = GameObject.FindGameObjectsWithTag("TakeGun");
	}
	// метод при подборе оружия для активации у игрока
	void OnWeaponPickup(string _name)
	{
		foreach (WeaponHolder wh in weapons)
			if (wh._name == _name)
				wh.isPresent = true;
	}



	void Update()
	{
		//wpn = -1;
		if (Input.GetKeyDown(KeyCode.Alpha1)) wpn = 0;
		if (Input.GetKeyDown(KeyCode.Alpha2)) wpn = 1;
		foreach (var Gun in canTakeWeapons) {
			float dist = Vector3.Distance(Gun.transform.position, transform.position);
			if (dist < 1)
			{
				if (Gun.activeSelf)
				{
                  var obj = Gun.GetComponent<WeaponHolder>();

				weapons.Add(obj);
				 Gun.SetActive(false);
				}
				
			}
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "TakeGun")
		{
		 
		}
	}


	public void ButtonClick()
	{

		    wpn = (wpn + 1) % weapons.Count;
			weapons[currentWeapon].gunGO.SetActive(false); // выключаем текущее
			weapons[wpn].gunGO.SetActive(true); // включаем выбранное
			 currentWeapon = wpn; // запоминаем выбранное
	 
	}
}	 
 