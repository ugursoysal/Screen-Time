﻿namespace Video_Capture_DonK
{
    partial class Information
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Information));
            this.captureTree = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // captureTree
            // 
            this.captureTree.Location = new System.Drawing.Point(13, 13);
            this.captureTree.Name = "captureTree";
            this.captureTree.Size = new System.Drawing.Size(775, 425);
            this.captureTree.TabIndex = 0;
            // 
            // Information
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.captureTree);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Information";
            this.Text = "Capture List";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Information_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView captureTree;
    }
}