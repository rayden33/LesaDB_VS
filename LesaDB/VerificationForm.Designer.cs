namespace LesaDB
{
    partial class VerificationForm
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
            this.tbPass = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnTasd = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbPass
            // 
            this.tbPass.Location = new System.Drawing.Point(65, 52);
            this.tbPass.Name = "tbPass";
            this.tbPass.Size = new System.Drawing.Size(149, 20);
            this.tbPass.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(268, 40);
            this.label1.TabIndex = 1;
            this.label1.Text = "BUYRUQNI TASDIQLASH UCHUN \r\nPAROLNI KIRITING:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnTasd
            // 
            this.btnTasd.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnTasd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnTasd.Location = new System.Drawing.Point(76, 78);
            this.btnTasd.Name = "btnTasd";
            this.btnTasd.Size = new System.Drawing.Size(125, 23);
            this.btnTasd.TabIndex = 2;
            this.btnTasd.Text = "TASDIQLASH";
            this.btnTasd.UseVisualStyleBackColor = true;
            this.btnTasd.Click += new System.EventHandler(this.btnTasd_Click);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(76, 109);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "BEKOR QILISH";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // VerificationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(281, 144);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnTasd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbPass);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "VerificationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VerificationForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbPass;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnTasd;
        private System.Windows.Forms.Button button1;
    }
}