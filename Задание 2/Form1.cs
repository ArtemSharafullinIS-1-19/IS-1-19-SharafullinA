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
        class ConnToDB
        {
            public MySqlConnection ConnDB()
            {
                // строка подключения к БД
                string connStr = "server=caseum.ru;port=33333;user=test_user;database=db_test;password=test_pass;";
                // создаём объект для подключения к БД
                MySqlConnection conn = new MySqlConnection(connStr);
                return conn;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int x = 0;
            ConnToDB Conndb = new ConnToDB();
            try
            {
                Conndb.ConnDB().Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось подключится к базе данных.\nИсключение скопировано в буфер обмена.\n{ex.ToString()}", "Ошибка!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                Clipboard.SetDataObject(ex.ToString());
                x = 1;
            }
            finally
            {
                if (x == 1) { }
                else { MessageBox.Show("Подключение прошло успешно!", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                Conndb.ConnDB().Close();
            }
        }
    }
}
