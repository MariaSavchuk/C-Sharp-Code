using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
/*Мишень представляет собой область, закрашенную серым на рисунке,
 * соответствующем одному варианту. Требуется написать программу, которая
 * вводит значения радиусов мишени;
 * отображает мишень;
 * вводит информацию о количестве выстрелов;
 * вводит координаты попадания для каждого выстрела и отображает на
рисунке мишени точку попадания в поле;
 * рассчитывает количество промахов и количество попаданий в мишень
 * после каждого выстрела.
Предусмотреть обработку ошибочного ввода пользователя
 */
namespace Target
{
    public partial class ShotForm : Form
    {
        public ShotForm()
        {
            InitializeComponent();
            

        }
        public class G
        {
            public static  Bitmap bit;
            public static Graphics graph;
            public static int J = 0;
            public static int Miss = 0;
            public static int Hit = 0;
            
        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    G.bit = new Bitmap(drawPictureBox.Width, drawPictureBox.Height);
                    G.graph = Graphics.FromImage(G.bit);
                    int R = Int32.Parse(RadiusTextBox.Text);
                    HatchBrush gr = new HatchBrush(HatchStyle.BackwardDiagonal, Color.DimGray, Color.Gray);
                    int Y0 = drawPictureBox.Height / 2;
                    int X0 = drawPictureBox.Width / 2;
                    if ((R < 10) || (R > Y0 / 2))
                        throw new ArgumentException("Не больше экрана и не меньше хотя бы десяти!!");
                    Rectangle p1 = new Rectangle(X0 - 2 * R, Y0, 2 * R, 2 * R);
                    Rectangle p2 = new Rectangle(X0, Y0 - 2 * R, 2 * R, 2 * R);
                    G.graph.FillPie(gr, p1, -45, -180);
                    G.graph.FillPie(gr, p2, -45, 180);
                    G.graph.DrawEllipse(new Pen(Color.Black), p1);
                    G.graph.DrawEllipse(new Pen(Color.Black), p2);
                    G.graph.DrawLine(new Pen(Color.Black), new Point(X0 - 2 * R, Y0 + 2 * R), new Point(X0 + 2 * R, Y0 - 2 * R));
                    G.graph.DrawLine(new Pen(Color.Black), new Point(X0, Y0 * 2), new Point(X0, 0));
                    G.graph.DrawLine(new Pen(Color.Black), new Point(X0 - 6, 6), new Point(X0, 0));
                    G.graph.DrawLine(new Pen(Color.Black), new Point(X0 + 6, 6), new Point(X0, 0));
                    G.graph.DrawLine(new Pen(Color.Black), new Point(2 * X0, Y0), new Point(0, Y0));
                    G.graph.DrawLine(new Pen(Color.Black), new Point(2 * X0, Y0), new Point(2 * X0 - 6, Y0 - 6));
                    G.graph.DrawLine(new Pen(Color.Black), new Point(2 * X0, Y0), new Point(2 * X0 - 6, Y0 + 6));
                   int i,j;
                   for (i = j = Y0; (i > 10) && (j < 2 * Y0 - 10); i = i - 10, j = j + 10)
                   {
                       G.graph.DrawLine(new Pen(Color.Black), new Point(X0 - 3, i), new Point(X0 + 3, i));
                       G.graph.DrawLine(new Pen(Color.Black), new Point(X0 - 3, j), new Point(X0 + 3, j));
                   }
                    for (i = j = X0; (j > 10) && (i < 2 * X0 - 10); i = i + 10, j = j - 10)
                    {
                        G.graph.DrawLine(new Pen(Color.Black), new Point(i, Y0 - 3), new Point(i, Y0 + 3));
                        G.graph.DrawLine(new Pen(Color.Black), new Point(j, Y0 - 3), new Point(j, Y0 + 3));
                    }
                    drawPictureBox.Image = G.bit;
                    ShutsTextBox.Enabled = true;
                    RadiusTextBox.Enabled = false;
                    ShutsTextBox.Focus();
                }
                catch (FormatException x)
                {
                    MessageBox.Show(x.Message);
                }
                catch (ArgumentException y)
                {
                    MessageBox.Show(y.Message);
                }
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    int N = Int32.Parse(ShutsTextBox.Text);
                    if (N <= 0)
                        throw new ArgumentException("Хотя бы один выстрел");
                    
                    ShutsDataGridView.ColumnCount = 1;
                    ShutsDataGridView.RowCount = N ;
                    ShutsDataGridView.Columns[0].HeaderText = "Координаты выстрелов в формате (x,y)";
                    for(int i=0;i<N;i++)
                        ShutsDataGridView.Rows[i].HeaderCell.Value = String.Format("Выстрел " + (i + 1));
                    
                   ShutsDataGridView.Columns[0].Width = ShutsDataGridView.Width - ShutsDataGridView.RowHeadersWidth;

                    if (ShutsDataGridView.Height > ShutsDataGridView.RowTemplate.Height * (N+1) + ShutsDataGridView.ColumnHeadersHeight)
                        ShutsDataGridView.Height = ShutsDataGridView.RowTemplate.Height * (N+1) + ShutsDataGridView.ColumnHeadersHeight;
                    ShutsDataGridView.Visible = true;
                    ShutsTextBox.Enabled = false;
                    ShutsDataGridView.Focus();
                }
                catch (FormatException x)
                {
                    MessageBox.Show(x.Message);
                }
                catch (ArgumentException y)
                {
                    MessageBox.Show(y.Message);
                }
            }
        }
        private void dataGridView1_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            try
            {
                if ((G.J!=e.RowIndex)&&(G.J!=ShutsDataGridView.RowCount-1)&&(G.J!=ShutsDataGridView.RowCount))
                {
                    e.Value ="";
                    e.ParsingApplied = true;
                    //dataGridView1.CurrentCell = dataGridView1.Rows[G.J].Cells[0];
                    throw new ArgumentException("Вы ещё не совершили предыдущие выстрелы или выстрел уже произведён");

                }

                string s = e.Value.ToString();
                if ((s.Substring(0, 1) != "(") || (s.Substring(s.Length - 1, 1) != ")") || (s.Length < 5))
                {
                    
                    e.Value = "";
                    e.ParsingApplied = true;
                    ShutsDataGridView.CurrentCell = ShutsDataGridView.Rows[G.J].Cells[0];
                    throw new FormatException("Не верно введены координаты точки");
                }
                s = s.Remove(0, 1);
                s = s.Remove(s.Length - 1, 1);
                int i = s.IndexOf(",");
                int x = Int32.Parse(s.Substring(0, i));
                s = s.Remove(0, i + 1);
                int y = Int32.Parse(s);
                int Y0 = drawPictureBox.Height / 2;
                int X0 = drawPictureBox.Width / 2;
                x = x + X0;
                y = Y0 - y;
                if ((G.bit.GetPixel(x, y).Equals(Color.FromArgb(0, 0, 0, 0)) || (G.bit.GetPixel(x, y).Equals(Color.FromArgb(255, 0, 0, 0)))) || (G.bit.GetPixel(x, y).Equals(Color.FromArgb(255, 0, 128, 0))))
                {
                    G.graph.FillEllipse(new SolidBrush(Color.Green), x - 3, y - 3, 6, 6);
                    G.Miss++;
                    if (G.J == ShutsDataGridView.RowCount)
                    {
                        G.Miss = G.Miss - 1;
                    }
                }
                else
                {
                    G.graph.FillEllipse(new SolidBrush(Color.Red), x - 3, y - 3, 6, 6);
                    G.Hit++;
                    if (G.J == ShutsDataGridView.RowCount)
                    {
                        G.Hit = G.Hit - 1;
                    }
                }
                G.J++;
                drawPictureBox.Image = G.bit;
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                if (G.J== ShutsDataGridView.RowCount)
                {
                    ShutsDataGridView.Enabled = false;
                    MessageBox.Show("Конец!");
                }
                if (G.J - 1 == ShutsDataGridView.RowCount)
                    G.J--;
                label1.Text = String.Format("Количество произведённых выстрелов "+G.J);
                label2.Text = String.Format("Попаданий "+G.Hit);
                label3.Text = String.Format("Промахов "+G.Miss);
                
            }
            catch (FormatException z)
            {
                MessageBox.Show(z.Message);
            }
            catch (ArgumentException z1)
            {
                MessageBox.Show(z1.Message);
            }
    
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (G.graph != null)
            {
                G.graph.Clear(Color.White);
                drawPictureBox.Image = G.bit;
                ShutsDataGridView.CurrentCell = ShutsDataGridView.Rows[0].Cells[0];
            }
            G.J = G.Miss = G.Hit = 0;
            label1.Visible = label2.Visible = label3.Visible = false;
            ShutsDataGridView.Enabled = true;
            ShutsDataGridView.Visible = false;
            for (int i = 0; i < ShutsDataGridView.RowCount; i++)
                ShutsDataGridView.Rows[i].Cells[0].Value = "";
            RadiusTextBox.Text = "Введите радиус";
            RadiusTextBox.Enabled = true;
            RadiusTextBox.Focus();
            ShutsTextBox.Text = "Введите количество выстрелов";

        }


    }
}
