using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectGameObjects : MonoBehaviour
{
	private TakeWeapons weapons;
	public GameObject[] bulletsList;
	private GunEnergy gunEnergy;

	void Awake()
	{
		weapons = GetComponent<TakeWeapons>();
		bulletsList = GameObject.FindGameObjectsWithTag("Bullet_pack");

	}

	void Update()
	{
		CollectsBullets(bulletsList);
	}

	void CollectsBullets(GameObject[] targets)
	{

		foreach (var target in targets)
		{
			var headding = target.transform.position - transform.position;
			if (headding.sqrMagnitude < 1 * 1)
			{
				foreach (var weapon in weapons.weapons)
				{
					var energy = weapon.gunGO.GetComponent<GunEnergy>();
					energy.gunEnerdy += 20;
				}
				
				target.gameObject.SetActive(false);
			}
		}
	}
}
