using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace UserInputOutput.Models
{
    public class TimeSheet
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public int Type { get; set; }   // 1 for input ..... 2 for output 
        
    }

}