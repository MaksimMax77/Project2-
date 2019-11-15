using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
	public string _name; // имя оружия
	public GameObject gunGO; // го оружия
	public bool isPresent; // флаг наличия оружия

	private void Update()
	{
		if (isPresent)
		{
			gunGO.SetActive(true);
			gameObject.SetActive(false);
		}
		else
		{
			gunGO.SetActive(false);
		}
	}
}
