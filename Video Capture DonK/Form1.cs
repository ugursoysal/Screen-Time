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
        Recorder rec = null;
        List<Company> companies = null;
        CaptureLog captureLog = null;
        NotifyIcon notification = null;
        string selectedCompany = null;
        public static readonly string VIDEOS_DIRECTORY = Func.GetVideosDirectory();
        private readonly string companiesFile = "companies.json";
        private readonly string capturesFile = "capture_logs.json";
        bool wasPlaying = false;
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        public int TimePassed = 0;
        public int CompanyTime = 0;
        readonly System.Windows.Forms.Timer timeTimer = null;
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
                File.CreateText(companiesFile).Close();
            if (!File.Exists(capturesFile))
                File.CreateText(capturesFile).Close();
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
            timePassed.Text = Func.GetTimeText(CompanyTime + TimePassed);

            uint idleCount = GetLastUserInput.GetLastUserInput.GetIdleTickCount();
            TimeSpan timeSpan = TimeSpan.FromMilliseconds(idleCount);
            if (timeSpan.TotalSeconds > 5)
            {
                new Inactivity(this, timeTimer, timePassed).Show();
                timeTimer.Enabled = false;
                timeTimer.Stop();
            }
        }
        private void StartRecording()
        {
            wasPlaying = false;
            CompanyTime = DatabaseHandler.CalculateCompanyTimePassed(capturesFile, selectedCompany);
            Program.Paused = false;
            recordButton.BackgroundImage = Properties.Resources.pause;
            indicatorLight.BackgroundImage = Properties.Resources.recording;
            captureLog = new CaptureLog(selectedCompany);
            string directory = Path.Combine(VIDEOS_DIRECTORY, captureLog.CompanyName);
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);
            rec = new Recorder(new RecorderParams(Path.Combine(directory, captureLog.GetFilename() + ".avi"), 30, SharpAvi.KnownFourCCs.Codecs.Xvid, 100));
            TimePassed = 0;
            timeTimer.Enabled = true;
            timeTimer.Start();
        }
        public void SaveRecord()
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
                new Thread(() =>
                {
                    if (notification != null)
                    {
                        notification.Dispose();
                        notification = null;
                    }
                    notification = new NotifyIcon()
                    {
                        Visible = true,
                        Icon = Icon.ExtractAssociatedIcon(System.Reflection.Assembly.GetExecutingAssembly().Location),
                        BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info,
                        BalloonTipTitle = captureLog.CompanyName,
                        BalloonTipText = "Video has been saved to the user directory." + Environment.NewLine + Environment.NewLine + "(Duration for this session: " + Func.GetTimeText(TimePassed) + ")",
                    };
                    notification.ShowBalloonTip(6000);

                    TimePassed = 0;
                    Thread.Sleep(8000);
                }).Start();
                //MessageBox.Show("Video has been successfully captured and saved to the directory." + Environment.NewLine + Environment.NewLine + "(Duration for this session: " + Func.GetTimeText(captureLog.TimePassed) + ")", captureLog.CompanyName);
            }
        }
        private void CompanyDropList_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (companyDropList.SelectedItem != null && companyDropList.SelectedItem.ToString() != selectedCompany)
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
                        if (rec != null)
                            SaveRecord();
                        if (companies == null)
                        {
                            companies = new List<Company>();
                        }
                        if (companies.Count(a => a.Name == promptValue) > 0)
                        {
                            MessageBox.Show("This company already exists in the companies list.");
                        }
                        else
                        {
                            companies.Add(new Company(promptValue));
                            DatabaseHandler.SaveCompanies(companiesFile, companies);
                            PopulateDropLists();
                            companyLabel.Text = promptValue;
                            CompanyTime = 0;
                            timePassed.Text = Func.GetTimeText(0);
                            companyDropList.SelectedItem = promptValue;
                        }
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
                        if (companies.Count(a => a.Name == promptValue) > 0)
                        {
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
                            if (promptValue == selectedCompany)
                            {
                                if (rec != null)
                                    SaveRecord();
                                selectedCompany = "(Select a company)";
                                companyLabel.Text = selectedCompany;
                                CompanyTime = 0;
                                timePassed.Text = Func.GetTimeText(0);
                                companyDropList.SelectedItem = selectedCompany;
                            }
                        }

                    }
                }
                else
                {
                    if (rec == null)
                    {
                        TimePassed = 0;
                        selectedCompany = companyDropList.SelectedItem.ToString();
                        companyLabel.Text = selectedCompany;
                        CompanyTime = DatabaseHandler.CalculateCompanyTimePassed(capturesFile, selectedCompany);
                        timePassed.Text = Func.GetTimeText(CompanyTime + TimePassed);
                    }
                    else
                    {
                        if (timeTimer.Enabled)
                            wasPlaying = true;
                        SaveRecord();
                        selectedCompany = companyDropList.SelectedItem.ToString();
                        companyLabel.Text = selectedCompany;
                        CompanyTime = DatabaseHandler.CalculateCompanyTimePassed(capturesFile, selectedCompany);
                        if (selectedCompany != "(Select a company)" && selectedCompany.Length > 0 && wasPlaying)
                            StartRecording();
                        timePassed.Text = Func.GetTimeText(CompanyTime + TimePassed);
                    }
                }
            }
        }
        private void NotesButton_Click(object sender, EventArgs e)
        {
            if (selectedCompany == null || selectedCompany == "(Select a company)")
            {
                MessageBox.Show("Please select a company.");
            }
            else if(rec == null)
            {
                MessageBox.Show("You can only add notes while you're recording.");
            }
            else
            {
                try
                {
                    (new Information(selectedCompany, captureLog)).Show();
                }
                catch
                {
                    MessageBox.Show("Error in Notes application.");
                }
            }
        }

        private void Form1_Closing(object sender, FormClosingEventArgs e)
        {
            if (notification != null)
            {
                notification.Dispose();
            }
        }
    }
}
