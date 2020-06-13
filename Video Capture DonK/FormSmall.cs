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
    }
}
