using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Security;

namespace TodoApp.Models
{
    public class CustomMembershipProvider : MembershipProvider
    {
        public override bool EnablePasswordRetrieval => throw new NotImplementedException();

        public override bool EnablePasswordReset => throw new NotImplementedException();

        public override bool RequiresQuestionAndAnswer => throw new NotImplementedException();

        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override int MaxInvalidPasswordAttempts => throw new NotImplementedException();

        public override int PasswordAttemptWindow => throw new NotImplementedException();

        public override bool RequiresUniqueEmail => throw new NotImplementedException();

        public override MembershipPasswordFormat PasswordFormat => throw new NotImplementedException();

        public override int MinRequiredPasswordLength => throw new NotImplementedException();

        public override int MinRequiredNonAlphanumericCharacters => throw new NotImplementedException();

        public override string PasswordStrengthRegularExpression => throw new NotImplementedException();

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(string username, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override string GetUserNameByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override bool UnlockUser(string userName)
        {
            throw new NotImplementedException();
        }

        public override void UpdateUser(MembershipUser user)
        {
            throw new NotImplementedException();
        }

        //認証機能をつかさどる
        public override bool ValidateUser(string username, string password)
        {
            using(var db = new TodoesContext())
            {
                var hash = this.GeneratePasswordHash(username, password);
                //FirstOrDefault リストの一番先頭OR　NULLを返す
                var user = db.Users.Where(x=>x.UserName == username && x.Password == hash).FirstOrDefault();
                if (user != null)
                {
                    return true;
                }
            }

            //todo 後で削除
            //if ("administrator".Equals(username) && "password".Equals(password))
            //{
            //    return true;
            //}

            return false;
        }

        //PBKDF2 RFC2898
        //レインボーテーブル攻撃　ソルト　ストレッチング
        public string GeneratePasswordHash(string username,string password)
        {
            //ソルトを作成
            string rawSalt = $"secret_{username}";

            //インスタンス化
            var sha256=  new SHA256CryptoServiceProvider();
            //バイトの配列に変換して渡す
            var salt = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(rawSalt));

            //ストレッチング10000回
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);

            //ハッシュを取得
            var hash = pbkdf2.GetBytes(32);
            return Convert.ToBase64String(hash);
        }
    }
}