using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiHealth : MonoBehaviour
{
	[SerializeField] GameObject ProgressBar; 
	Health health;
	ProgressBar progressBar;
	void Awake()
    {
		health = GetComponent<Health>();
		progressBar = ProgressBar.GetComponent<ProgressBar>();
	
	}
	private void Update()
	{
			progressBar.BarValue = health.health;
	}
}
