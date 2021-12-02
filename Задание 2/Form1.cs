using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Задание_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
         class MySqlConnect
        {

            public MySqlConnection ConnDB()
            {
                string connStr = "server=caseum.ru;port=33333;user=test_user;database=db_test;password=test_pass;";
                MySqlConnection conn = new MySqlConnection(connStr);
                return conn;
            }
            public static string host = "caseum.ru";
            public static string port = "33333";
            public static string user_id = "test_user";
            public static string database = "db_test";
            public static string password = "test_pass";


            public static string SqlConnect()
                {
                    string conn = $"server={host};port={port};user={user_id};database={database};password={password}";
                    return conn;
                }
            }

            private void button1_Click(object sender, EventArgs e)
            {
                MySqlConnection conec = new MySqlConnection(MySqlConnect.SqlConnect());
                try
                {
                    conec.Open();
                    MessageBox.Show("Подключение произшло успешно!");
                }
                catch
                {
                    MessageBox.Show("При подключении произошла ошибка!");
                    conec.Close();
                }
            }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}   
