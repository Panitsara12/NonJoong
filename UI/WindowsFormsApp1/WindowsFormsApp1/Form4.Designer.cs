﻿
namespace WindowsFormsApp1
{
    partial class Form4
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(86, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "Lot ID";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.MintCream;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.textBox1.ForeColor = System.Drawing.Color.Gray;
            this.textBox1.Location = new System.Drawing.Point(41, 117);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(157, 35);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "Lot ID";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.Enter += new System.EventHandler(this.textBox1_Enter);
            this.textBox1.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // pictureBox8
            // 
            this.pictureBox8.Image = global::WindowsFormsApp1.Properties.Resources.bin;
            this.pictureBox8.Location = new System.Drawing.Point(74, 237);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(97, 91);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox8.TabIndex = 40;
            this.pictureBox8.TabStop = false;
            this.pictureBox8.Click += new System.EventHandler(this.pictureBox8_Click);
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PeachPuff;
            this.ClientSize = new System.Drawing.Size(243, 369);
            this.Controls.Add(this.pictureBox8);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.DoubleBuffered = true;
            this.Name = "Form4";
            this.Text = "Form4";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.PictureBox pictureBox8;
    }
}