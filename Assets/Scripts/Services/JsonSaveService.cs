using System;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

namespace Services
{
    public class JsonSaveService : ISaveService
    {
        private readonly String _fileName = "save.json";

        public void SaveCharacter(Vector3 position,int health)
        {
            using (var file = File.Open(
                MakePath(), 
                FileMode.Create))
            using (var streamWriter = new StreamWriter(file))
            {
                var json = JsonConvert.SerializeObject(
                    new CharacterStoreInfo(position,health)
                );

                streamWriter.Write(json);
            }
        }

        public Vector3 LoadCharacterPosition()
        {
            using (var file = File.Open(MakePath(), FileMode.Open))
            using (var streamReader = new StreamReader(file))
            {
                var json = streamReader.ReadToEnd();

                var storeInfo = JsonConvert.DeserializeObject<CharacterStoreInfo>(json);
                return storeInfo.position;
            }
			 
		}
        public int LoadCharacterHealth()
		{
			using (var file = File.Open(MakePath(), FileMode.Open))
			using (var streamReader = new StreamReader(file))
			{
				var json = streamReader.ReadToEnd();

				var storeInfo = JsonConvert.DeserializeObject<CharacterStoreInfo>(json);
				return storeInfo.health;
			}

		}

		private string MakePath()
        {
            return Path.Combine(Application.streamingAssetsPath.Replace("StreamingAssets", ""), _fileName);
        }

		
	}

    [Serializable]
    public struct CharacterStoreInfo
    {
        [JsonProperty]
        public readonly Vector3 position;
		[JsonProperty]
		public readonly int health;

		[JsonConstructor]
        public CharacterStoreInfo(Vector3 position,int health)
        {
            this.position = position;
			this.health = health;
        }
    }
}