using System;
using Newtonsoft.Json;
using UnityEngine;

namespace Services
{
    public interface ISaveService
    {
        void SaveCharacterPosition(Vector2 position);
        Vector2 LoadCharacterPosition();
    }
}