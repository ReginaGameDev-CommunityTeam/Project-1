using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using ReginaGameDev.Utilities;

namespace ReginaGameDev.Models
{
    [System.Serializable]
    public class RandomWordStorage
    {
        public List<string> Adjectives;
        public List<string> Nouns;

        public string GetRandomAdjective()
        {
            return Adjectives[Random.Range(0, Adjectives.Count - 1)];
        }
        public string GetRandomNoun()
        {
            return Nouns[Random.Range(0, Nouns.Count - 1)];
        }
    }
}
