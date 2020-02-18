using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

namespace Services
{
	[Serializable]
	public struct CharacterStoreInfo
	{
		[JsonProperty] public readonly Vector3 position;
		[JsonProperty] public readonly int health;

		[JsonConstructor]
		public CharacterStoreInfo(Vector3 position, int health)
		{
			this.position = position;
			this.health = health;
		}
	}
}