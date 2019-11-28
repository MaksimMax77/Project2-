using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerDeath : MonoBehaviour
{
	private Ihealth playerHealth;
	private IPause pause;
	[SerializeField] GameObject deathSprite;
 
	void Update()
    {
		DeathScreenOffOn();
	}

    [Inject]
	public void Init(IPause pause, Ihealth playerHealth)
	{
		print(pause + " injected zaebal");
		this.pause = pause;
		this.playerHealth = playerHealth;
	}

	void DeathScreenOffOn()
	{
		if (playerHealth.death)
		{
			StartCoroutine(PauseEnumerator());
		}
		else
		{
			deathSprite.SetActive(false);
			pause.SetPauseOff();
		}
	}

	IEnumerator PauseEnumerator()
	{
		yield return new WaitForSeconds(2);
		pause.SetPauseOn();
		deathSprite.SetActive(true);
	}
}
