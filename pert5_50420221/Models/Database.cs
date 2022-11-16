using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace pert5_50420221.Models
{
    public class Database
    {
        public static MySqlConnection Connection()
        {
            string connString = "server=localhost;port=3306;username=root;password=;database=pert5_50420221;";
            return new MySqlConnection(connString);
        }
    }
}