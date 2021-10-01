using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;

namespace Utils.Configuration
{
    public class InitializeApplication : MonoBehaviour
    {
        public void Awake()
        {
            ConfigureFiles();
        }
        public void ConfigureFiles()
        {
            if (!File.Exists(Constants.ConstantsFilePath))
            {
                #if UNITY_EDITOR
                string pathFile = "file://" + Constants.ConstantsStreamingFilePath;
                #elif UNITY_ANDROID
                string pathFile = Constants.ConstantsStreamingFilePath;
                #endif
                UnityWebRequest fileRequest = UnityWebRequest.Get(pathFile);
                fileRequest.SendWebRequest();
                while(!fileRequest.isDone){}
                File.WriteAllBytes(Constants.ConstantsFilePath, fileRequest.downloadHandler.data);
            }
            if(!File.Exists(Constants.TargetsFilePath)){
                #if UNITY_EDITOR
                string pathFile = "file://" + Constants.TargetsStreamingFilePath;
                #elif UNITY_ANDROID
                string pathFile = Constants.TargetsStreamingFilePath;
                #endif
                UnityWebRequest fileRequest = UnityWebRequest.Get(pathFile);
                fileRequest.SendWebRequest();
                while(!fileRequest.isDone){}
                File.WriteAllBytes(Constants.TargetsFilePath, fileRequest.downloadHandler.data);
            }
            Constants.GlobalColor = Utilities.LoadGlobalColor();
        }
    }
}