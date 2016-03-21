using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace delegat
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Calculator calc; 
        private void Stop_Click(object sender, EventArgs e)
        {
            label2.Text=calc.Demonstrator.Stop();
            timer1.Enabled = false;
            Stop.Enabled = false;
        }
        private void Start_Click(object sender, EventArgs e)
        {
            try
            {
                int x = Int32.Parse(textBox1.Text.ToString());
                calc = new Calculator(x,new Show(Show1));
                timer1.Interval = calc.rest;
                timer1.Enabled = true;
                label2.Text = "Вычисления";
                Stop.Enabled = true;
            }
            catch(Exception l)
            {
                MessageBox.Show(l.Message);
            }
        }
         public void Show1(string x)
        {
          label2.Text = x;
        }
         private void timer1_Tick(object sender, EventArgs e)
         {
             calc.Calculation();
         }
    }
}