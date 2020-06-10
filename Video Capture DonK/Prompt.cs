using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Video_Capture_DonK
{
    public static class Prompt
    {
        public static string ShowDialog(string text, string caption, string option)
        {
            Form prompt = new Form()
            {
                Width = 300,
                Height = 120,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen,
                MinimizeBox = false,
                MaximizeBox = false
            };
            Label textLabel = new Label() { Left = 49, Top = 15, Text = text, AutoSize = true };
            TextBox textBox = new TextBox() { Left = 50, Top = 30, Width = 200, MaxLength = 30 };
            Button confirmation = new Button() { Text = option, Left = 150, Width = 100, Top = 50, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }
    }
}
