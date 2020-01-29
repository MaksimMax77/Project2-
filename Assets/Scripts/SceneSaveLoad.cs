using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSaveLoad : MonoBehaviour
{
	[SerializeField] SceneLoader sceneLoader;
	[SerializeField] int thisSceneIndex;

    void Start()
    {
		sceneLoader.SaveLoadSceneIndex(thisSceneIndex);
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
