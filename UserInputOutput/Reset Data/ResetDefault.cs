using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using UserInputOutput.Models;

namespace UserInputOutput.Helper
{
    internal sealed class ResetDefault : DropCreateDatabaseIfModelChanges<UserInputOutput.Models.UserDbSet>
    {
      

        protected override void Seed(UserInputOutput.Models.UserDbSet context)
        {
            var userType = new List<UserType>
                {
                    new UserType  {UserTypeId=1,Name="Admin",Description="FullAccess",UserCreated=DateTime.Now,ModifiedDate=DateTime.Now,CreatedDate=DateTime.Now}
                };
            userType.ForEach(
                q => context.UserTypes.Add(q)
                );
            context.SaveChanges();
            var userGroup = new List<UserGroup>
                {
                    new UserGroup  {UserGroupId=1,UserCreated=DateTime.Now,Name="Everyone",ModifiedDate=DateTime.Now,Description="FullAccess",CreatedDate=DateTime.Now}
                };
            userGroup.ForEach(
                q =>  context.UserGroups.Add(q)
                );
            context.SaveChanges();

        }
    }
}