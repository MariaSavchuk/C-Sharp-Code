using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace Дурак
{
    public partial class MyForm : Form
    {
        public MyForm()
        {
            InitializeComponent();
        }
        int  par=5,k=1,b=1;
        private void YesButton_Click(object sender, EventArgs e)
        {
            label2.Visible = true;
            label2.Text = "Понятно:)";
            YesButton.Visible = false;
            NoButton.Visible = false;
            label1.Visible = false;
            controlTextBox.Visible = false;
        }
        private void MyForm_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Alt)&&(k!=0))
            {
                controlTextBox.Visible = true;
                controlTextBox.Focus();
            }
        }

        private void NoButton_Click(object sender, EventArgs e)
        {
            label2.Visible = true;
            label2.Text = "Молодец!";
            YesButton.Visible = false;
            NoButton.Visible = false;
            controlTextBox.Visible = false;
            label1.Visible = false;
        }

        private void cntrolTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (controlTextBox.Text.Equals("Нет"))
                {
                    k = 0;
                    b = 0;
                    e.SuppressKeyPress = true;
                    controlTextBox.Visible = false;
                }
            }
        }

        private void MyForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (NoButton.Location.X - par <= 0)
            {
                NoButton.Location = new Point(NoButton.Location.X + par+NoButton.Width, NoButton.Location.Y);
            }
            if (NoButton.Location.X + par >= this.Width - NoButton.Width)
            {
                NoButton.Location = new Point(NoButton.Location.X - par-NoButton.Width, NoButton.Location.Y);
            }
            if (NoButton.Location.Y - par <= 0)
            {
                NoButton.Location = new Point(NoButton.Location.X, NoButton.Location.Y + par+NoButton.Height);
            }
            if (NoButton.Location.Y + par >= this.Height -  NoButton.Height-15)
            {
                NoButton.Location = new Point(NoButton.Location.X, NoButton.Location.Y - par-NoButton.Height);
            }
            int Xm = e.Location.X;
            int Ym = e.Location.Y;
            int X = NoButton.Location.X;
            int Y = NoButton.Location.Y;
            int W = NoButton.Width;
            int H = NoButton.Height;
            if (((Math.Abs(X - Xm) <= par) && (Math.Abs(Y - par) <= Ym) && (Ym <= Y + H)) || ((Math.Abs(Ym - Y - H) <= par) && (Math.Abs(X - par) <= Xm) && (Xm <= X + W)) || ((Math.Abs(Xm - X - W) <= par) && (Math.Abs(Y - par) <= Ym) && (Ym <= Y + H)) || ((Math.Abs(Y - Ym) <= par) && (Math.Abs(X - par) <= Xm) && (Xm <= X + W)))
            {
                if ((Xm <= X) && (Ym <= Y))
                {
                    NoButton.Location = new Point(NoButton.Location.X + k, NoButton.Location.Y + b);
                }
                if ((Xm <= X) && (Ym >= Y) && (Ym <= Y + H))
                {
                    NoButton.Location = new Point(NoButton.Location.X + k, NoButton.Location.Y);
                }
                if ((Xm <= X) && (Ym >= Y + H))
                {
                    NoButton.Location = new Point(NoButton.Location.X + k, NoButton.Location.Y - b);
                }
                if ((Xm >= X) && (Xm <= X + W) && (Ym >= Y + H))
                {
                    NoButton.Location = new Point(NoButton.Location.X, NoButton.Location.Y - b);
                }
                if ((Xm >= X + W) && (Ym >= Y + H))
                {
                    NoButton.Location = new Point(NoButton.Location.X - k, NoButton.Location.Y - b);
                }
                if ((Xm >= X + W) && (Ym >= Y) && (Ym <= Y + H))
                {
                    NoButton.Location = new Point(NoButton.Location.X - k, NoButton.Location.Y);
                }
                if ((Xm >= X + W) && (Ym <= Y))
                {
                    NoButton.Location = new Point(NoButton.Location.X - k, NoButton.Location.Y + b);
                }
                if ((Xm >= X) && (Xm <= X + W) && (Ym <= Y))
                {
                    NoButton.Location = new Point(NoButton.Location.X, NoButton.Location.Y + b);
                }
            }
        }

        private void NoButton_Enter(object sender, EventArgs e)
        {
            if (k != 0)
            {
                YesButton.Focus();
            }
        }

        private void NoButton_MouseMove(object sender, MouseEventArgs e)
        {
            NoButton.Location = new Point(NoButton.Location.X + k, NoButton.Location.Y + b);
        }
    }
}
    