using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ali.Helper
{
    public static class SerializationManager
    {
        static JsonSerializerSettings settings;

        public static void Init()
        {
            settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            };
        }

        public static string SerializeObject<T>(T _object)
        {
            return JsonConvert.SerializeObject(_object, settings);
        }

        public static T DeserializeObject<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json, settings);
        }
    }
}