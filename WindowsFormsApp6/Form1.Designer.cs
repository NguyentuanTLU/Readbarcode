namespace WindowsFormsApp6
{
    partial class Form1
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.listBoxROI = new System.Windows.Forms.ListBox();
            this.btnLoadImage = new System.Windows.Forms.Button();
            this.btnDeleteROI = new System.Windows.Forms.Button();
            this.btnSaveROI = new System.Windows.Forms.Button();
            this.btnLoadROI = new System.Windows.Forms.Button();
            this.btnReadBarcode = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.comboBoxAlgorithm = new System.Windows.Forms.ComboBox();
            this.comboBoxBarcodeFormat = new System.Windows.Forms.ComboBox();
            this.textBoxBarcodeLength = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.pictureBox1.Location = new System.Drawing.Point(3, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(940, 539);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // listBoxROI
            // 
            this.listBoxROI.FormattingEnabled = true;
            this.listBoxROI.ItemHeight = 20;
            this.listBoxROI.Location = new System.Drawing.Point(975, 12);
            this.listBoxROI.Name = "listBoxROI";
            this.listBoxROI.Size = new System.Drawing.Size(265, 364);
            this.listBoxROI.TabIndex = 1;
            // 
            // btnLoadImage
            // 
            this.btnLoadImage.Location = new System.Drawing.Point(12, 604);
            this.btnLoadImage.Name = "btnLoadImage";
            this.btnLoadImage.Size = new System.Drawing.Size(111, 60);
            this.btnLoadImage.TabIndex = 2;
            this.btnLoadImage.Text = "LoadIMG";
            this.btnLoadImage.UseVisualStyleBackColor = true;
            this.btnLoadImage.Click += new System.EventHandler(this.btnLoadImage_Click);
            // 
            // btnDeleteROI
            // 
            this.btnDeleteROI.Location = new System.Drawing.Point(172, 604);
            this.btnDeleteROI.Name = "btnDeleteROI";
            this.btnDeleteROI.Size = new System.Drawing.Size(111, 60);
            this.btnDeleteROI.TabIndex = 3;
            this.btnDeleteROI.Text = "Delete";
            this.btnDeleteROI.UseVisualStyleBackColor = true;
            this.btnDeleteROI.Click += new System.EventHandler(this.btnDeleteROI_Click_1);
            // 
            // btnSaveROI
            // 
            this.btnSaveROI.Location = new System.Drawing.Point(337, 604);
            this.btnSaveROI.Name = "btnSaveROI";
            this.btnSaveROI.Size = new System.Drawing.Size(111, 60);
            this.btnSaveROI.TabIndex = 4;
            this.btnSaveROI.Text = "SaveROI";
            this.btnSaveROI.UseVisualStyleBackColor = true;
            this.btnSaveROI.Click += new System.EventHandler(this.btnSaveROI_Click_1);
            // 
            // btnLoadROI
            // 
            this.btnLoadROI.Location = new System.Drawing.Point(501, 604);
            this.btnLoadROI.Name = "btnLoadROI";
            this.btnLoadROI.Size = new System.Drawing.Size(111, 60);
            this.btnLoadROI.TabIndex = 5;
            this.btnLoadROI.Text = "LoadROI";
            this.btnLoadROI.UseVisualStyleBackColor = true;
            this.btnLoadROI.Click += new System.EventHandler(this.btnLoadROI_Click_1);
            // 
            // btnReadBarcode
            // 
            this.btnReadBarcode.Location = new System.Drawing.Point(667, 604);
            this.btnReadBarcode.Name = "btnReadBarcode";
            this.btnReadBarcode.Size = new System.Drawing.Size(111, 60);
            this.btnReadBarcode.TabIndex = 6;
            this.btnReadBarcode.Text = "Read";
            this.btnReadBarcode.UseVisualStyleBackColor = true;
            this.btnReadBarcode.Click += new System.EventHandler(this.btnReadBarcode_Click_1);
            // 
            // comboBoxAlgorithm
            // 
            this.comboBoxAlgorithm.FormattingEnabled = true;
            this.comboBoxAlgorithm.Location = new System.Drawing.Point(975, 397);
            this.comboBoxAlgorithm.Name = "comboBoxAlgorithm";
            this.comboBoxAlgorithm.Size = new System.Drawing.Size(265, 28);
            this.comboBoxAlgorithm.TabIndex = 7;
            // 
            // comboBoxBarcodeFormat
            // 
            this.comboBoxBarcodeFormat.FormattingEnabled = true;
            this.comboBoxBarcodeFormat.Location = new System.Drawing.Point(975, 464);
            this.comboBoxBarcodeFormat.Name = "comboBoxBarcodeFormat";
            this.comboBoxBarcodeFormat.Size = new System.Drawing.Size(265, 28);
            this.comboBoxBarcodeFormat.TabIndex = 8;
            // 
            // textBoxBarcodeLength
            // 
            this.textBoxBarcodeLength.Location = new System.Drawing.Point(975, 524);
            this.textBoxBarcodeLength.Name = "textBoxBarcodeLength";
            this.textBoxBarcodeLength.Size = new System.Drawing.Size(265, 26);
            this.textBoxBarcodeLength.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1252, 731);
            this.Controls.Add(this.textBoxBarcodeLength);
            this.Controls.Add(this.comboBoxBarcodeFormat);
            this.Controls.Add(this.comboBoxAlgorithm);
            this.Controls.Add(this.btnReadBarcode);
            this.Controls.Add(this.btnLoadROI);
            this.Controls.Add(this.btnSaveROI);
            this.Controls.Add(this.btnDeleteROI);
            this.Controls.Add(this.btnLoadImage);
            this.Controls.Add(this.listBoxROI);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListBox listBoxROI;
        private System.Windows.Forms.Button btnLoadImage;
        private System.Windows.Forms.Button btnDeleteROI;
        private System.Windows.Forms.Button btnSaveROI;
        private System.Windows.Forms.Button btnLoadROI;
        private System.Windows.Forms.Button btnReadBarcode;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ComboBox comboBoxAlgorithm;
        private System.Windows.Forms.ComboBox comboBoxBarcodeFormat;
        private System.Windows.Forms.TextBox textBoxBarcodeLength;
    }
}

