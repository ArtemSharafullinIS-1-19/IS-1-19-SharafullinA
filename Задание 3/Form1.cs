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

namespace Задание_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        MySqlConnection conn;

        string connStr = "server=caseum.ru;port=33333;user=test_user;database=db_test;password=test_pass;";
        private MySqlDataAdapter MyDA = new MySqlDataAdapter();
        private BindingSource bSource = new BindingSource();
        private DataSet ds = new DataSet();
        private DataTable table = new DataTable();

        public async void GetListUsers()
        {
            int x = 0;
            while (x != 1000000)
            {
                table.Clear();
                x++;
                string commandStr = "SELECT id AS 'Код', fio AS 'ФИО', " +
                    "theme_kurs AS 'Тема курсовой' FROM t_stud";
                conn.Open();
                MyDA.SelectCommand = new MySqlCommand(commandStr, conn);
                MyDA.Fill(table);
                bSource.DataSource = table;
                dataGridView1.DataSource = bSource;
                conn.Close();
                await Task.Delay(1500);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            conn = new MySqlConnection(connStr);
            GetListUsers();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString(), "ФИО студента", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
