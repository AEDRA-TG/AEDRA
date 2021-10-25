using System.Collections;
using System.Collections.Generic;

namespace Model.Common
{
    public class Tutorial
    {
        public string Name { get; set; }
        public string ResourceIconName { get; set; }
        public string VideoURL {get;set;}

        public Tutorial(){}

        public Tutorial(string name,string resourceIconName, string videoURL){
            this.Name = name;
            this.ResourceIconName = resourceIconName;
            this.VideoURL = videoURL;
        }
    }
}