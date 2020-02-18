using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Services;


public class SceneLoader : MonoBehaviour
{
	JsonSaveService saveService = new JsonSaveService();
	 
	int IndexOfThisScene;

	public void SaveLoadSceneIndex(int IndexOfThisScene)// должно сохранять индекс текущей сцены, если его указать в IndexOfThisScene
	{
		this.IndexOfThisScene = IndexOfThisScene;
		saveService.SaveLevelIndex(IndexOfThisScene);
	}

	public void SaveStartPlayerPosition(Vector3 position)
	{
		saveService.SavePlayerStartPosition(position);
	}

	public void LoadStartPlayerPosition()
	{
		saveService.LoadPlayerStartPosition();
	}


	public void LoadSceneIndex()//должно загружать сцену
	{
		IndexOfThisScene = saveService.LoadLevelIndex();
		Loadscene(IndexOfThisScene);
	} 

	public void Loadscene(int sceneIndex)
	{
		SceneManager.LoadScene(sceneIndex);
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
