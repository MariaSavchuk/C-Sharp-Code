namespace Target
{
    partial class ShotForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.drawPictureBox = new System.Windows.Forms.PictureBox();
            this.RadiusTextBox = new System.Windows.Forms.TextBox();
            this.ShutsTextBox = new System.Windows.Forms.TextBox();
            this.ShutsDataGridView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.RedoButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.drawPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShutsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // drawPictureBox
            // 
            this.drawPictureBox.BackColor = System.Drawing.Color.White;
            this.drawPictureBox.Location = new System.Drawing.Point(481, 68);
            this.drawPictureBox.Name = "drawPictureBox";
            this.drawPictureBox.Size = new System.Drawing.Size(410, 325);
            this.drawPictureBox.TabIndex = 1;
            this.drawPictureBox.TabStop = false;
            // 
            // RadiusTextBox
            // 
            this.RadiusTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RadiusTextBox.ForeColor = System.Drawing.SystemColors.Highlight;
            this.RadiusTextBox.Location = new System.Drawing.Point(40, 68);
            this.RadiusTextBox.Name = "RadiusTextBox";
            this.RadiusTextBox.Size = new System.Drawing.Size(168, 29);
            this.RadiusTextBox.TabIndex = 2;
            this.RadiusTextBox.Text = "Введите радиус";
            this.RadiusTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // ShutsTextBox
            // 
            this.ShutsTextBox.Enabled = false;
            this.ShutsTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ShutsTextBox.ForeColor = System.Drawing.SystemColors.Highlight;
            this.ShutsTextBox.Location = new System.Drawing.Point(40, 130);
            this.ShutsTextBox.Name = "ShutsTextBox";
            this.ShutsTextBox.Size = new System.Drawing.Size(219, 22);
            this.ShutsTextBox.TabIndex = 3;
            this.ShutsTextBox.Text = "Введите количество выстрелов";
            this.ShutsTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox2_KeyDown);
            // 
            // ShutsDataGridView
            // 
            this.ShutsDataGridView.AllowUserToAddRows = false;
            this.ShutsDataGridView.AllowUserToDeleteRows = false;
            this.ShutsDataGridView.AllowUserToResizeColumns = false;
            this.ShutsDataGridView.AllowUserToResizeRows = false;
            this.ShutsDataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.ShutsDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.ShutsDataGridView.ColumnHeadersHeight = 25;
            this.ShutsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ShutsDataGridView.DefaultCellStyle = dataGridViewCellStyle1;
            this.ShutsDataGridView.EnableHeadersVisualStyles = false;
            this.ShutsDataGridView.Location = new System.Drawing.Point(27, 264);
            this.ShutsDataGridView.MultiSelect = false;
            this.ShutsDataGridView.Name = "ShutsDataGridView";
            this.ShutsDataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ShutsDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.ShutsDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.ShutsDataGridView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ShutsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.ShutsDataGridView.Size = new System.Drawing.Size(383, 226);
            this.ShutsDataGridView.TabIndex = 4;
            this.ShutsDataGridView.Visible = false;
            this.ShutsDataGridView.CellParsing += new System.Windows.Forms.DataGridViewCellParsingEventHandler(this.dataGridView1_CellParsing);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.SteelBlue;
            this.label1.Location = new System.Drawing.Point(478, 412);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(209, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Количество произведённых выстрелов:";
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.SteelBlue;
            this.label2.Location = new System.Drawing.Point(478, 446);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Попаданий:";
            this.label2.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.SteelBlue;
            this.label3.Location = new System.Drawing.Point(635, 446);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Промахов:";
            this.label3.Visible = false;
            // 
            // RedoButton
            // 
            this.RedoButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RedoButton.ForeColor = System.Drawing.Color.DarkBlue;
            this.RedoButton.Location = new System.Drawing.Point(76, 208);
            this.RedoButton.Name = "RedoButton";
            this.RedoButton.Size = new System.Drawing.Size(97, 25);
            this.RedoButton.TabIndex = 8;
            this.RedoButton.Text = "Заново";
            this.RedoButton.UseVisualStyleBackColor = true;
            this.RedoButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 585);
            this.Controls.Add(this.RedoButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ShutsDataGridView);
            this.Controls.Add(this.ShutsTextBox);
            this.Controls.Add(this.RadiusTextBox);
            this.Controls.Add(this.drawPictureBox);
            this.Name = "Form1";
            this.Text = "Мишень";
            ((System.ComponentModel.ISupportInitialize)(this.drawPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShutsDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox drawPictureBox;
        private System.Windows.Forms.TextBox RadiusTextBox;
        private System.Windows.Forms.TextBox ShutsTextBox;
        private System.Windows.Forms.DataGridView ShutsDataGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button RedoButton;
    }
}

