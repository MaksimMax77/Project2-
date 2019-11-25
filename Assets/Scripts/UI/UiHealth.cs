using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiHealth : MonoBehaviour
{
	[SerializeField] GameObject progressBarGameObj; 
	Health health;
	ProgressBar progressBar;
	void Awake()
    {
		health = GetComponent<Health>();
		progressBar = progressBarGameObj.GetComponent<ProgressBar>();
	
	}
	private void Update()
	{
			progressBar.BarValue = health.health;
	}
}
