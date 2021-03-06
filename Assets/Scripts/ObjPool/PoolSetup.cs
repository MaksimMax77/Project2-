﻿using UnityEngine;
using System.Collections;

namespace ObjPool
{
	[AddComponentMenu("Pool/PoolSetup")]
	public class PoolSetup : MonoBehaviour
	{//обертка для управления статическим классом PoolManager

		#region Unity scene settings
		[SerializeField] private PoolManager2.PoolPart[] pools; //структуры, где пользователь задает префаб для использования в пуле и инициализируемое количество 
		#endregion

		#region Methods
		void OnValidate()
		{
			for (int i = 0; i < pools.Length; i++)
			{
				pools[i].name = pools[i].prefab.name; //присваиваем имена заранее, до инициализации
			}
		}

		void Awake()
		{
			Initialize();
		}

		void Initialize()
		{
			PoolManager2.Initialize(pools); //инициализируем менеджер пулов
		}
		#endregion

	}
}