using System;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

namespace Services
{
	public class JsonSaveService : ISaveService
	{
		private readonly String _fileName = "save.json";
		private readonly String _fileLevelIndex = "saveLevelindex.json";
		private readonly String _playerStartPos = "playerStartPos.json";

		public int LoadLevelIndex()//загрузить индекс уровня
		{
			using (var file = File.Open(MakePath(_fileLevelIndex), FileMode.Open))
			using (var streamReader = new StreamReader(file))
			{
				var json = streamReader.ReadToEnd();

				var storeInfo = JsonConvert.DeserializeObject<CharacterSceneInfo>(json);
				return storeInfo.lastSceneindex;
			}
		}

		public void SaveLevelIndex(int index)// сохранить индекс уровня
		{
			using (var file = File.Open(MakePath(_fileLevelIndex),FileMode.Create))
			using (var streamWriter = new StreamWriter(file))
			{
				var json = JsonConvert.SerializeObject(
					new CharacterSceneInfo(index)
				);

				streamWriter.Write(json);
			}
		}

		public void SavePlayerStartPosition(Vector3 playerStartPos)
		{
			using (var file = File.Open(MakePath(_playerStartPos), FileMode.Create))
			using (var streamWriter = new StreamWriter(file))
			{
				var json = JsonConvert.SerializeObject(
					new CharacterStarPosInfo(playerStartPos)
				);

				streamWriter.Write(json);
			}
		}

		public Vector3 LoadPlayerStartPosition()//загрузить индекс уровня
		{
			using (var file = File.Open(MakePath(_playerStartPos), FileMode.Open))
			using (var streamReader = new StreamReader(file))
			{
				var json = streamReader.ReadToEnd();

				var storeInfo = JsonConvert.DeserializeObject<CharacterStarPosInfo>(json);
				return storeInfo.StartPos;
			}
		}

		public void SaveCharacter(Vector3 position, int health)
		{
			using (var file = File.Open(
				MakePath(_fileName),
				FileMode.Create))
			using (var streamWriter = new StreamWriter(file))
			{
				var json = JsonConvert.SerializeObject(
					new CharacterStoreInfo(position, health)
				);

				streamWriter.Write(json);
			}
		}

		public Vector3 LoadCharacterPosition()
		{
			using (var file = File.Open(MakePath(_fileName), FileMode.Open))
			using (var streamReader = new StreamReader(file))
			{
				var json = streamReader.ReadToEnd();

				var storeInfo = JsonConvert.DeserializeObject<CharacterStoreInfo>(json);
				return storeInfo.position;
			}

		}
		public int LoadCharacterHealth()
		{
			using (var file = File.Open(MakePath(_fileName), FileMode.Open))
			using (var streamReader = new StreamReader(file))
			{
				var json = streamReader.ReadToEnd();

				var storeInfo = JsonConvert.DeserializeObject<CharacterStoreInfo>(json);
				return storeInfo.health;
			}

		}

		private string MakePath(string name)
		{
			return Path.Combine(Application.streamingAssetsPath.Replace("StreamingAssets", ""), name);
		}
	}
}