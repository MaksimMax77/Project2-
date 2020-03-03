using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using Services;
using Zenject;

namespace ChackPointFolder
{	
	public class CheckPoint : MonoBehaviour
	{
		 
		[Inject] private ISaveService saveService;
		[SerializeField] private GameObject player;
		private PlayerStartPosition playerStartPosition;
		 

		void Awake()
		{
			playerStartPosition = player.GetComponent<PlayerStartPosition>();
		}


		void OnTriggerEnter2D(Collider2D collider)
		{
			if (collider.gameObject.tag == "Player")
			{
				playerStartPosition.startPoisition.position = transform.position;
				Debug.Log("чекпоинт");
				saveService.SavePlayerStartPosition(playerStartPosition.startPoisition.position);
			}
		}
	}
}
