using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace school_diary.Models
{
    public class TeachClassStudent
    {
        public int Id { get; set; }
        public Student Students { get; set; }
        public TeachClass TeachClasses { get; set; }
        [JsonIgnore]
        public ICollection<TeachClassStudentGrade> TeClStGrs { get; set; }
    }
}