using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ManaView : MonoBehaviour
{
	[SerializeField] private GameObject progressBarGameObj;
	[Inject]private IMana mana;
	private ProgressBar progressBar;

	void Awake()
	{
		progressBar = progressBarGameObj.GetComponent<ProgressBar>();
	}
	private void Update()
	{
		progressBar.BarValue = mana.mana;
	}
}
