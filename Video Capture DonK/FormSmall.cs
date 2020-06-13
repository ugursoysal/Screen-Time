using System;
using System.Drawing;
using System.Windows.Forms;

namespace Video_Capture_DonK
{
    public partial class FormSmall : Form
    {
        private readonly Form1 Form1 = null;
        public FormSmall(Form1 form1)
        {
            Form1 = form1;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(Form1.Location.X, Form1.Location.Y);
            InitializeComponent();
            SetIndicator();
        }

        private void ScreenTimeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void SetIndicator()
        {
            recordButton.BackgroundImage = Form1.RecordButtonImage;
            indicatorLight.BackgroundImage = Form1.IndicatorImage;
        }
        private void RecordButton_Click(object sender, EventArgs e)
        {
            Form1.Record_Click(sender, e);
            SetIndicator();
        }

        private void FormSmall_Closed(object sender, FormClosedEventArgs e)
        {
            Form1.EnableControls();
            Form1.Show();
        }

        private void ScreenTimeButton_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Form1.ReleaseCapture();
                Form1.SendMessage(this.Handle, Form1.WM_NCLBUTTONDOWN, Form1.HT_CAPTION, 0);
            }
        }

        private void FormSmall_LocationChanged(object sender, EventArgs e)
        {
            Form1.SetDesktopLocation(this.DesktopLocation.X, this.DesktopLocation.Y);
        }

        /*private void ScreenTimeButton_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Form1.ReleaseCapture();
                Form1.SendMessage(Handle, Form1.WM_NCLBUTTONDOWN, Form1.HT_CAPTION, 0);
            }
        }*/
    }
}
