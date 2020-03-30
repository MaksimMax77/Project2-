using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;

public class JsonSaver  
{
	private string saveFilePath = "characterSave.json";
	public CharacterInfo characterInfo;


	public JsonSaver()
	{
		characterInfo = new CharacterInfo();
	}

	private string MakePath(string name)
	{
		return Path.Combine(Application.streamingAssetsPath.Replace("StreamingAssets", ""), name);
	}

	public void SaveCharcter(Vector3 startPos, int health, int lastSceneIndex)
	{
		File.WriteAllText(MakePath(saveFilePath), JsonConvert.SerializeObject(new CharacterInfo(startPos, health, lastSceneIndex)));
	}	 


	public void Load()
	{
		using (var file = File.Open(MakePath(saveFilePath), FileMode.Open))
		using (var streamReader = new StreamReader(file))
		{
			var json = streamReader.ReadToEnd();

			var  Info = JsonConvert.DeserializeObject<CharacterInfo>(json);
			characterInfo.lastSceneIndex = Info.lastSceneIndex;
			characterInfo.health = Info.health;
			characterInfo.startPos = Info.startPos;
		}
	}
	 

}
