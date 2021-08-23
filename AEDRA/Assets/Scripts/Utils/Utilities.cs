using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace Utils {
    public static class Utilities
    {
        public static T DeserializeJSON<T>(string filename){
            string json = File.ReadAllText(filename);
            return JsonConvert.DeserializeObject<T>(json);
        }

        public static void SerializeJSON<T>(string filename, T data){
            string json = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(filename,json);
        }

        public static JObject LoadJSONKey(string filename, string key){
            string json = File.ReadAllText(filename);
            return (JObject)JObject.Parse(json)[key];
        }

        public static void SaveJSONKey(string filename, string key, object data){
            string json = File.ReadAllText(filename);
            JObject jsonObject = JObject.Parse(json);
            jsonObject[key].Replace(JToken.FromObject(data));
            SerializeJSON(filename,jsonObject);
        }
        public static Color LoadGlobalColor(){
            JObject map = LoadJSONKey("Assets/Files/Constants.json","globalColor");
            Color color = new Color((float)map["r"],(float)map["g"],(float)map["b"],(float)map["a"]);
            return color;
        }

        public static void SaveGlobalColor(Color color){
            Dictionary<string,float> colorData = new Dictionary<string, float>{
                {"r",color.r},
                {"g",color.g},
                {"b",color.b},
                {"a",color.a}
            };
            SaveJSONKey("Assets/Files/Constants.json","globalColor",colorData);
            Constants.GlobalColor = color;
        }
    }
}
