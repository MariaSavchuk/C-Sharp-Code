using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
namespace motion
{
 /*
    Разработать приложение, использующее диалоговые панели, меню, стандартные органы управления следующим образом:
  * фигура движется по фигуре;
  * progress bar отображает объем процесса движения;
  * в диалоговом окне выбираются параметры:
  * spin (NumericUpDown) задает размер движущейся фигуры;
  * slider (TrackBar) задает скорость движения фигуры по окружности;один ColorDialog задает цвет контура фигуры, другой – цвет заливки;
  * меню обеспечивает выбор New, Open, Save.
  * Для Open и Save - Serialize.
  */

    public partial class MotionForm : Form
    {
        
        private DialogForm dialog_form = new DialogForm();
        
        private class G
        {   
            public static int Z = 0;
            public static Bitmap bit;
            public static Graphics graph;
            public static double Factor = 0;
            public static Color Border;
            public static Color Fill;
            public static int Speed;
        }
        [Serializable()]
        public class PictureParams
        {
            public Color bord;
            public Color fill;
            public  int Z = 0;
            public int speed;
        }
        public MotionForm()
        {
            InitializeComponent();
            AddOwnedForm(dialog_form);
            saveToolStripMenuItem1.Enabled=false;
        }
        private void dialogBoxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dialog_form.ShowDialog();
        }
        public void drawTriangle(int R,int Z,int speed)
        {
                motionPictureBox.Refresh();
                timer.Interval = 200 / speed;
                G.Speed = speed;
                //G.bit1 = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                //G.bit1 = new Bitmap(Z, Z);
                G.bit = new Bitmap(motionPictureBox.Width, motionPictureBox.Height);
                //G.graph = pictureBox1.CreateGraphics();
                G.graph=Graphics.FromImage(G.bit);
                 //G.graph1=Graphics.FromImage(G.bit1);

                int X0 = motionPictureBox.Width / 2;
                int Y0 = motionPictureBox.Height / 2;
                GraphicsPath my = new GraphicsPath();
                double H=Z*(Math.Pow(3,0.5))/2;
                my.AddLine(new Point(X0, Y0 - R), new Point((int)(X0 + Z/2), (int)(Y0 - R + H)));
                my.AddLine(new Point((int)(X0 + Z/2), (int)(Y0 - R + H)), new Point((int)(X0 - Z/2), (int)(Y0 - R + H)));
                my.AddLine(new Point((int)(X0 - Z / 2), (int)(Y0 + Z * H)), new Point(X0 , Y0 -R));
                /*
                my.AddLine(new Point((int)(Z/2), 0), new Point(Z, (int)H));
                my.AddLine(new Point(Z, (int)H), new Point(0, (int)H));
                my.AddLine(new Point(0, (int)H), new Point((int)(Z / 2), 0));
                */
 
               // G.graph.DrawImage(G.bit1, X0-Z/2, Y0-R);
                G.graph.DrawEllipse(new Pen(Color.Black, 5), X0 - R, Y0 - R, 2 * R, 2 * R);
                G.graph.DrawPath(new Pen(G.Border, 4), my);
                G.graph.FillPath(new SolidBrush(G.Fill), my);
                motionPictureBox.Image = G.bit;
                G.Z = Z;
                timer.Enabled = true;
                proccesProgressBar.Maximum = 126;
                proccesProgressBar.Value = 0;
                G.Factor = 0;
                saveToolStripMenuItem1.Enabled = true;
        }
        public void changeParams(Color X,Color Y)
        {
            G.Border = X;
            G.Fill = Y;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {

            G.Factor = G.Factor + 0.05;
            int X0 = motionPictureBox.Width / 2;
            int Y0 = motionPictureBox.Height / 2;
          //  G.bit1.MakeTransparent(Color.White);
            //G.bit.MakeTransparent(Color.White);
            G.graph.Clear(Color.White);
            int R = 100;
            int X = (int)(R * (Math.Sin(G.Factor)));
            int Y;
            if ((G.Factor - ((int)(G.Factor / (2 * Math.PI))) * (2 * Math.PI) > Math.PI / 2) && (G.Factor - ((int)(G.Factor / (2 * Math.PI))) * (2 * Math.PI) < 3 * Math.PI / 2))
                Y = (int)(-Math.Pow(R * R - X * X, 0.5));
            else
                Y = (int)Math.Pow(R * R - X * X, 0.5);
            
            double H = G.Z * (Math.Pow(3, 0.5)) / 2;
            GraphicsPath my= new GraphicsPath();
            my.AddLine(new Point(X0+X, Y0 -Y), new Point((int)(X0+X + G.Z/2), (int)(Y0 + H-Y)));
            my.AddLine(new Point((int)(X0 + G.Z/2+X), (int)(Y0 + H-Y)), new Point((int)(X0 - G.Z/2+X), (int)(Y0+ H-Y)));
            my.AddLine(new Point((int)(X0 - G.Z/2 + X),(int)( Y0 + H - Y)), new Point(X0 + X, Y0 - Y));
            // G.bit1.MakeTransparent(Color.White);
           // G.bit1.MakeTransparent(Color.Green);
            G.graph.DrawEllipse(new Pen(Color.Black, 5), X0 - R, Y0 - R, 2 * R, 2 * R);
            G.graph.FillPath(new SolidBrush(G.Fill), my);
            G.graph.DrawPath(new Pen(G.Border,4), my);
            /*
            GraphicsPath my = new GraphicsPath();
            my.AddLine(new Point((int)(G.Z / 2), 0), new Point(G.Z, (int)H));
            my.AddLine(new Point(G.Z, (int)H), new Point(0, (int)H));
            my.AddLine(new Point(0, (int)H), new Point((int)(G.Z / 2), 0));
            
            G.graph1.DrawPath(new Pen(G.Border, 4), my);
            G.graph1.FillPath(new SolidBrush(G.Fill), my); 
            G.graph.DrawImage(G.bit1, X0+X-G.Z/2, Y0-Y);
            */
            //G.bit1.MakeTransparent(Color.White);
           
            
            motionPictureBox.Image = G.bit;
            if (proccesProgressBar.Value == proccesProgressBar.Maximum)
                proccesProgressBar.Value = 0;
            else
                proccesProgressBar.Value++;
           

        }

        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            saveFileDialog.ShowDialog();
           // const string file = saveFileDialog1.FileName(;
            
             FileStream fs = (FileStream)saveFileDialog.OpenFile();// new FileStream(file, FileMode.OpenOrCreate);
             BinaryFormatter serializer = new BinaryFormatter();
             PictureParams x = new PictureParams();
             x.fill = G.Fill;
             x.bord = G.Border;
             x.Z = G.Z;
             x.speed = G.Speed;
             serializer.Serialize(fs, x);
             fs.Close();

             
        }

        private void openToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    BinaryFormatter dserializer = new BinaryFormatter();
                    PictureParams y = new PictureParams();
                    FileStream fc = (FileStream)openFileDialog.OpenFile();
                    y = (PictureParams)dserializer.Deserialize(fc);
                    drawTriangle(100, y.Z, y.speed);
                    changeParams(y.bord, y.fill);
                    fc.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка чтения");
            }
            
              
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
