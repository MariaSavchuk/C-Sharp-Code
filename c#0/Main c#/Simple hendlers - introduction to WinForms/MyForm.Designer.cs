namespace Дурак
{
    partial class MyForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.YesButton = new System.Windows.Forms.Button();
            this.NoButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.controlTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label1.Location = new System.Drawing.Point(230, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(460, 42);
            this.label1.TabIndex = 0;
            this.label1.Text = "Вы знаете, как нажать на Нет?";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // YesButton
            // 
            this.YesButton.Location = new System.Drawing.Point(171, 164);
            this.YesButton.Name = "YesButton";
            this.YesButton.Size = new System.Drawing.Size(91, 56);
            this.YesButton.TabIndex = 1;
            this.YesButton.Text = "Да";
            this.YesButton.UseVisualStyleBackColor = true;
            this.YesButton.Click += new System.EventHandler(this.YesButton_Click);
            // 
            // NoButton
            // 
            this.NoButton.AccessibleRole = System.Windows.Forms.AccessibleRole.OutlineButton;
            this.NoButton.Location = new System.Drawing.Point(570, 164);
            this.NoButton.Name = "NoButton";
            this.NoButton.Size = new System.Drawing.Size(91, 56);
            this.NoButton.TabIndex = 2;
            this.NoButton.Text = "Нет";
            this.NoButton.UseVisualStyleBackColor = true;
            this.NoButton.MouseMove += new System.Windows.Forms.MouseEventHandler(this.NoButton_MouseMove);
            this.NoButton.Click += new System.EventHandler(this.NoButton_Click);
            this.NoButton.Enter += new System.EventHandler(this.NoButton_Enter);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(298, 158);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(254, 62);
            this.label2.TabIndex = 3;
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label2.Visible = false;
            // 
            // controlTextBox
            // 
            this.controlTextBox.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.controlTextBox.ForeColor = System.Drawing.SystemColors.InfoText;
            this.controlTextBox.Location = new System.Drawing.Point(192, 486);
            this.controlTextBox.Name = "controlTextBox";
            this.controlTextBox.Size = new System.Drawing.Size(470, 20);
            this.controlTextBox.TabIndex = 4;
            this.controlTextBox.Visible = false;
            this.controlTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cntrolTextBox_KeyDown);
            // 
            // MyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(842, 509);
            this.Controls.Add(this.NoButton);
            this.Controls.Add(this.YesButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.controlTextBox);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "MyForm";
            this.Text = "Нажмите alt, а потом введите \"Hет\" +Enter, После чего кнопка перестанет убегать.";
            this.TopMost = true;
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MyForm_MouseMove);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MyForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button YesButton;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Button NoButton;
        private System.Windows.Forms.TextBox controlTextBox;
    }
}

