using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeWeapons : MonoBehaviour
{
	
	public WeaponHolder[] weapons; // здесь всё оружие лежит
	public int currentWeapon = 0; // текущее оружие

	// метод при подборе оружия для активации у игрока
	void OnWeaponPickup(string _name)
	{
		foreach (WeaponHolder wh in weapons)
			if (wh._name == _name)
				wh.isPresent = true;
	}

	void Update()
	{
		int wpn = -1;
		if (Input.GetKeyDown(KeyCode.Alpha1)) wpn = 0;
		if (Input.GetKeyDown(KeyCode.Alpha2))wpn = 1;
		if (Input.GetKeyDown(KeyCode.Alpha3)) wpn = 2;
		if (Input.GetKeyDown(KeyCode.Alpha4)) wpn = 3;
		if (Input.GetKeyDown(KeyCode.Alpha5)) wpn = 4;
		if (wpn >= 0)
		{
			weapons[currentWeapon].gunGO.SetActive(false); // выключаем текущее
			weapons[wpn].gunGO.SetActive(true); // включаем выбранное
			currentWeapon = wpn; // запоминаем выбранное
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "TakeGun")
		{
			OnWeaponPickup("FireGun");
			Debug.Log("Pines");
		}
	}
}
