using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Library;
using MySql.Data.MySqlClient;

namespace Задание_4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        MySqlConnection conn;
        readonly string connStr = "server=caseum.ru;port=33333;user=test_user;database=db_test;password=test_pass;";
        // строка подключения к БД

        //DataAdapter представляет собой объект Command , получающий данные из источника данных.
         MySqlDataAdapter MyDA = new MySqlDataAdapter();
        //Объявление BindingSource, основная его задача, это обеспечить унифицированный доступ к источнику данных.
        BindingSource bSource = new BindingSource();
        //DataSet - расположенное в оперативной памяти представление данных, обеспечивающее согласованную реляционную программную 
        //модель независимо от источника данных.DataSet представляет полный набор данных, включая таблицы, содержащие, упорядочивающие 
        //и ограничивающие данные, а также связи между таблицами.
        DataTable table = new DataTable();

        //Метод наполнения виртуальной таблицы и присвоение её к датагриду
        public void GetListUsers()
        {
            table.Clear();
            //Запрос для вывода строк в БД
            string commandStr = "SELECT idStud AS 'Код', fioStud AS 'ФИО', " +
                "drStud AS 'Дата рождения' FROM t_datetime";
            //Открываем соединение
            conn.Open();
            //Объявляем команду, которая выполнить запрос в соединении conn
            MyDA.SelectCommand = new MySqlCommand(commandStr, conn);
            //Заполняем таблицу записями из БД
            MyDA.Fill(table);
            //Указываем, что источником данных в bindingsource является заполненная выше таблица
            bSource.DataSource = table;
            //Указываем, что источником данных ДатаГрида является bindingsource 
            dataGridView1.DataSource = bSource;
            //Закрываем соединение
            conn.Close();
        }

        void button1_Click(object sender, EventArgs e)
        {
           GetListUsers();
        }

        void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DateTime dateTime = new DateTime();
            dateTime = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[2].Value);
            MessageBox.Show(DateTime.Today.Subtract(dateTime.Date).Days.ToString(), "Дней от дня рождения", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        void Form1_Load(object sender, EventArgs e)
        {
            // создаём объект для подключения к БД
            conn = ConnBaza.ConnBaz(connStr);
            //Вызываем метод для заполнение дата Грида
            GetListUsers();

        }
    }
}
