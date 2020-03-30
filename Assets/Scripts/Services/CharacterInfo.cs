using System;
using UnityEngine;
using Newtonsoft.Json;


[Serializable]
public struct CharacterInfo 
{
	[JsonProperty] public int health;
	[JsonProperty] public  Vector3 startPos;
	[JsonProperty] public int lastSceneIndex;
	 

	[JsonConstructor]
	public CharacterInfo(Vector3 startPos, int health, int lastSceneIndex)
	{
		this.startPos = startPos;
		this.health = health;
		this.lastSceneIndex = lastSceneIndex;
	}
}
