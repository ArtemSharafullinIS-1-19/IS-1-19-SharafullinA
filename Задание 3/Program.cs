﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Задание_3
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
        class ConnBaza
        {
            public MySqlConnection ConnBaz(string connStr)
            {

                string port = "33333";
                string host = "caseum.ru";
                string user = "test_user";
                string password = "test_pass";
                string db = "db_test";
                connStr = $"server={host};port={port};user={user};database={db};password={password};";
                MySqlConnection conn = new MySqlConnection(connStr);
                return conn;
            }
        }
    }
}
