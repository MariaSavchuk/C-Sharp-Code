using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace motion
{
    public partial class DialogForm : Form
    {

        public DialogForm()
        {
            InitializeComponent();
            
            
        }
        private class TriangleParams
        {
           public static int speed;
           public static int Z;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                TriangleParams.Z = (int)numericUpDown1.Value;
                MotionForm motionForm = this.Owner as MotionForm;
                TriangleParams.speed = trackBar1.Value;
                if ((TriangleParams.speed != 0) && (TriangleParams.Z != 0))
                {
                    motionForm.drawTriangle(100, TriangleParams.Z, TriangleParams.speed);
                    motionForm.changeParams(colorDialog1.Color, colorDialog2.Color);
                    Close();
                }
                else
                    throw new ArgumentException("Введите данные");
            }
            catch(ArgumentException x)
            {
                MessageBox.Show(x.Message);
            }
        }
        public void New()
        {
            numericUpDown1.Value = numericUpDown1.Minimum;
            trackBar1.Value = 0;
            colorDialog1.Color = Color.Black;
            colorDialog2.Color = Color.Black;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            colorDialog2.ShowDialog();
        }
    }
}
