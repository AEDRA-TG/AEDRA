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
            CopyFile(Constants.ConstantsFilePath, Constants.ConstantsStreamingFilePath);
            CopyFile(Constants.TargetsFilePath, Constants.TargetsStreamingFilePath);
            CopyFile(Constants.DijkstraFilePath, Constants.DijkstraStreamingFilePath);
            CopyFile(Constants.TutorialsFilePath, Constants.TutorialsStreamingFilePath);
            CopyFile(Constants.DijkstraStepsFilePath, Constants.DijkstraStepsStreamingFilePath);
            CopyFile(Constants.TraversalTreeStepsFilePath, Constants.TraversalTreeStepsStreamingFilePath);
            CopyFile(Constants.TraversalGraphStepsFilePath, Constants.TraversalGraphStepsStreamingFilePath);
            Constants.GlobalColor = Utilities.LoadGlobalColor();
        }

        private void CopyFile(string persistentDataPath, string streamingAssetsFilePath){
            if (!File.Exists(persistentDataPath))
            {
                #if UNITY_EDITOR
                string pathFile = "file://" + streamingAssetsFilePath;
                #elif UNITY_ANDROID
                string pathFile = streamingAssetsFilePath;
                #endif

                UnityWebRequest fileRequest = UnityWebRequest.Get(pathFile);
                fileRequest.SendWebRequest();
                while(!fileRequest.isDone){}
                File.WriteAllBytes(persistentDataPath, fileRequest.downloadHandler.data);
            }
        }
    }
}