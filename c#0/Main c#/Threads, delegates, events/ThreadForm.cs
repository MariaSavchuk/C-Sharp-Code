using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Threading;
namespace Target
{
    public partial class ThreadForm : Form
    {
        /*Создать два класса «Вычислитель» и «Демонстратор», которые обмениваются между собой
         * сообщениями о наступивших событиях.
         * Вычислитель (при необходимости) случайным образом генерирует параметры, выполняет
         * вычисления (Числа Каталана), и генерирует событие «Вычисление завершено». После генерации
         * события Вычислитель «отдыхает» некоторое время (время отдыха передаётся в конструкторе
         * Вычислителя) и выполняет следующее вычисление.
         * Это событие обрабатывает Демонстратор, выводя результаты вычисления на форму в удобном
         * для чтения виде.
         * Демонстратор по команде пользователя генерирует событие «Прекратить вычисления»,
         * которое обрабатывается Вычислителем.
         * Класс «Демонстратор» также организует стрельбу по мишени.
         * Координаты выстрелов выбираются случайным образом. 
         * Задержка между выстрелами, а также размер мишени и максимальные
         * значения для координат выстрелов задаются в конструкторе Демонстратора.
         * Завершение стрельбы выполняется по команде пользователя. Если пользователь потребовал
         * прекратить стрельбу раньше, чем прекратить вычисления, необходимо:
         * выдать предупреждающее сообщение и игнорировать команду;
         * Работу Вычислителя и Демонстратора организовать в разных тредах.
         */
        public ThreadForm()
        {
            InitializeComponent();
        }
        public class G
        {
            public static Bitmap bit;
            public static Bitmap edial;
            public static Graphics graph;
            public static int J = 0;
            public static int Miss = 0;
            public static int Hit = 0;

        }
        public Demonstraror dem;
        public Calculator calc;
        public delegate void S(string s);
        public delegate void N(int n1,int n2,int n3);
        Thread Tcalc;
        Thread Tdem;
        private void button1_Click(object sender, EventArgs e)
        {
            Tcalc = new Thread(calc.Calculation);
            Tcalc.Start();
            button3.Enabled = true;
            Tdem = new Thread(dem.Shoot);
            Tdem.Start();
            button4.Enabled = true;
            button1.Enabled = false;

        }
        public void Show1(string s)
        {
            label4.Invoke(new S(update), new object[] { s });
        }
        private void update(string s)
        {
            label4.Text = s;
        }
        public void Shoot1(int x,int y)
        {
            x = pictureBox1.Width / 2+x;
            y = pictureBox1.Height / 2 + y;
            if ((G.edial.GetPixel(x, y).Equals(Color.FromArgb(0, 0, 0, 0)) || (G.edial.GetPixel(x, y).Equals(Color.FromArgb(255, 0, 0, 0)))))
            {
                G.graph.FillEllipse(new SolidBrush(Color.Green), x - 3, y - 3, 6, 6);
                G.Miss++;
            }
            else
            {
                G.graph.FillEllipse(new SolidBrush(Color.Red), x - 3, y - 3, 6, 6);
                G.Hit++;
            }
            G.J++;
            Invoke(new N(OK), new object[] { G.J, G.Hit, G.Miss });
        }
        private void OK(int x, int y, int z)
        {
            label1.Text = String.Format("Количество произведённых выстрелов " + x);
            label2.Text = String.Format("Попаданий " + y);
            label3.Text = String.Format("Промахов " + z);
            pictureBox1.Image = G.bit;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            dem.Stop();
            button3.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!Tcalc.IsAlive)
            {
                dem.Active = false;
                button4.Enabled = false;
            }
            else
                MessageBox.Show("Сначала нужно прекратить вычисления!");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                G.bit = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                G.graph = Graphics.FromImage(G.bit);
                int R = Int32.Parse(textBox1.Text);
                int time = Int32.Parse(textBox2.Text);
                int X = Int32.Parse(textBox3.Text);
                dem = new Demonstraror(Show1, Shoot1, time, R, X);
                calc = new Calculator(time, dem);
                dem.Calculator = calc;
                HatchBrush gr = new HatchBrush(HatchStyle.BackwardDiagonal, Color.DimGray, Color.Gray);
                int Y0 = pictureBox1.Height / 2;
                int X0 = pictureBox1.Width / 2;
                Rectangle p1 = new Rectangle(X0 - 2 * R, Y0, 2 * R, 2 * R);
                Rectangle p2 = new Rectangle(X0, Y0 - 2 * R, 2 * R, 2 * R);
                G.graph.FillPie(gr, p1, -45, -180);
                G.graph.FillPie(gr, p2, -45, 180);
                G.graph.DrawEllipse(new Pen(Color.DimGray), p1);
                G.graph.DrawEllipse(new Pen(Color.DimGray), p2);
                G.graph.DrawLine(new Pen(Color.Black), new Point(X0 - 2 * R, Y0 + 2 * R), new Point(X0 + 2 * R, Y0 - 2 * R));
                G.graph.DrawLine(new Pen(Color.Black), new Point(X0, Y0 * 2), new Point(X0, 0));
                G.graph.DrawLine(new Pen(Color.Black), new Point(X0 - 6, 6), new Point(X0, 0));
                G.graph.DrawLine(new Pen(Color.Black), new Point(X0 + 6, 6), new Point(X0, 0));
                G.graph.DrawLine(new Pen(Color.Black), new Point(2 * X0, Y0), new Point(0, Y0));
                G.graph.DrawLine(new Pen(Color.Black), new Point(2 * X0, Y0), new Point(2 * X0 - 6, Y0 - 6));
                G.graph.DrawLine(new Pen(Color.Black), new Point(2 * X0, Y0), new Point(2 * X0 - 6, Y0 + 6));
                G.edial = new Bitmap(G.bit);
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                button1.Enabled = true;
                button5.Enabled = false;
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
}
