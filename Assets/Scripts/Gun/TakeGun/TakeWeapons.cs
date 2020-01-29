using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeWeapons : MonoBehaviour
{
	public int wpn;
	public int nextWeapon;
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
		nextWeapon = currentWeapon + 1;
		foreach (var Gun in canTakeWeapons) {
			float dist = Vector2.Distance(Gun.transform.position, transform.position);
			if (dist < 1)
			{
				if (Gun.activeSelf)
				{
                  var obj = Gun.GetComponent<WeaponHolder>();
				  weapons.Add(obj);
			      ButtonClick();
				  Gun.SetActive(false);
				}
			}
		}

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
 