using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Migrations;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.ComponentModel.DataAnnotations.Schema;


namespace UserInputOutput.Models
{
    public class User
    {
        
       
        [Key]
        public int Id { get; set; }
        
        [Required]
        [Display(Name = "نام کاربری"), StringLength(15, MinimumLength = 1)]
        public string UserName { get; set; }
        
        [Required]
        [Display(Name = "نام")]
        public string Name { get; set; }
        
        [Required]
        [Display(Name = "نام خانوادگی")]
        public string Family { get; set; }
        
        [Required]
        [Display(Name = " رمز عبور"), StringLength(30, MinimumLength = 5)]
        public string Password { get; set; }
        
        
        [Display(Name = "آخرین رجوع")]
        public DateTime? LastLogin { get; set; }


        [Display(Name = "گروه")]
        public int UserGroupId { get; set; }
        [ForeignKey("UserGroupId")]
        public virtual UserGroup Group { get; set; }

       [Display(Name = "نوع کاربر")]
        public int UserTypeId { get; set; }
        [ForeignKey("UserTypeId")]
        public virtual UserType UserType { get; set; }
    }


    
}