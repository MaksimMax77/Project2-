using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsUI : MonoBehaviour
{
	TakeWeapons takeWeapons;
    void Awake()
    {
		var Player = GameObject.FindGameObjectWithTag("Player");
		takeWeapons = Player.GetComponent<TakeWeapons>();
    }

    // Update is called once per frame
    void Update()
    {
	 
	}

 public void ClickButton1()
	{
		takeWeapons.wpn = 0;
	}
public	void ClickButton2()
	{
		takeWeapons.wpn = 1;
	}
public	void ClickButton3()
	{
		takeWeapons.wpn = 2;
	}
}
