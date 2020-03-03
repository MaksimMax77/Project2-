using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthView : MonoBehaviour
{
	[SerializeField] private GameObject progressBarGameObj;
	private HealthModel healthModel;
	private ProgressBar progressBar;


	void Awake()
	{
		healthModel = GetComponent<HealthModel>();
		progressBar = progressBarGameObj.GetComponent<ProgressBar>();
	}


	private void Update()
	{
		progressBar.BarValue = healthModel.health;
	}
}
