using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour,IPause
{
	bool pauseOff;

   public void SetPauseOnOff()
	{
		if (pauseOff)
		{
			Time.timeScale = 0;
			Debug.Log("пауза включена");
			pauseOff = false;
		}
		else
		{
			Time.timeScale = 1;
			Debug.Log("пауза отключена");
			pauseOff = true;
		}
	}
}
