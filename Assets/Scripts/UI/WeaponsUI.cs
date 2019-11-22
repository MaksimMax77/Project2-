using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WeaponsUI : MonoBehaviour
{
	TakeWeapons takeWeapons;
	Image image;
    void Awake()
    {
		var Player = GameObject.FindGameObjectWithTag("Player");
		takeWeapons = Player.GetComponent<TakeWeapons>();
		image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
	// image.sprite=
	}
 
}
