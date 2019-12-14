using System;
using ReginaGameDev.Models;
using ReginaGameDev.Utilities;
using UnityEditor.PackageManager;
using UnityEngine;

namespace ReginaGameDev.Systems
{
    public class NameGeneratorSystem
    {
        private string WordsConfigPath = "Assets/Scripts/Configs/Words.json";
        private RandomWordStorage WordStorage;

        public NameGeneratorSystem()
        {
            try
            {
                WordStorage = JsonLoader.LoadJson<RandomWordStorage>(WordsConfigPath);
            } catch(Exception exception)
            {
                Debug.LogError(exception.Message);
            }
        }

        public PlayerName GenerateName()
        {
            return new PlayerName(WordStorage.GetRandomAdjective(), WordStorage.GetRandomNoun());
        }
    }

}
