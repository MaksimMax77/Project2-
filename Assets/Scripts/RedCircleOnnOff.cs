﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedCircleOnnOff : MonoBehaviour
{
	public bool RedCircleOn;
	private HealthModel health;
	[SerializeField] GameObject RedCircle;


	private void Awake()
	{
		health = GetComponent<HealthModel>();
	}

	void Update()
    {
		if (health.health <= 0)
		{
			RedCircleOn = false;
		}
		if (RedCircleOn==true)
		{
			RedCircle.SetActive(true);
		}
		else if(RedCircleOn == false)
		{
			RedCircle.SetActive(false);
		}
    }
}
