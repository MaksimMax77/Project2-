﻿using System;
using Newtonsoft.Json;
using UnityEngine;

namespace Services
{
    public interface ISaveService
    {
        void SaveCharacter(Vector3 position,int health);
        Vector3 LoadCharacterPosition();
		int LoadCharacterHealth();
		void SavePlayerStartPosition(Vector3 playerStartPos);
		Vector3 LoadPlayerStartPosition();

    }
}