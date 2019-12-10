using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponHolder : MonoBehaviour
{
	public string _name; // имя оружия
	public GameObject gunGO; // го оружия
	public bool isPresent; // флаг наличия оружия

	 
	public Sprite sprite;
	public bool spritOn;
 
	private void Update()
	{
		 
	 	if (isPresent)
	 	{
			gunGO.SetActive(true);
	 	}
	 
	}

 
}
