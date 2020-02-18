using System.Collections;
using System.Collections.Generic;
using GunSystem;
using UnityEngine;

public class CollectGameObjects : MonoBehaviour
{
	private WeaponsChanger weapons;
	public GameObject[] bulletsList;
	private GunEnergy gunEnergy;

	void Awake()
	{
		weapons = GetComponent<WeaponsChanger>();
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.tag == "Bullet_pack")
		{
			if (collider.gameObject.activeSelf)
			{
				foreach (var weapon in weapons.weapons)
				{
					var energy = weapon.gunGO.GetComponent<GunEnergy>();
					energy.gunEnerdy += 20;
				}
				collider.gameObject.SetActive(false);
			}
		}

		if (collider.gameObject.tag == "TakeGun")
		{
			if (collider.gameObject.activeSelf)
			{
				var obj = collider.gameObject.GetComponent<WeaponHolder>();
				weapons.weapons.Add(obj);
				weapons.ButtonClick();
				collider.gameObject.SetActive(false);
			}
		}
	}
}
