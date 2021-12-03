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
        class ConnBaza
        {
            public MySqlConnection ConnBaz()
            {
                
                string port = "33333";
                string host = "caseum.ru";
                string user = "test_user";
                string password = "test_pass";
                string db = "db_test";
                string connStr = $"server={host};port={port};user={user};database={db};password={password};";
                MySqlConnection conn = new MySqlConnection(connStr);
                return conn; 
            }
        }
        private BindingSource bSource = new BindingSource();         
        private DataTable table = new DataTable();
        private MySqlDataAdapter adapter = new MySqlDataAdapter();

        private void button1_Click(object sender, EventArgs e)
        {
            ConnBaza conbaza = new ConnBaza();
            try
            {
                conbaza.ConnBaz().Open();
                string ConnSTR = "SELECT id AS 'ID', fio AS 'ФИО', theme_kurs AS 'Тема' FROM t_stud";
                MySqlDataAdapter adapter = new MySqlDataAdapter(ConnSTR, conbaza.ConnBaz());
                dataGridView1.Rows.Clear();
                dataGridView1.Rows.Clear();
                dataGridView1.Rows.Clear();
            }
            catch (Exception oshibka)
            {
                MessageBox.Show($"{oshibka}");
            }
            finally
            {
                MessageBox.Show("Вы успешно подключились к базе данных!");
                conbaza.ConnBaz().Close();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                MessageBox.Show(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
            }
            catch
            {
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
