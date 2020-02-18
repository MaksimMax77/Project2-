using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


namespace Sound
{

	public class MusicManager : MonoBehaviour
	{

		public string mainFolder = "GameSounds";

		public string musicFolder = "Music";

		public float fadeSpeed = 3; // скорость плавного перехода между треками музыки

		public AudioMixerGroup musicGroup;


		private static MusicManager _instance;
		private static AudioSource last, current;
		private static float musicVolume;
		private static bool muteMusic;

		void Awake()
		{
			musicVolume = 1;

			_instance = this;
		}



		public static void MusicVolume(float volume)
		{
			musicVolume = volume;
			if (current) current.volume = volume;
		}


		public static void MuteMusic(bool value)
		{
			muteMusic = value;
			if (current) current.mute = value;
		}

		public static void PlayMusic(string name, bool loop)
		{
			_instance.PlayMusicInternal(name, loop);
		}

		void PlayMusicInternal(string musicName, bool loop)
		{
			if (string.IsNullOrEmpty(musicName))
			{
				Debug.Log(_instance + " :: Имя файла не указанно.");
				return;
			}

			StartCoroutine(GetMusic(musicName, loop));
		}



		void LateUpdate()
		{
			Fader();
		}

		void Fader()
		{
			if (last == null) return;

			last.volume = Mathf.Lerp(last.volume, 0, fadeSpeed * Time.deltaTime);
			current.volume = Mathf.Lerp(current.volume, musicVolume, fadeSpeed * Time.deltaTime);

			if (last.volume < 0.05f)
			{
				last.volume = 0;
				Destroy(last.gameObject);
			}
		}

		IEnumerator GetMusic(string musicName, bool loop)
		{
			ResourceRequest request = LoadAsync(musicFolder + "/" + musicName);

			while (!request.isDone)
			{
				yield return null;
			}

			AudioClip clip = (AudioClip) request.asset;

			if (clip == null)
			{
				Debug.Log(_instance + " :: Файл не найден: " + musicName);

			}

			last = current;

			GameObject obj = new GameObject("Music: " + musicName);
			AudioSource au = obj.AddComponent<AudioSource>();
			obj.transform.parent = transform;
			au.outputAudioMixerGroup = musicGroup;
			au.playOnAwake = false;
			au.loop = loop;
			au.mute = muteMusic;
			au.volume = (last == null) ? musicVolume : 0;
			au.clip = clip;
			au.Play();
			current = au;

		}



		ResourceRequest LoadAsync(string name)
		{
			string path = mainFolder + "/" + name;
			return Resources.LoadAsync<AudioClip>(path);
		}
	}
}
