using System;
using System.Windows.Forms;

namespace Video_Capture_DonK
{
    public partial class Inactivity : Form
    {
        private readonly Form1 main = null;
        readonly Timer inactiveTimer = null;
        readonly Timer timeTimer = null;
        readonly Label timePassed = null;
        private int inactiveTime = 0;
        public Inactivity(Form1 form1, Timer timeTimer, Label timePassed)
        {
            this.TopMost = true;
            this.TopLevel = true;
            this.timePassed = timePassed;
            this.timeTimer = timeTimer;
            if (inactiveTimer == null)
                inactiveTimer = new Timer();
            inactiveTimer.Tick += new EventHandler(InactiveTimer_Tick);
            inactiveTimer.Interval = 1000;
            inactiveTimer.Enabled = true;
            inactiveTimer.Start();
            main = form1;
            InitializeComponent();
        }
        public void InactiveTimer_Tick(object sender, EventArgs e)
        {

            uint idleCount = GetLastUserInput.GetLastUserInput.GetIdleTickCount();
            TimeSpan timeSpan = TimeSpan.FromMilliseconds(idleCount);

            if (timeSpan.TotalSeconds < 2)
            {
                inactiveTimer.Enabled = false;
                inactiveTimer.Stop();
                inactiveTime = 0;
                timeTimer.Enabled = true;
                timeTimer.Start();
                Close();
            }
            else if (inactiveTime > 58)
            {
                inactiveTimer.Enabled = false;
                inactiveTimer.Stop();
                inactiveTime = 0;
                main.SaveRecord();
                Close();
            }
            else
            {
                main.TimePassed++;
                timePassed.Text = Func.GetTimeText(main.CompanyTime + main.TimePassed);
                inactiveTime++;
                progressBar.Value = inactiveTime;
                label1.Text = $"Your capture session will be ended in {59 - inactiveTime} seconds due to inactivity.";
            }
        }
    }
}
