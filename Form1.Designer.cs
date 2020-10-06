namespace ISSProject
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
            this.btn_Encrypt = new System.Windows.Forms.Button();
            this.tb_PlainText = new System.Windows.Forms.TextBox();
            this.btn_Decrypt = new System.Windows.Forms.Button();
            this.btn_BruteForce = new System.Windows.Forms.Button();
            this.tb_CipherText = new System.Windows.Forms.TextBox();
            this.tb_Key = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_Time = new System.Windows.Forms.TextBox();
            this.rtb_LFA = new System.Windows.Forms.RichTextBox();
            this.btn_LFA = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_LFAAmountSel = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_Encrypt
            // 
            this.btn_Encrypt.Location = new System.Drawing.Point(297, 42);
            this.btn_Encrypt.Name = "btn_Encrypt";
            this.btn_Encrypt.Size = new System.Drawing.Size(75, 23);
            this.btn_Encrypt.TabIndex = 1;
            this.btn_Encrypt.Text = "Encrypt";
            this.btn_Encrypt.UseVisualStyleBackColor = true;
            this.btn_Encrypt.Click += new System.EventHandler(this.btn_Encrypt_Click);
            // 
            // tb_PlainText
            // 
            this.tb_PlainText.Location = new System.Drawing.Point(107, 49);
            this.tb_PlainText.Name = "tb_PlainText";
            this.tb_PlainText.Size = new System.Drawing.Size(165, 20);
            this.tb_PlainText.TabIndex = 2;
            // 
            // btn_Decrypt
            // 
            this.btn_Decrypt.Location = new System.Drawing.Point(297, 124);
            this.btn_Decrypt.Name = "btn_Decrypt";
            this.btn_Decrypt.Size = new System.Drawing.Size(75, 23);
            this.btn_Decrypt.TabIndex = 3;
            this.btn_Decrypt.Text = "Decrypt";
            this.btn_Decrypt.UseVisualStyleBackColor = true;
            this.btn_Decrypt.Click += new System.EventHandler(this.btn_Decrypt_Click);
            // 
            // btn_BruteForce
            // 
            this.btn_BruteForce.Location = new System.Drawing.Point(297, 157);
            this.btn_BruteForce.Name = "btn_BruteForce";
            this.btn_BruteForce.Size = new System.Drawing.Size(75, 23);
            this.btn_BruteForce.TabIndex = 5;
            this.btn_BruteForce.Text = "Brute Force";
            this.btn_BruteForce.UseVisualStyleBackColor = true;
            this.btn_BruteForce.Click += new System.EventHandler(this.btn_BruteForce_Click);
            // 
            // tb_CipherText
            // 
            this.tb_CipherText.Location = new System.Drawing.Point(107, 126);
            this.tb_CipherText.Name = "tb_CipherText";
            this.tb_CipherText.Size = new System.Drawing.Size(165, 20);
            this.tb_CipherText.TabIndex = 6;
            // 
            // tb_Key
            // 
            this.tb_Key.Location = new System.Drawing.Point(107, 86);
            this.tb_Key.Name = "tb_Key";
            this.tb_Key.Size = new System.Drawing.Size(100, 20);
            this.tb_Key.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Plain Text:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Key:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Cipher Text:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 162);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Time Taken:";
            // 
            // tb_Time
            // 
            this.tb_Time.Location = new System.Drawing.Point(107, 159);
            this.tb_Time.Name = "tb_Time";
            this.tb_Time.Size = new System.Drawing.Size(100, 20);
            this.tb_Time.TabIndex = 12;
            // 
            // rtb_LFA
            // 
            this.rtb_LFA.Location = new System.Drawing.Point(494, 28);
            this.rtb_LFA.Name = "rtb_LFA";
            this.rtb_LFA.Size = new System.Drawing.Size(665, 250);
            this.rtb_LFA.TabIndex = 13;
            this.rtb_LFA.Text = "";
            // 
            // btn_LFA
            // 
            this.btn_LFA.Location = new System.Drawing.Point(522, 294);
            this.btn_LFA.Name = "btn_LFA";
            this.btn_LFA.Size = new System.Drawing.Size(143, 27);
            this.btn_LFA.TabIndex = 14;
            this.btn_LFA.Text = "Letter Frequency Attack";
            this.btn_LFA.UseVisualStyleBackColor = true;
            this.btn_LFA.Click += new System.EventHandler(this.btn_LFA_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(690, 301);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Show the most likely";
            // 
            // tb_LFAAmountSel
            // 
            this.tb_LFAAmountSel.Location = new System.Drawing.Point(799, 298);
            this.tb_LFAAmountSel.Name = "tb_LFAAmountSel";
            this.tb_LFAAmountSel.Size = new System.Drawing.Size(20, 20);
            this.tb_LFAAmountSel.TabIndex = 16;
            this.tb_LFAAmountSel.Text = "25";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(825, 301);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "keys";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1187, 333);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tb_LFAAmountSel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btn_LFA);
            this.Controls.Add(this.rtb_LFA);
            this.Controls.Add(this.tb_Time);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_Key);
            this.Controls.Add(this.tb_CipherText);
            this.Controls.Add(this.btn_BruteForce);
            this.Controls.Add(this.btn_Decrypt);
            this.Controls.Add(this.tb_PlainText);
            this.Controls.Add(this.btn_Encrypt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Encrypt;
        private System.Windows.Forms.TextBox tb_PlainText;
        private System.Windows.Forms.Button btn_Decrypt;
        private System.Windows.Forms.Button btn_BruteForce;
        private System.Windows.Forms.TextBox tb_CipherText;
        private System.Windows.Forms.TextBox tb_Key;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_Time;
        private System.Windows.Forms.RichTextBox rtb_LFA;
        private System.Windows.Forms.Button btn_LFA;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_LFAAmountSel;
        private System.Windows.Forms.Label label6;
    }
}

