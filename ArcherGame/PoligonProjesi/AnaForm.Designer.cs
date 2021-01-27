namespace PoligonProjesi
{
    partial class AnaForm
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnaForm));
            this.BilgiPanel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.SüreLabel = new System.Windows.Forms.Label();
            this.AltDuvarPanel = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.SavascıPanel = new System.Windows.Forms.Panel();
            this.BalonPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.BilgiPanel.SuspendLayout();
            this.AltDuvarPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // BilgiPanel
            // 
            this.BilgiPanel.BackColor = System.Drawing.Color.SteelBlue;
            this.BilgiPanel.Controls.Add(this.label1);
            this.BilgiPanel.Controls.Add(this.label2);
            this.BilgiPanel.Controls.Add(this.SüreLabel);
            this.BilgiPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.BilgiPanel.Location = new System.Drawing.Point(0, 0);
            this.BilgiPanel.Name = "BilgiPanel";
            this.BilgiPanel.Size = new System.Drawing.Size(1237, 77);
            this.BilgiPanel.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(12, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 29);
            this.label2.TabIndex = 3;
            this.label2.Text = "Puan:";
            // 
            // SüreLabel
            // 
            this.SüreLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SüreLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.SüreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.SüreLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.SüreLabel.Location = new System.Drawing.Point(1070, 23);
            this.SüreLabel.Name = "SüreLabel";
            this.SüreLabel.Size = new System.Drawing.Size(155, 51);
            this.SüreLabel.TabIndex = 1;
            this.SüreLabel.Text = "00:00";
            this.SüreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
          
            // 
            // AltDuvarPanel
            // 
            this.AltDuvarPanel.BackColor = System.Drawing.Color.Turquoise;
            this.AltDuvarPanel.Controls.Add(this.pictureBox1);
            this.AltDuvarPanel.Controls.Add(this.pictureBox2);
            this.AltDuvarPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.AltDuvarPanel.Location = new System.Drawing.Point(0, 638);
            this.AltDuvarPanel.Name = "AltDuvarPanel";
            this.AltDuvarPanel.Size = new System.Drawing.Size(1237, 57);
            this.AltDuvarPanel.TabIndex = 1;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(1110, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(127, 57);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox2_MouseClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1110, 57);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // SavascıPanel
            // 
            this.SavascıPanel.BackColor = System.Drawing.SystemColors.HotTrack;
            this.SavascıPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.SavascıPanel.Location = new System.Drawing.Point(0, 77);
            this.SavascıPanel.Name = "SavascıPanel";
            this.SavascıPanel.Size = new System.Drawing.Size(235, 561);
            this.SavascıPanel.TabIndex = 2;
            this.SavascıPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.SavascıPanel_Paint);
            // 
            // BalonPanel
            // 
            this.BalonPanel.BackColor = System.Drawing.SystemColors.HighlightText;
            this.BalonPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BalonPanel.Location = new System.Drawing.Point(235, 77);
            this.BalonPanel.Name = "BalonPanel";
            this.BalonPanel.Size = new System.Drawing.Size(1002, 561);
            this.BalonPanel.TabIndex = 3;
            
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(97, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 29);
            this.label1.TabIndex = 4;
            this.label1.Text = "0";
            // 
            // AnaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1237, 695);
            this.Controls.Add(this.BalonPanel);
            this.Controls.Add(this.SavascıPanel);
            this.Controls.Add(this.AltDuvarPanel);
            this.Controls.Add(this.BilgiPanel);
            this.Name = "AnaForm";
            this.Text = "OkcuPoligon";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.AnaForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AnaForm_KeyDown);
            this.BilgiPanel.ResumeLayout(false);
            this.BilgiPanel.PerformLayout();
            this.AltDuvarPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel BilgiPanel;
        private System.Windows.Forms.Label SüreLabel;
        private System.Windows.Forms.Panel SavascıPanel;
        private System.Windows.Forms.Panel BalonPanel;
        public System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Panel AltDuvarPanel;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}

