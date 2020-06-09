using System;
using System.Collections.Generic;
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
            this.clientDropList = new System.Windows.Forms.ComboBox();
            this.infoButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.recordButton = new System.Windows.Forms.Button();
            this.shutdownButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // timePassed
            // 
            this.timePassed.AutoSize = true;
            this.timePassed.Location = new System.Drawing.Point(368, 9);
            this.timePassed.Name = "timePassed";
            this.timePassed.Size = new System.Drawing.Size(34, 13);
            this.timePassed.TabIndex = 1;
            this.timePassed.Text = "00:00";
            // 
            // companyDropList
            // 
            this.companyDropList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.companyDropList.FormattingEnabled = true;
            this.companyDropList.Location = new System.Drawing.Point(11, 6);
            this.companyDropList.Name = "companyDropList";
            this.companyDropList.Size = new System.Drawing.Size(121, 21);
            this.companyDropList.TabIndex = 2;
            this.companyDropList.SelectedIndexChanged += new System.EventHandler(this.CompanyDropList_SelectedIndexChanged);
            // 
            // clientDropList
            // 
            this.clientDropList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.clientDropList.FormattingEnabled = true;
            this.clientDropList.Location = new System.Drawing.Point(139, 6);
            this.clientDropList.Name = "clientDropList";
            this.clientDropList.Size = new System.Drawing.Size(121, 21);
            this.clientDropList.TabIndex = 2;
            this.clientDropList.SelectedIndexChanged += new System.EventHandler(this.ClientDropList_SelectedIndexChanged);
            // 
            // infoButton
            // 
            this.infoButton.BackgroundImage = global::Video_Capture_DonK.Properties.Resources.info;
            this.infoButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.infoButton.Location = new System.Drawing.Point(266, 4);
            this.infoButton.Name = "infoButton";
            this.infoButton.Size = new System.Drawing.Size(23, 23);
            this.infoButton.TabIndex = 0;
            this.infoButton.UseVisualStyleBackColor = true;
            this.infoButton.Click += new System.EventHandler(this.Info_Click);
            // 
            // stopButton
            // 
            this.stopButton.BackgroundImage = global::Video_Capture_DonK.Properties.Resources.stop2;
            this.stopButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.stopButton.Enabled = false;
            this.stopButton.Location = new System.Drawing.Point(410, 4);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(23, 23);
            this.stopButton.TabIndex = 0;
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.Stop_Click);
            // 
            // recordButton
            // 
            this.recordButton.BackgroundImage = global::Video_Capture_DonK.Properties.Resources.record;
            this.recordButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.recordButton.Location = new System.Drawing.Point(439, 4);
            this.recordButton.Name = "recordButton";
            this.recordButton.Size = new System.Drawing.Size(23, 23);
            this.recordButton.TabIndex = 0;
            this.recordButton.UseVisualStyleBackColor = true;
            this.recordButton.Click += new System.EventHandler(this.Record_Click);
            // 
            // shutdownButton
            // 
            this.shutdownButton.BackgroundImage = global::Video_Capture_DonK.Properties.Resources.shutdown;
            this.shutdownButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.shutdownButton.Location = new System.Drawing.Point(468, 4);
            this.shutdownButton.Name = "shutdownButton";
            this.shutdownButton.Size = new System.Drawing.Size(23, 23);
            this.shutdownButton.TabIndex = 0;
            this.shutdownButton.UseVisualStyleBackColor = true;
            this.shutdownButton.Click += new System.EventHandler(this.Shutdown_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 33);
            this.Controls.Add(this.clientDropList);
            this.Controls.Add(this.companyDropList);
            this.Controls.Add(this.timePassed);
            this.Controls.Add(this.infoButton);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.recordButton);
            this.Controls.Add(this.shutdownButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Video Capture (special software for Don K.)";
            this.TopMost = true;
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button shutdownButton;
        private Button recordButton;
        private Button stopButton;
        private Label timePassed;
        private ComboBox companyDropList;
        private ComboBox clientDropList;
        private Button infoButton;
    }
}

