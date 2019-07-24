using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace school_diary.Models
{
    public class TeachClass
    {
        public int Id { get; set; }
        public Teach Teachs { get; set; }
        public ClassRoom ClassRooms { get; set; }
        [JsonIgnore]
        public ICollection<TeachClassStudent> TeachClassStudents { get; set; }
    }
}