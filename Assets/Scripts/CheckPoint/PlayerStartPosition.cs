using System.Collections;
using System.Collections.Generic;
using Services;
using UnityEngine;
using Zenject;

namespace ChackPointFolder
{
	public class PlayerStartPosition : MonoBehaviour
	{
		//[Inject] private ISaveService saveService
		[SerializeField] private PlayerSaver playerSaver;


		private void Start()
		{
			playerSaver.PlayerLoad();
			transform.position = playerSaver.jsonSaver.characterInfo.startPos;
		}
	}
}
