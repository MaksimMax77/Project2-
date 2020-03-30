using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSaver : MonoBehaviour
{

	[SerializeField] private GameObject Player;
	public JsonSaver jsonSaver;
	[SerializeField] private HealthModel playerHealth ;
	[SerializeField]private SceneSaveLoad thisSceneIndex;
	

    private void Awake()
    {
		jsonSaver = new JsonSaver();
	}

    public void PlayerSave()
	{
		jsonSaver.SaveCharcter(Player.transform.position, playerHealth.health, thisSceneIndex.thisSceneIndex);
	}

	public void PlayerLoad()
	{
		jsonSaver.Load();
		Player.transform.position = jsonSaver.characterInfo.startPos;
		playerHealth.health = jsonSaver.characterInfo.health;
		thisSceneIndex.thisSceneIndex = jsonSaver.characterInfo.lastSceneIndex;
	}
}
