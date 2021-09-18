using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace Utils {
    public static class Utilities
    {
        /// <summary>
        /// Method to deserialize a Object from a JSON file
        /// </summary>
        /// <param name="filename">Filepath of json file</param>
        /// <typeparam name="T">Type of object to deserialize</typeparam>
        /// <returns>Instance of the deserialized object</returns>
        public static T DeserializeJSON<T>(string filename){
            if(File.Exists(filename)){
                string json = File.ReadAllText(filename);
                return JsonConvert.DeserializeObject<T>(json);
            }
            return default;
        }
        /// <summary>
        /// Method to serialize a Object to a JSON file
        /// </summary>
        /// <param name="filename">Filepath of json file</param>
        /// <param name="data">Object to serialize</param>
        /// <typeparam name="T">Type of object to serialize</typeparam>
        public static void SerializeJSON<T>(string filename, T data){
            string json = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(filename,json);
        }

        /// <summary>
        /// Method to load a specified json property by a key
        /// </summary>
        /// <param name="filename">Filepath of json file</param>
        /// <param name="key">Name of the property to load</param>
        /// <returns>A map (json object) that contains the requested value</returns>
        public static JObject LoadJSONKey(string filename, string key){
            string json = File.ReadAllText(filename);
            return (JObject)JObject.Parse(json)[key];
        }
        /// <summary>
        /// Method to override the value of a given key in a json file
        /// </summary>
        /// <param name="filename">Filepath of json file</param>
        /// <param name="key">Name of the property to override</param>
        /// <param name="data">Data to update the value</param>
        public static void SaveJSONKey(string filename, string key, object data){
            string json = File.ReadAllText(filename);
            JObject jsonObject = JObject.Parse(json);
            jsonObject[key].Replace(JToken.FromObject(data));
            SerializeJSON(filename,jsonObject);
        }

        public static bool DeleteFile(string filePath){
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Method to retrieve the globalColor value from a file
        /// </summary>
        /// <returns>The Unity Color retrieved</returns>
        public static Color LoadGlobalColor(){
            if(File.Exists(Constants.ConstantsFilePath)){
                JObject map = LoadJSONKey(Constants.ConstantsFilePath,"globalColor");
                Color color = new Color((float)map["r"],(float)map["g"],(float)map["b"],(float)map["a"]);
                return color;
            }
            else{
                return Color.gray;
            }
        }
        /// <summary>
        /// Method to persist the global color in a file
        /// </summary>
        /// <param name="color">Unity Color to persist</param>
        public static void SaveGlobalColor(Color color){
            Dictionary<string,float> colorData = new Dictionary<string, float>{
                {"r",color.r},
                {"g",color.g},
                {"b",color.b},
                {"a",color.a}
            };
            SaveJSONKey(Constants.ConstantsFilePath,"globalColor",colorData);
            Constants.GlobalColor = color;
        }
        public static string GetDataPath(){
#if UNITY_EDITOR
            return "Assets/Files/";
#elif UNITY_ANDROID
            return Application.persistentDataPath + "/";      
#endif
        }

    }
}
