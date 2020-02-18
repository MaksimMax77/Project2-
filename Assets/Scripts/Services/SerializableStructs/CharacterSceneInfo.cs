using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

namespace Services
{
	[Serializable]
	public struct CharacterSceneInfo
	{
		[JsonProperty] public readonly int lastSceneindex;

		[JsonConstructor]
		public CharacterSceneInfo(int lastSceneindex)
		{
			this.lastSceneindex = lastSceneindex;
		}
	}
}