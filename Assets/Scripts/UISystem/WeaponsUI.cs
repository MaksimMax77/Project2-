using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UiSystem
{
	public class WeaponsUI : MonoBehaviour
	{
		[SerializeField] GameObject weaponEnergy;
		ProgressBar progressBar;
		[SerializeField] GameObject buttonChangeWeapon;
		Image image;

		public WeaponHolder[] guns;


		void Awake()
		{
			progressBar = weaponEnergy.GetComponent<ProgressBar>();
			image = buttonChangeWeapon.GetComponent<Image>();
		}

		// Update is called once per frame
		void Update()
		{
			foreach (var gun in guns)
			{
				if (gun.spritOn)
				{
					image.sprite = gun.sprite;
					var energy = gun.gunGO.GetComponent<GunEnergy>();
					progressBar.BarValue = energy.gunEnerdy;//подумать и посмотреть как сделать лучше отображение пуль
				}
			}
		}
	}
}
