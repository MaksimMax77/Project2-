using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMana : MonoBehaviour
{
	[SerializeField] GameObject ProgressBar;
	Mana mana;
	ProgressBar progressBar;

	void Awake()
	{
		mana = GetComponent<Mana>();
		progressBar = ProgressBar.GetComponent<ProgressBar>();
	}
	private void Update()
	{
		progressBar.BarValue = mana.mana;
	}
}
