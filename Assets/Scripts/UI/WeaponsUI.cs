using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WeaponsUI : MonoBehaviour
{
	 
 
	public GameObject buttonChangeWeapon;
	public Image image;

	WeaponHolder weaponsHol;
	public WeaponHolder[] guns;


	void Awake()
    {
		image = buttonChangeWeapon.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
		foreach(var gun in guns)
		{
			if (gun.spritOn)
			{
				image.sprite = gun.sprite;
			}
		}
		 
	}
 
}
