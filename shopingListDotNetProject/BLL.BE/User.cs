using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public class User
    {
        public int UserId  { get; set; }
        public string Username { get; set; }

        public User(int userId, string username)
        {
            this.UserId = userId;
            this.Username = username;
        }

        public override bool Equals(object obj)
        {
            return obj is User user &&
                   UserId == user.UserId &&
                   Username == user.Username;
        }
    }

}
