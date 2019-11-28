using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : IPause
{
   public void SetPauseOn()
	{
			Time.timeScale = 0;
	}

	public void SetPauseOff()
	{
			Time.timeScale = 1;
	}
}
