using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Video_Capture_DonK.Models;

namespace Video_Capture_DonK
{
    partial class FormSmall
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSmall));
            this.recordButton = new System.Windows.Forms.Button();
            this.indicatorLight = new System.Windows.Forms.PictureBox();
            this.ScreenTimeButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.indicatorLight)).BeginInit();
            this.SuspendLayout();
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
            this.recordButton.Location = new System.Drawing.Point(38, 6);
            this.recordButton.Name = "recordButton";
            this.recordButton.Size = new System.Drawing.Size(16, 16);
            this.recordButton.TabIndex = 0;
            this.recordButton.UseVisualStyleBackColor = false;
            this.recordButton.Click += new System.EventHandler(this.RecordButton_Click);
            // 
            // indicatorLight
            // 
            this.indicatorLight.BackColor = System.Drawing.Color.Transparent;
            this.indicatorLight.BackgroundImage = global::Video_Capture_DonK.Properties.Resources.record;
            this.indicatorLight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.indicatorLight.ErrorImage = null;
            this.indicatorLight.InitialImage = null;
            this.indicatorLight.Location = new System.Drawing.Point(62, 5);
            this.indicatorLight.Name = "indicatorLight";
            this.indicatorLight.Size = new System.Drawing.Size(18, 18);
            this.indicatorLight.TabIndex = 5;
            this.indicatorLight.TabStop = false;
            // 
            // ScreenTimeButton
            // 
            this.ScreenTimeButton.BackColor = System.Drawing.Color.Transparent;
            this.ScreenTimeButton.BackgroundImage = global::Video_Capture_DonK.Properties.Resources.capture_icon;
            this.ScreenTimeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ScreenTimeButton.FlatAppearance.BorderSize = 0;
            this.ScreenTimeButton.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ScreenTimeButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ScreenTimeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ScreenTimeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ScreenTimeButton.Location = new System.Drawing.Point(12, 6);
            this.ScreenTimeButton.Name = "ScreenTimeButton";
            this.ScreenTimeButton.Size = new System.Drawing.Size(16, 16);
            this.ScreenTimeButton.TabIndex = 0;
            this.ScreenTimeButton.UseVisualStyleBackColor = false;
            this.ScreenTimeButton.Click += new System.EventHandler(this.ScreenTimeButton_Click);
            // 
            // FormSmall
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.DimGray;
            this.BackgroundImage = global::Video_Capture_DonK.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(90, 28);
            this.Controls.Add(this.indicatorLight);
            this.Controls.Add(this.recordButton);
            this.Controls.Add(this.ScreenTimeButton);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(43)))), ((int)(((byte)(56)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(90, 28);
            this.MinimumSize = new System.Drawing.Size(90, 28);
            this.Name = "FormSmall";
            this.Text = "ScreenTime";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.SystemColors.ActiveBorder;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormSmall_Closed);
            ((System.ComponentModel.ISupportInitialize)(this.indicatorLight)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Button recordButton;
        private PictureBox indicatorLight;
        private Button ScreenTimeButton;
    }
}

