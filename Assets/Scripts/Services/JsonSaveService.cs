using System;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

namespace Services
{
    public class JsonSaveService : ISaveService
    {
        private readonly String _fileName = "save.json";

        public void SaveCharacterPosition(Vector2 position)
        {
            using (var file = File.Open(
                MakePath(), 
                FileMode.Create))
            using (var streamWriter = new StreamWriter(file))
            {
                var json = JsonConvert.SerializeObject(
                    new CharacterStoreInfo(position)
                );

                streamWriter.Write(json);
            }
        }

        public Vector2 LoadCharacterPosition()
        {
            using (var file = File.Open(MakePath(), FileMode.Open))
            using (var streamReader = new StreamReader(file))
            {
                var json = streamReader.ReadToEnd();

                var storeInfo = JsonConvert.DeserializeObject<CharacterStoreInfo>(json);
                return storeInfo.position;
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
        public readonly Vector2 position;

        [JsonConstructor]
        public CharacterStoreInfo(Vector2 position)
        {
            this.position = position;
        }
    }
}