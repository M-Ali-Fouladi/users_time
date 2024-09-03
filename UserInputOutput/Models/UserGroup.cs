using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace UserInputOutput.Models
{
    public class UserGroup
    {
        [Key]
        public int UserGroupId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UserCreated { get; set; }
        public DateTime ModifiedDate { get; set; }
        

    }
   
}