﻿using System;
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
        abstract class Komplektaciya<art>
        {
            protected int stoimost;
            protected string god;
            protected art artikul;
            public Komplektaciya(int stoimostt, string godd, art artikull)
            {
                stoimost = stoimostt;
                god = godd;
                artikul = artikull;
            }
            public abstract void Display(ListBox lb);
        }
        class CP : Komplektaciya<string>
        {
            double chastota;
            int yadro;
            int potoki;
            public CP(int stoimostt, string godd, string artikull, double chastotaa, int yadroo, int potokii)
                : base(stoimostt, godd, artikull)
            {
                chastota = chastotaa;
                yadro = yadroo;
                potoki = potokii;
            }
            public double chastotaa { get { return chastotaa; } set { chastotaa = value; } }
            public int yadroo { get { return yadroo; } set { yadroo = value; } }
            public int potokii { get { return potokii; } set { potokii = value; } }

            public override void Display(ListBox listBox1)
            {
                listBox1.Items.Add($"Цена - {stoimost}, Год выпуска - {god}, Арктикул - {artikul}, частота - {chastota}, Число ядер - {yadro}, Число потоков - {potoki}");
            }
        }
        class Videokartachka : Komplektaciya<string>
        {
            double chastota;
            string firma;
            int pamyat;
            public Videokartachka(int stoimostt, string godd, string artikull, double chastotaa, string firmaa, int pamyatt)
                : base(stoimostt, godd, artikull)
            {
                chastota = chastotaa;
                firma = firmaa;
                pamyat = pamyatt;
            }
             public double chastotaa { get { return chastotaa; } set { chastotaa = value; } }
            public string firmaa { get { return firmaa; } set { firmaa = value; } }
            public int pamyatt { get { return pamyatt; } set { pamyatt = value; } }

            public override void Display(ListBox listBox1)
            {
             listBox1.Items.Add($"Цена: {stoimost}, год Выпуска: {god}, арктикул: {artikul}, частота GPU: {chastota}, производитель: {firma}, объём Памяти {pamyat}");

            }
        }
        CP cp;
        Videokartachka GPU;

        void button1_Click(object sender, EventArgs e)
        {
           int stoimostt = Convert.ToInt32(textBox1.Text);
           string godd = textBox2.Text;
           double chastotaa = Convert.ToDouble(textBox3.Text);
           int yadroo = Convert.ToInt32(textBox4.Text);
           int potokii = Convert.ToInt32(textBox5.Text);
           string artikull = textBox9.Text;
           cp = new CP(stoimostt, godd, artikull, chastotaa, yadroo, potokii);
           cp.Display(listBox1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
             int stoimostt = Convert.ToInt32(textBox1.Text);
             string godd = textBox2.Text;
            double chastotaa = Convert.ToDouble(textBox6.Text);
             string firmaa = textBox7.Text;
             int pamyatt = Convert.ToInt32(textBox8.Text);
            string artikull = textBox9.Text;
             GPU = new Videokartachka(stoimostt, godd, artikull, chastotaa, firmaa, pamyatt);
             GPU.Display(listBox1);
        }


        private void textBox1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Цена")
                textBox1.Text = "";
        }
        private void textBox2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "Год Выпуска")
                textBox2.Text = "";
        }
        private void textBox3_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "Частота")
                textBox3.Text = "";
        }
        private void textBox4_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == "Количество ядер")
                textBox4.Text = "";
        }
        private void textBox5_Click(object sender, EventArgs e)
        {
            if (textBox5.Text == "Количество потоков")
                textBox5.Text = "";
        }
        private void textBox6_Click(object sender, EventArgs e)
        {
            if (textBox6.Text == "Частота GPU")
                textBox6.Text = "";
        }
        private void textBox7_Click(object sender, EventArgs e)
        {
            if (textBox7.Text == "Производитель")
                textBox7.Text = "";
        }
        private void textBox8_Click(object sender, EventArgs e)
        {
            if (textBox8.Text == "Объём Памяти")
                textBox8.Text = "";
        }
        private void textBox9_Click(object sender, EventArgs e)
        {
            if (textBox9.Text == "Артикул")
                textBox9.Text = "";
        }
}   } 