using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ReginaGameDev.Models;
using ReginaGameDev.Utilities;

namespace ReginaGameDev.Systems
{
    public class NameGeneratorSystem
    {
        private string WordsConfigPath = "Assets/Scripts/Configs/Words.json";
        private RandomWordStorage WordStorage;

        public NameGeneratorSystem()
        {
            WordStorage = JsonLoader.LoadJson<RandomWordStorage>(WordsConfigPath);
        }

        public PlayerName GenerateName()
        {
            return new PlayerName(WordStorage.GetRandomAdjective(), WordStorage.GetRandomNoun());
        }
    }

}
