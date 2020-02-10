﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsChanger : MonoBehaviour
{
	public int wpn;
	public int nextWeapon;
	public List<WeaponHolder> weapons; // здесь всё оружие лежит
	public  int currentWeapon = 0; // текущее оружие
	int nextweapon;

	// метод при подборе оружия для активации у игрока
	void OnWeaponPickup(string _name)
	{
		foreach (WeaponHolder wh in weapons)
			if (wh._name == _name)
				wh.isPresent = true;
	}

	void Update()
	{
		nextWeapon = currentWeapon + 1;
		RemoveWeaponFromList();
	}

	public void ButtonClick()
	{
		wpn = (wpn + 1) % weapons.Count;
		weapons[currentWeapon].gunGO.SetActive(false); // выключаем текущее
		weapons[currentWeapon].spritOn = false;
		weapons[wpn].gunGO.SetActive(true); // включаем выбранное
		weapons[wpn].spritOn = true ;
		currentWeapon = wpn; // запоминаем выбранное
	 
	}


	void RemoveWeaponFromList()
	{
		foreach (var weaponHolder in weapons)
		{
			var weaponsEnergy = weaponHolder.gunGO.GetComponent<GunEnergy>();
			if (weaponsEnergy.gunEnerdy <= 0)
			{
				wpn = (wpn + 1) % weapons.Count;
				weapons[currentWeapon].gunGO.SetActive(false);
				weapons[currentWeapon].spritOn = false;
				weapons.Remove(weaponHolder);//
				weapons[0].gunGO.SetActive(true);
				weapons[0].spritOn = true;
				currentWeapon = wpn;
			}
		}
	}


}	 
 