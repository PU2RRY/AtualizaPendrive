namespace Atualiza_Pendrive
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            button1 = new Button();
            textBox1 = new TextBox();
            progressBar1 = new ProgressBar();
            label1 = new Label();
            button2 = new Button();
            label2 = new Label();
            lbAviso = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(252, 30);
            button1.Name = "button1";
            button1.Size = new Size(38, 23);
            button1.TabIndex = 0;
            button1.Text = "...";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            textBox1.Location = new Point(6, 30);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(240, 23);
            textBox1.TabIndex = 1;
            textBox1.Text = "Selecione a pasta no seu PenDrive       --->";
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(6, 85);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(282, 23);
            progressBar1.TabIndex = 2;
            progressBar1.Click += progressBar1_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(68, 9);
            label1.Name = "label1";
            label1.Size = new Size(160, 20);
            label1.TabIndex = 3;
            label1.Text = "ATUALIZA PENDRIVE";
            // 
            // button2
            // 
            button2.BackColor = Color.DarkGray;
            button2.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            button2.Location = new Point(6, 135);
            button2.Name = "button2";
            button2.Size = new Size(284, 31);
            button2.TabIndex = 4;
            button2.Text = "ATUALIZAR";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click_1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 114);
            label2.Name = "label2";
            label2.Size = new Size(16, 15);
            label2.TabIndex = 5;
            label2.Text = "...";
            // 
            // lbAviso
            // 
            lbAviso.AutoSize = true;
            lbAviso.BackColor = Color.Black;
            lbAviso.Font = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lbAviso.ForeColor = Color.Red;
            lbAviso.Location = new Point(7, 60);
            lbAviso.Name = "lbAviso";
            lbAviso.Size = new Size(285, 14);
            lbAviso.TabIndex = 6;
            lbAviso.Text = "Selecione a pasta DCS dentro do Pendrive";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.WindowFrame;
            ClientSize = new Size(297, 174);
            Controls.Add(lbAviso);
            Controls.Add(label2);
            Controls.Add(button2);
            Controls.Add(label1);
            Controls.Add(progressBar1);
            Controls.Add(textBox1);
            Controls.Add(button1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Atualiza Pendrive";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox textBox1;
        private ProgressBar progressBar1;
        private Label label1;
        private Button button2;
        private Label label2;
        private Label lbAviso;
    }
}