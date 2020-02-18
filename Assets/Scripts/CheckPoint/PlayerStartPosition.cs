using System.Collections;
using System.Collections.Generic;
using Services;
using UnityEngine;
using Zenject;

namespace ChackPointFolder
{
	public class PlayerStartPosition : MonoBehaviour
	{
		public Transform startPoisition; // определяет начальную позицию игрока при включении уровня.

		[Inject] private ISaveService saveService;

		void Start()
		{
			startPoisition.position = saveService.LoadPlayerStartPosition();
			transform.position = startPoisition.position;
		}
	}
}
