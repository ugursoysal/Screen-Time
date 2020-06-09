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
        private readonly string capturesFile = "capture_logs.json";
        public Information()
        {
            InitializeComponent();
        }
        class Match
        {
            public string Company { get; set; }
            public string Client { get; set; }
            public Match(string comp, string cli)
            {
                Company = comp;
                Client = cli;
            }
        }
        private void Information_Load(object sender, EventArgs e)
        {
            List<CaptureLog> captureLogs = DatabaseHandler.LoadCaptureLogs(capturesFile);
            if (captureLogs != null)
            {
                List<Match> combinations = new List<Match>();
                foreach (var x in captureLogs)
                {
                    if (combinations.Count(a => a.Client == x.ClientName && a.Company == x.CompanyName) == 0)
                    {
                        combinations.Add(new Match(x.CompanyName, x.ClientName));
                    }
                }
                foreach (var x in combinations)
                {
                    List<TreeNode> newTree = new List<TreeNode>();
                    foreach (var c in captureLogs)
                    {
                        if (c.ClientName == x.Client && c.CompanyName == x.Company)
                        {
                            newTree.Add(new TreeNode(Func.GetTimeText(c.TimePassed) + " (date: " + c.DateTime.ToLocalTime().ToString() + ")"));
                        }
                    }
                    TreeNode[] array = newTree.ToArray();
                    TreeNode newNode = new TreeNode(x.Client + " (company: " + x.Company + ")", array);
                    captureTree.Nodes.Add(newNode);
                }
            }
        }
    }
}
