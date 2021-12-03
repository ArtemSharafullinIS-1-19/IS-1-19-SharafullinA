using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace Задние_3
{
    public partial class Form1 : Form
    {
        static class DBUtils
        {
            public static MySqlConnection GetDBConnection()
            {
                string host = "caseum.ru";
                string port = "33333";
                string database = "db_test";
                string username = "test_user";
                string password = "test_pass";
                string connString = $"server={host};port={port};user={username};database={database};password={password};";
                MySqlConnection conn = new MySqlConnection(connString);
                return conn;
            }
        }
        static class GetData
        {
            static public void SelectStudents(ListBox lv, MySqlConnection conn)
            {
                lv.Items.Clear();
                conn.Open();
                string sql = $"SELECT * FROM t_prep";
                MySqlCommand command = new MySqlCommand(sql, conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    string id_prepods = reader[0].ToString();
                    string name_prepods = reader[1].ToString();
                    string dolg_prepods = reader[2].ToString();
                    lv.Items.Add($"{id_prepods}) {name_prepods} - {dolg_prepods}");
                }

                reader.Close();
                conn.Close();
            }
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            MySqlConnection cnt = DBUtils.GetDBConnection();
            GetData.SelectStudents(listBox1, cnt);
        }
    }
}
