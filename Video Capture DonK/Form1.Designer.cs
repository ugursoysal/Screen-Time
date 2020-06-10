using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Video_Capture_DonK.Models;

namespace Video_Capture_DonK
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timePassed = new System.Windows.Forms.Label();
            this.companyDropList = new System.Windows.Forms.ComboBox();
            this.recordButton = new System.Windows.Forms.Button();
            this.shutdownButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.companyLabel = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // timePassed
            // 
            this.timePassed.AutoSize = true;
            this.timePassed.BackColor = System.Drawing.Color.Transparent;
            this.timePassed.ForeColor = System.Drawing.Color.White;
            this.timePassed.Location = new System.Drawing.Point(371, 7);
            this.timePassed.Name = "timePassed";
            this.timePassed.Size = new System.Drawing.Size(49, 13);
            this.timePassed.TabIndex = 1;
            this.timePassed.Text = "00:00:00";
            // 
            // companyDropList
            // 
            this.companyDropList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.companyDropList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.companyDropList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(43)))), ((int)(((byte)(56)))));
            this.companyDropList.Location = new System.Drawing.Point(73, 3);
            this.companyDropList.Name = "companyDropList";
            this.companyDropList.Size = new System.Drawing.Size(188, 21);
            this.companyDropList.TabIndex = 2;
            this.companyDropList.SelectedIndexChanged += new System.EventHandler(this.CompanyDropList_SelectedIndexChanged);
            // 
            // recordButton
            // 
            this.recordButton.BackColor = System.Drawing.Color.Transparent;
            this.recordButton.BackgroundImage = global::Video_Capture_DonK.Properties.Resources.play;
            this.recordButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.recordButton.FlatAppearance.BorderSize = 0;
            this.recordButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.recordButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.recordButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.recordButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.recordButton.Location = new System.Drawing.Point(13, 6);
            this.recordButton.Name = "recordButton";
            this.recordButton.Size = new System.Drawing.Size(16, 16);
            this.recordButton.TabIndex = 0;
            this.recordButton.UseVisualStyleBackColor = false;
            this.recordButton.Click += new System.EventHandler(this.Record_Click);
            // 
            // shutdownButton
            // 
            this.shutdownButton.BackColor = System.Drawing.Color.Transparent;
            this.shutdownButton.BackgroundImage = global::Video_Capture_DonK.Properties.Resources.shutdown;
            this.shutdownButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.shutdownButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.shutdownButton.FlatAppearance.BorderSize = 0;
            this.shutdownButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.shutdownButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.shutdownButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.shutdownButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.shutdownButton.ForeColor = System.Drawing.Color.Transparent;
            this.shutdownButton.Location = new System.Drawing.Point(422, 3);
            this.shutdownButton.Margin = new System.Windows.Forms.Padding(0);
            this.shutdownButton.Name = "shutdownButton";
            this.shutdownButton.Size = new System.Drawing.Size(23, 23);
            this.shutdownButton.TabIndex = 0;
            this.shutdownButton.UseVisualStyleBackColor = false;
            this.shutdownButton.Click += new System.EventHandler(this.Shutdown_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(43)))), ((int)(((byte)(56)))));
            this.pictureBox1.BackgroundImage = global::Video_Capture_DonK.Properties.Resources.droplist;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Enabled = false;
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(68, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(194, 21);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // companyLabel
            // 
            this.companyLabel.BackColor = System.Drawing.Color.Transparent;
            this.companyLabel.ForeColor = System.Drawing.Color.White;
            this.companyLabel.Location = new System.Drawing.Point(85, 6);
            this.companyLabel.Name = "companyLabel";
            this.companyLabel.Size = new System.Drawing.Size(150, 13);
            this.companyLabel.TabIndex = 4;
            this.companyLabel.Text = "(Select a company)";
            this.companyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImage = global::Video_Capture_DonK.Properties.Resources.record;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.ErrorImage = null;
            this.pictureBox2.InitialImage = null;
            this.pictureBox2.Location = new System.Drawing.Point(37, 5);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(18, 18);
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.DimGray;
            this.BackgroundImage = global::Video_Capture_DonK.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(452, 28);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.companyLabel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.companyDropList);
            this.Controls.Add(this.timePassed);
            this.Controls.Add(this.recordButton);
            this.Controls.Add(this.shutdownButton);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(43)))), ((int)(((byte)(56)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(452, 28);
            this.MinimumSize = new System.Drawing.Size(452, 28);
            this.Name = "Form1";
            this.Text = "Video Capture (special software for Don K.)";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.SystemColors.ActiveBorder;
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button shutdownButton;
        private Button recordButton;
        private Label timePassed;
        private ComboBox companyDropList;
        private PictureBox pictureBox1;
        private Label companyLabel;
        private PictureBox pictureBox2;
    }
}

