using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace UserInputOutput.Models
{
    public class Task
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Description { get; set; }

    }
  
}