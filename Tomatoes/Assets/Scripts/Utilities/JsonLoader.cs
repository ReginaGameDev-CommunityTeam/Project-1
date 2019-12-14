using System;
using System.IO;
using UnityEngine;

namespace ReginaGameDev.Utilities
{
    public class JsonLoader
    {
        public static T LoadJson<T>(string path)
        {
            try
            {
                using (StreamReader stream = new StreamReader(path))
                {
                    string jsonContents = stream.ReadToEnd();
                    return JsonUtility.FromJson<T>(jsonContents);
                }
            } catch(Exception ex)
            {
                throw new Exception($"JsonLoader failed to read file", ex);
            }
        }
    }
}
