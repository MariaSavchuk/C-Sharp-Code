using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Tag
{
    public partial class TagForm : Form
    {
        public TagForm()
        {
            InitializeComponent();
        }
        Tab T;
        private void how()
        {
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                {
                    TagDataGridView.Rows[i].Cells[j].Style.BackColor = Color.DarkSeaGreen;
                    TagDataGridView.Rows[i].Cells[j].Style.SelectionBackColor = Color.DarkSeaGreen;
                    TagDataGridView.Rows[i].Cells[j].Value = T.Table[i, j];

                }
            
            TagDataGridView.Rows[T.nullR].Cells[T.nullC].Value = "";
            TagDataGridView.Rows[T.nullR].Cells[T.nullC].Style.BackColor = Color.YellowGreen;
            TagDataGridView.Rows[T.nullR].Cells[T.nullC].Style.SelectionBackColor = Color.YellowGreen;
            MovesLabel.Text = String.Format("Количество ходов: " + T.col);
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            TagDataGridView.ColumnCount = 4;
            TagDataGridView.RowCount = 4;
            TagDataGridView.DefaultCellStyle.SelectionBackColor = Color.DarkSeaGreen;
            TagDataGridView.DefaultCellStyle.ForeColor = Color.DarkGreen;
            TagDataGridView.DefaultCellStyle.SelectionForeColor = Color.DarkGreen;
            for (int i = 0; i < 4; i++)
                TagDataGridView.Columns[i].Width = 100;
            T = new Tab();
            MovesLabel.Text = String.Format("Количество ходов: "+T.col);
            how();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            int i = e.RowIndex;
            int j = e.ColumnIndex;
            T.Change(i, j);
            how();
            if (T.Yes())
            {
                MessageBox.Show("Конец!\n" + "Количество ходов: " + T.col);
                MovesLabel.Enabled = false;
                TagDataGridView.Enabled = false;
            }
        }

        private void NewGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MovesLabel.Enabled = true;
            TagDataGridView.Enabled = true;
            T.NewGame();
            MovesLabel.Text = String.Format("Количество ходов" + T.col);
            how();
        }

        private void RecoverGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MovesLabel.Enabled = true;
            TagDataGridView.Enabled = true;
            T.Restart();
            MovesLabel.Text = String.Format("Количество ходов" + T.col);
            how();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void RoulsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" Необходимо упорядочить клетки по номерам, сделав как можно меньше перемещений! ");
        }


    }
}
