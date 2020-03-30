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
		 
		//[Inject] private ISaveService saveService;
		[SerializeField] private GameObject player;
		[SerializeField] private PlayerSaver playerSaver;
		
		void OnTriggerEnter2D(Collider2D collider)
		{
			if (collider.gameObject.tag == "Player")
			{
				playerSaver.PlayerSave();
				Debug.Log("чекпоинт");
			}
		}
	}
}
