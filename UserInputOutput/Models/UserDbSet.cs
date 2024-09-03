using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace UserInputOutput.Models
{
    public class UserDbSet:DbContext
    {
        public DbSet<TimeSheet> Hozors { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
    }
}