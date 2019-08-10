using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace school_diary.Models
{
    public class Mark
    {
        public int Id { get; set; }

        [Range(1,5, ErrorMessage ="Ocena ne moze biti manja od 1, ni veca od 5!!!")]
        public int MarkValue { get; set; }
        public DateTime InsertDate { get; set; } = DateTime.Now;
        public DateTime? ChangeDate { get; set; }
        public virtual Teach Teaches { get; set; }
    }
}