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
        CaptureLog captureLog = null;
        string selectedCompany = null;
        private readonly string VIDEOS_DIRECTORY = Path.Combine(Directory.GetCurrentDirectory(), "videos");
        private readonly string companiesFile = "companies.json";
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
            if (!File.Exists(capturesFile))
                File.CreateText(capturesFile);
            companies = DatabaseHandler.ReadCompanies(companiesFile);
        }
        private void PopulateDropLists()
        {
            companyDropList.Items.Clear();
            if (companies != null)
                companyDropList.Items.AddRange(companies.Select(a => a.Name).ToArray());
            companyDropList.Items.Add("(New company...)");
            companyDropList.Items.Add("(Delete company...)");
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
                SaveRecord();
                Application.Exit();
            }
        }
        private void Record_Click(object sender, EventArgs e)
        {
            if(selectedCompany == null || selectedCompany == "(Select a company)")
            {
                MessageBox.Show("Please select a company.");
            }
            else if (rec == null)
            {
                StartRecording();
            }
            else
            {
                if (Program.Paused)
                {
                    timeTimer.Enabled = true;
                    timeTimer.Start();
                    recordButton.BackgroundImage = Properties.Resources.pause;
                    indicatorLight.BackgroundImage = Properties.Resources.recording;
                }
                else
                {
                    timeTimer.Stop();
                    timeTimer.Enabled = false;
                    recordButton.BackgroundImage = Properties.Resources.play;
                    indicatorLight.BackgroundImage = Properties.Resources.record;
                }
                Program.Paused = !Program.Paused;
            }
        }
        private void TimeTimer_Tick(object sender, EventArgs e)
        {
            TimePassed++;
            timePassed.Text = Func.GetTimeText(TimePassed);
        }
        private void StartRecording()
        {
            Program.Paused = false;
            recordButton.BackgroundImage = Properties.Resources.pause;
            indicatorLight.BackgroundImage = Properties.Resources.recording;
            captureLog = new CaptureLog(selectedCompany);
            rec = new Recorder(new RecorderParams(Path.Combine(VIDEOS_DIRECTORY, captureLog.GetFilename() + ".avi"), 27, SharpAvi.KnownFourCCs.Codecs.MotionJpeg, 100));
            TimePassed = 0;
            timeTimer.Enabled = true;
            timeTimer.Start();
        }
        private void SaveRecord()
        {
            if (rec != null)
            {
                timeTimer.Enabled = false;
                timeTimer.Stop();
                indicatorLight.BackgroundImage = Properties.Resources.record;
                recordButton.BackgroundImage = Properties.Resources.play;
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
                MessageBox.Show("Video has been successfully captured and saved to the directory." + Environment.NewLine + Environment.NewLine + "(Duration: " + Func.GetTimeText(captureLog.TimePassed) + ")", captureLog.CompanyName);
            }
        }
        private void CompanyDropList_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (companyDropList.SelectedItem != null)
            {
                if (companyDropList.SelectedItem.ToString() == "(New company...)")
                {
                    string promptValue = Prompt.ShowDialog("Please enter the company's name:", "Add New Company", "Add");
                    if (promptValue.Length > 30)
                    {
                        MessageBox.Show("Company name should be less than 30 characters.");
                    }
                    else if (promptValue.Length > 0)
                    {
                        if (companies == null)
                        {
                            companies = new List<Company>();
                        }
                        companies.Add(new Company(promptValue));
                        DatabaseHandler.SaveCompanies(companiesFile, companies);
                        PopulateDropLists();
                        companyDropList.SelectedItem = promptValue;
                    }
                }
                else if (companyDropList.SelectedItem.ToString() == "(Delete company...)")
                {
                    string promptValue = Prompt.ShowDialog("Please enter the company's name:", "Delete Existing Company", "Delete");
                    if (promptValue.Length > 30)
                    {
                        MessageBox.Show("Company name should be less than 30 characters.");
                    }
                    else if(promptValue.Length > 0)
                    {
                        if (companies == null)
                        {
                            companies = new List<Company>();
                        }
                        foreach (var x in companies)
                        {
                            if (x.Name == promptValue)
                            {
                                companies.Remove(x);
                                break;
                            }
                        }
                        DatabaseHandler.SaveCompanies(companiesFile, companies);
                        PopulateDropLists();
                        companyDropList.SelectedItem = "(Select a company)";
                        companyLabel.Text = "(Select a company)";
                    }
                }
                else
                {
                    if (rec == null)
                    {
                        selectedCompany = companyDropList.SelectedItem.ToString();
                        companyLabel.Text = selectedCompany;
                    }
                    else
                    {
                        SaveRecord();
                        selectedCompany = companyDropList.SelectedItem.ToString();
                        companyLabel.Text = selectedCompany;
                        StartRecording();
                    }
                }
            }
        }
        private void NotesButton_Click(object sender, EventArgs e)
        {
            if (selectedCompany == null || selectedCompany == "(Select a company)")
            {
                MessageBox.Show("Please select a company.");
            }else if(rec == null)
            {
                MessageBox.Show("You can only add notes while you're recording.");
            }
            else{
                Information information = new Information(selectedCompany, Func.GetTimeText(captureLog.TimePassed));
                information.Show();
            }
        }
    }
}
