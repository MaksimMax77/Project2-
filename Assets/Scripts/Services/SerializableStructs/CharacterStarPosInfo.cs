using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

namespace Services
{
	[Serializable]
	public struct CharacterStarPosInfo
	{
		[JsonProperty]
		public readonly Vector3 StartPos;

		[JsonConstructor]
		public CharacterStarPosInfo(Vector3 StartPos)
		{
			this.StartPos = StartPos;
		}
	}
}

