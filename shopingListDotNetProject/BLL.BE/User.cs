using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
    public class User
    {
        int userId { get; set; }
        string username { get; set; }

        public User(int userId, string username)
        {
            this.userId = userId;
            this.username = username;
        }
    }
}
