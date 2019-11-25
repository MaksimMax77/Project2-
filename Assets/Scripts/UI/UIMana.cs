using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMana : MonoBehaviour
{
	[SerializeField] GameObject progressBarGameObj;
	Mana mana;
	ProgressBar progressBar;

	void Awake()
	{
		mana = GetComponent<Mana>();
		progressBar = progressBarGameObj.GetComponent<ProgressBar>();
	}
	private void Update()
	{
		progressBar.BarValue = mana.mana;
	}
}
