using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSaveLoad : MonoBehaviour
{
	[SerializeField] private PlayerSaver saver;
	public int thisSceneIndex;

	void Start()
    {
		//saver.PlayerSave();
    }
}
