using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace pert5_50420221.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class UserDB
    {
        MySqlConnection conn;
        public UserDB(MySqlConnection conn)
        {
            this.conn = conn;
        }

        public void InsertUser(User user)
        {
            string createQuery = String.Format(
                "INSERT INTO users(username, password) VALUES('{0}', '{1}');",
                user.Username,
                user.Password
                );

            var comm = new MySqlCommand(createQuery, this.conn);
            this.conn.Open();
            comm.ExecuteNonQuery();
            this.conn.Close();
        }

        public User FindUserByUsername(string username)
        {
            User user = new User();
            try
            {
                string findQuery = String.Format(
                    "SELECT id, username, password FROM users WHERE username = '{0}';",
                    username
                    );
                this.conn.Open();
                var comm = new MySqlCommand(findQuery, this.conn);
                MySqlDataReader data = comm.ExecuteReader();

                if (data.HasRows)
                {
                    while(data.Read())
                    {
                        user.ID = Int32.Parse(data[0].ToString());
                        user.Username = data[1].ToString();
                        user.Password = data[2].ToString();
                    }
                }
                this.conn.Close();
                return user;
            }
            catch
            {
                return null;
            }
        }
    }
}