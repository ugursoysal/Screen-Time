using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        readonly string RecordTime;
        public Information(string selectedCompany, string recTime)
        {
            RecordTime = recTime;
            Company = selectedCompany;
            InitializeComponent();
        }
        private void Information_Load(object sender, EventArgs e)
        {
            this.Text = "Notes: " + Company + " (" + RecordTime + ")";
            textBox1.Text = Company;
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
    }
}
