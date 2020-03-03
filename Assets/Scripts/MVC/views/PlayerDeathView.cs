using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathView : MonoBehaviour
{
	public GameObject deathSprite;
	PlayerDeathModel playerDeathModel;

	void Awake()
    {
		playerDeathModel = GetComponent<PlayerDeathModel>();
	}

	private IEnumerator PauseEnumerator()
	{
		yield return new WaitForSeconds(2);
		Time.timeScale = 0;
		deathSprite.SetActive(true);
	}

	public void DeathOff()
	{
		 deathSprite.SetActive(false);
		Time.timeScale = 1;
	}

	public void DeathOn()
	{
		StartCoroutine(PauseEnumerator());
	}
}
