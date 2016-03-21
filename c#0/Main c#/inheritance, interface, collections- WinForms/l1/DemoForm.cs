using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace l1
{
    public partial class DemoForm : Form
    {
        public DemoForm()
        {
            InitializeComponent();
        }
        List<STR> s;

        private void button1_Click(object sender, EventArgs e)
        {
            int t = comboBox1.SelectedIndex;
            try
            {
                switch (t)
                {
                    case 0:
                        {
                            STR x = new STR();
                            s.Add(x);
                            break;
                        }
                    case 1:
                        {
                            Komp x = new Komp();
                            s.Add(x);
                            break;
                        }
                    case 2:
                        {
                            STR x = new STR(textBox1.Text.ToString());
                            s.Add(x);
                            break;
                        }
                    case 3:
                        {
                            if (textBox1.Text.Length != 1)
                                throw new FormatException("Символ!");
                            char m = textBox1.Text[0];
                            STR x = new STR(m);
                            s.Add(x);
                            break;
                        }
                    case 4:
                        {
                            int m = Int32.Parse(textBox1.Text);
                            int y = Int32.Parse(textBox2.Text);
                            Komp x = new Komp(m, y);
                            s.Add(x);
                            break;
                        }
                    case 5:
                        {
                            Komp x = new Komp(textBox1.Text.ToString());
                            s.Add(x);
                            break;
                        }
                }
            }
            catch (FormatException x)
            {
                MessageBox.Show(x.Message);
            }

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int t = comboBox1.SelectedIndex;
            button1.Visible = true;
            switch (t)
            {
                case 0:
                    {

                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox1.Visible = false;
                        textBox2.Visible = false;
                        break;
                    }
                case 1:
                    {
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox1.Visible = false;
                        textBox2.Visible = false;
                        break;
                    }
                case 2:
                    {
                        textBox1.Text = "Введите строку";
                        textBox2.Text = "";
                        textBox1.Visible = true;
                        textBox2.Visible = false;

                        break;
                    }
                case 3:
                    {
                        textBox1.Text = "Введите символ";
                        textBox2.Text = "";
                        textBox1.Visible = true;
                        textBox2.Visible = false;
                        break;
                    }
                case 4:
                    {
                        textBox1.Text = "Введите действительную часть";
                        textBox2.Text = "Введите мнимую часть";
                        textBox1.Visible = true;
                        textBox2.Visible = true;
                        break;
                    }
                case 5:
                    {
                        textBox1.Text = "Введите строку";
                        textBox2.Text = "";
                        textBox1.Visible = true;
                        textBox2.Visible = false;
                        break;
                    }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listBox1.Height = Height / 2;
            listBox1.Width = Width / 2;
            s = new List<STR>();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                button1.Enabled = false;
                comboBox1.Enabled = false;
                button2.Enabled = false;
                int[] j=new int[2];
                int k = 0;
                s.Sort();
                listBox1.Items.Add("Отсортировали");
                for (int i = 0; i < s.Count; i++)
                {
                    listBox1.Items.Add((i+1)+") "+s[i]);
                }
                for (int i = 0; i < s.Count; i++)
                {
                    if (s[i] is Komp)
                    {
                        j[k] = i;
                        k++;
                        if (k == 2)
                            break;
                    }
                }
                if (k == 2)
                {
                    listBox1.Items.Add("Сложили:" + s[j[0]] + " + " + s[j[1]] + "=" + ((s[j[0]] as Komp) + (s[j[1]] as Komp)));
                    listBox1.Items.Add("Перемножили:" + s[j[0]] + " * " + s[j[1]] + "=" + ((s[j[0]] as Komp) * (s[j[1]] as Komp)));
                }
                else
                    listBox1.Items.Add("Недостаточно чисел для операций");
                if (s.Count >= 2)
                {
                    listBox1.Items.Add(String.Format(" GetHashCode({0})={2}; GetHashCode({1})={3}", s[0], s[1], s[0].GetHashCode(), s[1].GetHashCode()));
                }
                if (s.Count > 1)
                {
                    listBox1.Items.Add(String.Format("{0}:GetLen()={1} ", s[s.Count - 1], s[s.Count - 1].GetLen()));
                    listBox1.Items.Add(String.Format("{0}:Equals({1})={2} ", s[0], s[1], s[0].Equals(s[1])));
                }
            }
            catch (Exception l)
            {
                MessageBox.Show(l.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            s.Clear();
            listBox1.Items.Clear();
            comboBox1.Enabled = true;
            comboBox1.Text = "Выберите, что добавить";
            button1.Enabled = true;
            button2.Enabled = true;
            textBox1.Visible=false;
            textBox2.Visible = false;
            button1.Visible = false;

        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            listBox1.Height=Height / 2;
            listBox1.Width = Width / 2;
        }
    }
}
