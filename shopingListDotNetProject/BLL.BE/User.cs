using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public class User
    {
        public User()
        {
        }
        public int Id { get; set; }
        public int UserId  { get; set; }
        public string UserName { get; set; }

        public User(int userId, string username)
        {
            this.UserId = userId;
            this.UserName = username;
        }

        public User(string username)
        {
            UserName = username;
        }

        public override bool Equals(object obj)
        {
            return obj is User user &&
                   UserId == user.UserId &&
                   UserName == user.UserName;
        }
    }

}
