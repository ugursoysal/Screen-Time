using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Video_Capture_DonK.Models;

namespace Video_Capture_DonK
{
    public partial class Information : Form
    {
        readonly string Company;
        readonly string filename;
        readonly CaptureLog captureLog;
        public Information(CaptureLog capLog)
        {
            captureLog = capLog;
            string directory = Path.Combine(Form1.VIDEOS_DIRECTORY, captureLog.CompanyName);
            filename = Path.Combine(directory, capLog.GetFilename() + ".txt");
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);
            Company = capLog.CompanyName;
            InitializeComponent();
        }
        private void Information_Load(object sender, EventArgs e)
        {
            Text = "Notes: " + Company + " (" + captureLog.DateTime.Date.ToShortDateString() + ")";
            try
            {
                if (!File.Exists(filename))
                    File.Create(filename).Close();
                string text = File.ReadAllText(filename);
                textBox1.Text = text;
            }
            catch(Exception x)
            {
                MessageBox.Show("Error occured while loading the notes of this session." + Environment.NewLine + Environment.NewLine + x.Message);
                this.Close();
            }
            /*
            List<CaptureLog> captureLogs = DatabaseHandler.LoadCaptureLogs(capturesFile);
            if (captureLogs != null)
            {
                List<string> combinations = new List<string>();
                foreach (var x in captureLogs)
                {
                    if (!combinations.Contains(x.CompanyName))
                    {
                        combinations.Add(x.CompanyName);
                    }
                }
                foreach (var x in combinations)
                {
                    List<TreeNode> newTree = new List<TreeNode>();
                    foreach (var c in captureLogs)
                    {
                        if (c.CompanyName == x)
                        {
                            newTree.Add(new TreeNode(Func.GetTimeText(c.TimePassed) + " (date: " + c.DateTime.ToLocalTime().ToString() + ")"));
                        }
                    }
                    TreeNode[] array = newTree.ToArray();
                    TreeNode newNode = new TreeNode(x, array);
                    captureTree.Nodes.Add(newNode);
                }
            }*/
        }

        private void Information_Closing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (!File.Exists(filename))
                    File.Create(filename).Close();
                File.WriteAllText(filename, textBox1.Text);
            }
            catch(Exception x)
            {
                MessageBox.Show("Error occured while saving the notes of this session." + Environment.NewLine + Environment.NewLine + x.Message);
                Dispose();
            }
        }
    }
}
