namespace LesaDB
{
    partial class Settings
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.tbSkLesa = new System.Windows.Forms.TextBox();
            this.btnChanPass = new System.Windows.Forms.Button();
            this.btnBDClean = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.tbSkLesa);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(241, 114);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sklad";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Skladdagi lesalar soni";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(64, 85);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(107, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Saqlash";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tbSkLesa
            // 
            this.tbSkLesa.Location = new System.Drawing.Point(127, 17);
            this.tbSkLesa.Name = "tbSkLesa";
            this.tbSkLesa.Size = new System.Drawing.Size(100, 20);
            this.tbSkLesa.TabIndex = 0;
            // 
            // btnChanPass
            // 
            this.btnChanPass.Location = new System.Drawing.Point(64, 120);
            this.btnChanPass.Name = "btnChanPass";
            this.btnChanPass.Size = new System.Drawing.Size(107, 23);
            this.btnChanPass.TabIndex = 1;
            this.btnChanPass.Text = "Parolni o`zgartirish";
            this.btnChanPass.UseVisualStyleBackColor = true;
            this.btnChanPass.Click += new System.EventHandler(this.btnChanPass_Click);
            // 
            // btnBDClean
            // 
            this.btnBDClean.Location = new System.Drawing.Point(64, 149);
            this.btnBDClean.Name = "btnBDClean";
            this.btnBDClean.Size = new System.Drawing.Size(107, 23);
            this.btnBDClean.TabIndex = 2;
            this.btnBDClean.Text = "Bazani tozalash";
            this.btnBDClean.UseVisualStyleBackColor = true;
            this.btnBDClean.Visible = false;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(64, 207);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(107, 23);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Chiqish";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(241, 243);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnBDClean);
            this.Controls.Add(this.btnChanPass);
            this.Controls.Add(this.groupBox1);
            this.Name = "Settings";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox tbSkLesa;
        private System.Windows.Forms.Button btnChanPass;
        private System.Windows.Forms.Button btnBDClean;
        private System.Windows.Forms.Button btnExit;
    }
}