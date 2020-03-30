using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Services;


public class SceneLoader : MonoBehaviour
{
	private JsonSaver jsonSaver;
	private int lastSceneIndex;

	private void Awake()
	{
		jsonSaver = new JsonSaver();
	}

	public void Loadscene(int sceneIndex)
	{
		SceneManager.LoadScene(sceneIndex);
	}

	public void LoadSavedScene()
	{
		jsonSaver.Load();
		lastSceneIndex = jsonSaver.characterInfo.lastSceneIndex;
		Loadscene(lastSceneIndex);
	}

	public void RestartThisScene()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void ApplicationQuit()
	{
		Application.Quit();
	}
}
