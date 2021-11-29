using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IS_1_19_SharafullinAA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        { }
            abstract class Detalis
        {
            public int stoimost;
            public int god;
            public abstract void Info(ListBox l);
            public Detalis(int stoimostt, int godd)
            {
                stoimost = stoimostt;
                god = godd;
            }
        }
        class CP : Detalis
        {
            public int yadra;
            public int potoki;
            public int chastota;
            public override void Info(ListBox l)
            {
                l.Items.Add($"Стоимость - {stoimost}, Год выпуска - {god}, Колличество ядер - {yadra}, Колличество потоков - {potoki}, Частота процессора - {chastota}");
            }
            public CP(int yadraa, int potokii, int chastotaa, int stoimost, int god) : base(god, stoimost)
            {
                yadra = yadraa;
                potoki = potokii;
                chastota = chastotaa;
            }
        }
        class Videocarta : Detalis
        {
            public int chastota_GPU;
            public int moshnost;
            public int pamyat;
            public override void Info(ListBox l)
            {
                l.Items.Add($"Частота видеокарты - {chastota_GPU}, Производительность - {moshnost}, Обьем памяти - {pamyat}, Стоимость - {stoimost}, Год выпуска - {god}");
            }
            public Videocarta(int chastotaGPUU, int moshnostt, int pamyatt, int stoimost, int god) : base(god, stoimost)
            {
                chastota_GPU = chastotaGPUU;
                moshnost = moshnostt;
                pamyat = pamyatt;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CP sot = new CP(6, 6, 29, 2018, 11000);
            sot.Info(listBox1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Videocarta sot = new Videocarta(16, 23000, 6, 2018, 20000);
            sot.Info(listBox1);
        }
}   } 
