using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace school_diary.Utilities
{
    [DataContract]
    public class FileInformation
    {
        public FileInformation(string dirName, string name, string mimeType, long size, DateTime lastModified)
        {
            this.dirName = dirName;
            this.name = name;
            this.mimeType = mimeType;
            this.size = size;
            this.lastModified = lastModified;
        }

        [DataMember(Name = "Files")]
        public string dirName { get; set; }
        [DataMember (Name ="FileName")]
        public string name { get; set; }
        [DataMember (Name ="MimeType")]
        [JsonProperty(PropertyName = "mime-type")]
        public string mimeType { get; set; }
        [DataMember(Name ="DateModified")]
        public DateTime lastModified { get; set; }
        [DataMember(Name ="FileSize")]
        public long size { get; set; }
    }
}