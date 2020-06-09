using Captura;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Video_Capture_DonK.Models;

namespace Video_Capture_DonK
{
    public partial class Form1 : Form
    {
        System.Windows.Forms.Timer timeTimer = null;
        Recorder rec = null;
        List<Company> companies = null;
        List<Client> clients = null;
        CaptureLog captureLog = null;
        string selectedClient = null;
        string selectedCompany = null;
        private readonly string VIDEOS_DIRECTORY = Path.Combine(Directory.GetCurrentDirectory(), "videos");
        private readonly string companiesFile = "companies.json";
        private readonly string clientsFile = "clients.json";
        private readonly string capturesFile = "capture_logs.json";
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        int TimePassed = 0;
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        public Form1()
        {
            if (timeTimer == null)
                timeTimer = new System.Windows.Forms.Timer();
            timeTimer.Tick += new EventHandler(TimeTimer_Tick);
            timeTimer.Interval = 1000;
            timeTimer.Enabled = false;
            timeTimer.Stop();
            LoadData();
            InitializeComponent();
            PopulateDropLists();
        }
        private void LoadData()
        {
            if (!Directory.Exists(VIDEOS_DIRECTORY))
                Directory.CreateDirectory(VIDEOS_DIRECTORY);
            if (!File.Exists(companiesFile))
                File.CreateText(companiesFile);
            if (!File.Exists(clientsFile))
                File.CreateText(clientsFile);
            if (!File.Exists(capturesFile))
                File.CreateText(capturesFile);
            companies = DatabaseHandler.ReadCompanies(companiesFile);
            clients = DatabaseHandler.ReadClients(clientsFile);
        }
        private void PopulateDropLists()
        {
            companyDropList.Items.Clear();
            clientDropList.Items.Clear();
            if (companies != null)
                companyDropList.Items.AddRange(companies.Select(a => a.Name).ToArray());
            if (clients != null)
                clientDropList.Items.AddRange(clients.Select(a => a.Name).ToArray());
            companyDropList.Items.Add("(New company...)");
            companyDropList.Items.Add("(Delete company...)");
            clientDropList.Items.Add("(New client...)");
            clientDropList.Items.Add("(Delete client...)");
        }
        private void Form1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void Shutdown_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure you want to exit?",
                                        "Closing...",
                                        MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                if (rec != null)
                    rec.Dispose();
                Application.Exit();
            }
        }
        private void Record_Click(object sender, EventArgs e)
        {
            if(selectedCompany == null || selectedClient == null)
            {
                MessageBox.Show("Please select a company/client combination.");
            }
            else if (rec == null)
            {
                Program.Paused = false;
                recordButton.BackgroundImage = Properties.Resources.pause;
                captureLog = new CaptureLog(selectedCompany, selectedClient);
                rec = new Recorder(new RecorderParams(Path.Combine(VIDEOS_DIRECTORY, captureLog.GetFilename() + ".avi"), 27, SharpAvi.KnownFourCCs.Codecs.MotionJpeg, 100));
                TimePassed = 0;
                clientDropList.Enabled = false;
                companyDropList.Enabled = false;
                stopButton.Enabled = true;
                infoButton.Enabled = false;
                timeTimer.Enabled = true;
                timeTimer.Start();
            }
            else
            {
                if (Program.Paused)
                {
                    timeTimer.Enabled = true;
                    timeTimer.Start();
                    recordButton.BackgroundImage = Properties.Resources.pause;
                }
                else
                {
                    timeTimer.Stop();
                    timeTimer.Enabled = false;
                    recordButton.BackgroundImage = Properties.Resources.record;
                }
                Program.Paused = !Program.Paused;
            }
        }
        private void TimeTimer_Tick(object sender, EventArgs e)
        {
            TimePassed++;
            timePassed.Text = Func.GetTimeText(TimePassed);
        }
        private void Stop_Click(object sender, EventArgs e)
        {
            SaveRecord();
        }
        private void SaveRecord()
        {
            if (rec != null)
            {
                clientDropList.Enabled = true;
                companyDropList.Enabled = true;
                infoButton.Enabled = true;
                stopButton.Enabled = false;
                timeTimer.Enabled = false;
                timeTimer.Stop();
                timePassed.Text = "00:00";
                recordButton.BackgroundImage = Properties.Resources.record;
                rec.Dispose();
                rec = null;
                List<CaptureLog> captureLogs = DatabaseHandler.LoadCaptureLogs(capturesFile);
                captureLog.TimePassed = TimePassed;
                if(captureLogs == null)
                {
                    captureLogs = new List<CaptureLog>();
                }
                captureLogs.Add(captureLog);
                DatabaseHandler.SaveCaptureLogs(capturesFile, captureLogs);
                MessageBox.Show("Video has been successfully captured and saved to the directory.");
            }
        }
        private void ClientDropList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (clientDropList.SelectedItem != null)
            {
                if (clientDropList.SelectedItem.ToString() == "(New client...)")
                {
                    string promptValue = Prompt.ShowDialog("Please enter the client's name:", "Add New Client");
                    if(clients == null)
                    {
                        clients = new List<Client>();
                    }
                    clients.Add(new Client(promptValue));
                    DatabaseHandler.SaveClients(clientsFile, clients);
                    PopulateDropLists();
                }
                else if (clientDropList.SelectedItem.ToString() == "(Delete client...)")
                {
                    string promptValue = Prompt.ShowDialog("Please enter the company's name:", "Delete Existing Company");
                    if (clients == null)
                    {
                        clients = new List<Client>();
                    }
                    foreach (var x in clients)
                    {
                        if (x.Name == promptValue)
                        {
                            clients.Remove(x);
                            break;
                        }
                    }
                    DatabaseHandler.SaveClients(clientsFile, clients);
                    PopulateDropLists();
                }
                else
                {
                    selectedClient = clientDropList.SelectedItem.ToString();
                }
            }
        }

        private void CompanyDropList_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (companyDropList.SelectedItem != null)
            {
                if (companyDropList.SelectedItem.ToString() == "(New company...)")
                {
                    string promptValue = Prompt.ShowDialog("Please enter the company's name:", "Add New Company");
                    if (companies == null)
                    {
                        companies = new List<Company>();
                    }
                    companies.Add(new Company(promptValue));
                    DatabaseHandler.SaveCompanies(companiesFile, companies);
                    PopulateDropLists();
                }
                else if (companyDropList.SelectedItem.ToString() == "(Delete company...)")
                {
                    string promptValue = Prompt.ShowDialog("Please enter the company's name:", "Delete Existing Company");
                    if (companies == null)
                    {
                        companies = new List<Company>();
                    }
                    foreach(var x in companies)
                    {
                        if(x.Name == promptValue) {
                            companies.Remove(x);
                            break;
                        }
                    }
                    DatabaseHandler.SaveCompanies(companiesFile, companies);
                    PopulateDropLists();
                }
                else
                {
                    selectedCompany = companyDropList.SelectedItem.ToString();
                }
            }
        }

        private void Info_Click(object sender, EventArgs e)
        {
            Information information = new Information();
            information.Show();
        }
    }
}
