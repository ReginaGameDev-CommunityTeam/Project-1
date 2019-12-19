using System.Collections.Generic;
using UnityEngine;

namespace ReginaGameDev.Models
{
    [System.Serializable]
    public class RandomWordStorage
    {
        public List<string> Adjectives;
        public List<string> Nouns;

        public string GetRandomAdjective()
        {
            return Adjectives[Random.Range(0, Adjectives.Count)];
        }
        public string GetRandomNoun()
        {
            return Nouns[Random.Range(0, Nouns.Count)];
        }
    }
}
