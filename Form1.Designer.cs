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
            progressBar1 = new ProgressBar();
            label1 = new Label();
            btnAtualiza = new Button();
            label2 = new Label();
            comboBox1 = new ComboBox();
            btnRecarregadiscos = new Button();
            SuspendLayout();
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(6, 61);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(282, 23);
            progressBar1.TabIndex = 2;
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
            // btnAtualiza
            // 
            btnAtualiza.BackColor = Color.DarkGray;
            btnAtualiza.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnAtualiza.Location = new Point(6, 112);
            btnAtualiza.Name = "btnAtualiza";
            btnAtualiza.Size = new Size(284, 31);
            btnAtualiza.TabIndex = 4;
            btnAtualiza.Text = "ATUALIZAR";
            btnAtualiza.UseVisualStyleBackColor = false;
            btnAtualiza.Click += btnAtualiza_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 91);
            label2.Name = "label2";
            label2.Size = new Size(16, 15);
            label2.TabIndex = 5;
            label2.Text = "...";
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(6, 32);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(255, 23);
            comboBox1.TabIndex = 7;
            comboBox1.TextChanged += comboBox1_TextChanged;
            // 
            // btnRecarregadiscos
            // 
            btnRecarregadiscos.Image = Properties.Resources.recarregar_20_x_20_;
            btnRecarregadiscos.Location = new Point(263, 31);
            btnRecarregadiscos.Name = "btnRecarregadiscos";
            btnRecarregadiscos.Size = new Size(27, 24);
            btnRecarregadiscos.TabIndex = 8;
            btnRecarregadiscos.UseVisualStyleBackColor = true;
            btnRecarregadiscos.Click += btnRecarregadiscos_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.WindowFrame;
            ClientSize = new Size(297, 150);
            Controls.Add(btnRecarregadiscos);
            Controls.Add(comboBox1);
            Controls.Add(label2);
            Controls.Add(btnAtualiza);
            Controls.Add(label1);
            Controls.Add(progressBar1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Atualiza Pendrive";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ProgressBar progressBar1;
        private Label label1;
        private Button btnAtualiza;
        private Label label2;
        private ComboBox comboBox1;
        private Button btnRecarregadiscos;
    }
}