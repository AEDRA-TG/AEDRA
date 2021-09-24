using System.IO;
using UnityEditor;
using UnityEngine;

namespace Utils.Configuration
{
    public class InitializeApplication : MonoBehaviour
    {
        public void Awake()
        {
            ConfigureFiles();
        }

        [System.Obsolete]
        public void ConfigureFiles()
        {
            if (!File.Exists(Constants.ConstantsFilePath))
            {
                WWW www = new WWW(Constants.ConstantsStreamingFilePath);
                while (!www.isDone) {; }
                if (string.IsNullOrEmpty(www.error))
                {
                    File.WriteAllBytes(Constants.ConstantsFilePath, www.bytes);
                }
            }
            if(!File.Exists(Constants.TargetsFilePath)){
                WWW www = new WWW(Constants.TargetsStreamingFilePath);
                while (!www.isDone) {; }
                if (string.IsNullOrEmpty(www.error))
                {
                    File.WriteAllBytes(Constants.TargetsFilePath, www.bytes);
                }
            }
        }
    }
}