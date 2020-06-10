using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Video_Capture_DonK.Models;

namespace Video_Capture_DonK
{
    class DatabaseHandler
    {
        public static List<Company> ReadCompanies(string filename)
        {
            if (!File.Exists(filename))
            {
                try
                {
                    File.Create(filename);
                    return null;
                }
                catch
                {
                    MessageBox.Show("ERROR: Couldn't create companies database file. Please try again.");
                    Application.Exit();
                }
            }
            try
            {
                return JsonConvert.DeserializeObject<List<Company>>(File.ReadAllText(filename));
            }
            catch
            {
                MessageBox.Show("ERROR: Couldn't read companies database file. Please try again.");
                Application.Exit();
            }
            return null;
        }

        public static List<CaptureLog> LoadCaptureLogs(string filename)
        {
            if (!File.Exists(filename))
            {
                try
                {
                    File.Create(filename);
                    return null;
                }
                catch
                {
                    MessageBox.Show("ERROR: Couldn't create capture logs database file. Please try again.");
                    Application.Exit();
                }
            }
            try
            {
                return JsonConvert.DeserializeObject<List<CaptureLog>>(File.ReadAllText(filename));
            }
            catch
            {
                MessageBox.Show("ERROR: Couldn't read capture logs database file. Please try again.");
                Application.Exit();
            }
            return null;
        }

        public static void SaveCompanies(string filename, List<Company> companies)
        {
            if (!File.Exists(filename))
            {
                try
                {
                    File.Create(filename);
                }
                catch
                {
                    MessageBox.Show("ERROR: Couldn't save to companies database file. Please try again.");
                }
            }
            try
            {
                File.WriteAllText(filename, JsonConvert.SerializeObject(companies));
            }
            catch
            {
                MessageBox.Show("ERROR: Couldn't write to companies database file. Please try again.");
                Application.Exit();
            }
        }

        public static void SaveCaptureLogs(string filename, List<CaptureLog> captureLogs)
        {
            if (!File.Exists(filename))
            {
                try
                {
                    File.Create(filename);
                }
                catch
                {
                    MessageBox.Show("ERROR: Couldn't save to capture log file. Please try again.");
                }
            }
            try
            {
                File.WriteAllText(filename, JsonConvert.SerializeObject(captureLogs));
            }
            catch
            {
                MessageBox.Show("ERROR: Couldn't write to capture log file. Please try again.");
                Application.Exit();
            }
        }
    }
}
