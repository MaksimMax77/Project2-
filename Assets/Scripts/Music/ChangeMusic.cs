using UnityEngine;
 

public class ChangeMusic : MonoBehaviour
{
	[SerializeField] MusicManagerComponent battleMusicCompanent;
	[SerializeField] MusicManagerComponent fonMusicCompanent;
	public bool isBattleMusic;

	private void Start()
	{
		fonMusicCompanent.enabled = true;
	}

	private void Update()
	{
		Change();
	}

	void Change()
	{
		if (isBattleMusic)
		{
			battleMusicCompanent.enabled = true;
			fonMusicCompanent.enabled = false;
		}
		else
		{
			battleMusicCompanent.enabled = false;
			fonMusicCompanent.enabled = true;
		}
	}
}
 
