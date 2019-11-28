using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerDeath : MonoBehaviour
{
	Health playerHealth;
	PauseController pause;
	GameObject player;
     
    void Awake()
    {
		player = GameObject.FindGameObjectWithTag("Player");
		playerHealth = player.GetComponent<Health>();
    }

	[Inject]
	public void Init(PauseController pause)
	{
		print(pause + " injected zaebal");
		this.pause = pause;
	}

	void Update()
    {
		if (playerHealth.death)
		{
			
			pause.SetPauseOnOff();
		}
    }
}
