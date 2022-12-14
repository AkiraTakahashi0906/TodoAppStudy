using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace TodoApp.Models
{
    public class CoustomRoleProvider : RoleProvider
    {
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        //指定されたユーザーが所属するロールを配列で返す
        public override string[] GetRolesForUser(string username)
        {
            using(var db =new TodoesContext())
            {
                var user = db.Users.Where(x=>x.UserName==username).FirstOrDefault();
                if (user != null)
                {
                    //Select MAP
                    return user.Roles.Select(x => x.RoleName).ToArray();
                }
            }

            //ユーザーがヒットしなければ空の配列を返す。
            return new string[] {  };
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        //引数に指定されたユーザーが引数に指定されたロールに所属しているかどうか返すメソッド
        public override bool IsUserInRole(string username, string roleName)
        {
            string[] roles = this.GetRolesForUser(username);
            return roles.Contains(roleName);
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}