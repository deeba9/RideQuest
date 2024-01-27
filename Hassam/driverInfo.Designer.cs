namespace Hassam
{
    partial class driverInfo
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ava = new System.Windows.Forms.TextBox();
            this.plateTB = new System.Windows.Forms.TextBox();
            this.typeTB = new System.Windows.Forms.TextBox();
            this.noTB = new System.Windows.Forms.TextBox();
            this.locTB = new System.Windows.Forms.TextBox();
            this.loginbt = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.userTB = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(127)))), ((int)(((byte)(158)))));
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Location = new System.Drawing.Point(-2, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(803, 62);
            this.panel1.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(127)))), ((int)(((byte)(158)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Comic Sans MS", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.SystemColors.Control;
            this.textBox1.Location = new System.Drawing.Point(163, 13);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(297, 40);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "Driver\'s Information";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(158)))));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.Control;
            this.button1.Location = new System.Drawing.Point(583, -27);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(63, 121);
            this.button1.TabIndex = 13;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Comic Sans MS", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.label5.Location = new System.Drawing.Point(54, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(180, 30);
            this.label5.TabIndex = 15;
            this.label5.Text = "Contact Number";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.label1.Location = new System.Drawing.Point(339, 212);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(221, 30);
            this.label1.TabIndex = 16;
            this.label1.Text = "Availability(Yes/No)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.label2.Location = new System.Drawing.Point(339, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 30);
            this.label2.TabIndex = 17;
            this.label2.Text = "Vehicle Type";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Comic Sans MS", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.label3.Location = new System.Drawing.Point(54, 307);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 30);
            this.label3.TabIndex = 18;
            this.label3.Text = "Location";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Comic Sans MS", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.label4.Location = new System.Drawing.Point(54, 212);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(151, 30);
            this.label4.TabIndex = 19;
            this.label4.Text = "Plate Number";
            // 
            // ava
            // 
            this.ava.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(158)))));
            this.ava.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ava.ForeColor = System.Drawing.SystemColors.Window;
            this.ava.Location = new System.Drawing.Point(344, 247);
            this.ava.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ava.Name = "ava";
            this.ava.Size = new System.Drawing.Size(245, 43);
            this.ava.TabIndex = 20;
            // 
            // plateTB
            // 
            this.plateTB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(158)))));
            this.plateTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.plateTB.ForeColor = System.Drawing.SystemColors.Window;
            this.plateTB.Location = new System.Drawing.Point(59, 247);
            this.plateTB.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.plateTB.Name = "plateTB";
            this.plateTB.Size = new System.Drawing.Size(220, 43);
            this.plateTB.TabIndex = 21;
            // 
            // typeTB
            // 
            this.typeTB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(158)))));
            this.typeTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.typeTB.ForeColor = System.Drawing.SystemColors.Window;
            this.typeTB.Location = new System.Drawing.Point(344, 142);
            this.typeTB.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.typeTB.Name = "typeTB";
            this.typeTB.Size = new System.Drawing.Size(245, 43);
            this.typeTB.TabIndex = 22;
            // 
            // noTB
            // 
            this.noTB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(158)))));
            this.noTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noTB.ForeColor = System.Drawing.SystemColors.Window;
            this.noTB.Location = new System.Drawing.Point(59, 142);
            this.noTB.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.noTB.Name = "noTB";
            this.noTB.Size = new System.Drawing.Size(220, 43);
            this.noTB.TabIndex = 23;
            // 
            // locTB
            // 
            this.locTB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(158)))));
            this.locTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.locTB.ForeColor = System.Drawing.SystemColors.Window;
            this.locTB.Location = new System.Drawing.Point(59, 342);
            this.locTB.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.locTB.Name = "locTB";
            this.locTB.Size = new System.Drawing.Size(530, 43);
            this.locTB.TabIndex = 24;
            // 
            // loginbt
            // 
            this.loginbt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(158)))));
            this.loginbt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.loginbt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loginbt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginbt.ForeColor = System.Drawing.SystemColors.Control;
            this.loginbt.Location = new System.Drawing.Point(390, 419);
            this.loginbt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.loginbt.Name = "loginbt";
            this.loginbt.Size = new System.Drawing.Size(170, 54);
            this.loginbt.TabIndex = 25;
            this.loginbt.Text = "Add";
            this.loginbt.UseVisualStyleBackColor = false;
            this.loginbt.Click += new System.EventHandler(this.loginbt_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Comic Sans MS", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.label6.Location = new System.Drawing.Point(54, 395);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(277, 30);
            this.label6.TabIndex = 26;
            this.label6.Text = "Name (same as username)";
            // 
            // userTB
            // 
            this.userTB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(158)))));
            this.userTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userTB.ForeColor = System.Drawing.SystemColors.Window;
            this.userTB.Location = new System.Drawing.Point(59, 430);
            this.userTB.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.userTB.Name = "userTB";
            this.userTB.Size = new System.Drawing.Size(220, 43);
            this.userTB.TabIndex = 27;
            // 
            // driverInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 501);
            this.Controls.Add(this.userTB);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.loginbt);
            this.Controls.Add(this.locTB);
            this.Controls.Add(this.noTB);
            this.Controls.Add(this.typeTB);
            this.Controls.Add(this.plateTB);
            this.Controls.Add(this.ava);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "driverInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "driverInfo";
            this.Load += new System.EventHandler(this.driverInfo_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox ava;
        private System.Windows.Forms.TextBox plateTB;
        private System.Windows.Forms.TextBox typeTB;
        private System.Windows.Forms.TextBox noTB;
        private System.Windows.Forms.TextBox locTB;
        private System.Windows.Forms.Button loginbt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox userTB;
    }
}