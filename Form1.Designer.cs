namespace WinFormsApp1
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
            txtArama = new TextBox();
            btnAra = new Button();
            dataGridViewSonuc = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            cmbAramaTuru = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSonuc).BeginInit();
            SuspendLayout();
            // 
            // txtArama
            // 
            txtArama.Location = new Point(12, 49);
            txtArama.Name = "txtArama";
            txtArama.Size = new Size(117, 27);
            txtArama.TabIndex = 0;
            txtArama.TextChanged += textArama_TextChanged;
            // 
            // btnAra
            // 
            btnAra.Location = new Point(135, 49);
            btnAra.Name = "btnAra";
            btnAra.Size = new Size(75, 29);
            btnAra.TabIndex = 2;
            btnAra.Text = "Ara";
            btnAra.UseVisualStyleBackColor = true;
            btnAra.Click += btnAra_Click;
            // 
            // dataGridViewSonuc
            // 
            dataGridViewSonuc.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewSonuc.Location = new Point(12, 127);
            dataGridViewSonuc.Name = "dataGridViewSonuc";
            dataGridViewSonuc.RowHeadersWidth = 51;
            dataGridViewSonuc.Size = new Size(570, 188);
            dataGridViewSonuc.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 26);
            label1.Name = "label1";
            label1.Size = new Size(208, 20);
            label1.TabIndex = 4;
            label1.Text = "Ad-Soyad / Telefon Numarası:";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 85);
            label2.Name = "label2";
            label2.Size = new Size(117, 20);
            label2.TabIndex = 5;
            label2.Text = "Sorgulama Türü:";
            // 
            // cmbAramaTuru
            // 
            cmbAramaTuru.FormattingEnabled = true;
            cmbAramaTuru.Location = new Point(135, 84);
            cmbAramaTuru.Name = "cmbAramaTuru";
            cmbAramaTuru.Size = new Size(75, 28);
            cmbAramaTuru.TabIndex = 6;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(589, 349);
            Controls.Add(cmbAramaTuru);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dataGridViewSonuc);
            Controls.Add(btnAra);
            Controls.Add(txtArama);
            Name = "Form1";
            Text = "TelefonSorgu";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewSonuc).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtArama;
        private Button btnAra;
        private DataGridView dataGridViewSonuc;
        private Label label1;
        private Label label2;
        private ComboBox cmbAramaTuru;
    }
}
