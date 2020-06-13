using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
                    File.Create(filename).Close();
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
                string json = File.ReadAllText(filename);
                if (json != null && json.Length > 0)
                    return JsonConvert.DeserializeObject<List<Company>>(json);
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
                    File.Create(filename).Close();
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
                string json = File.ReadAllText(filename);
                if (json != null && json.Length > 0)
                    return JsonConvert.DeserializeObject<List<CaptureLog>>(json);
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
                    File.Create(filename).Close();
                }
                catch
                {
                    MessageBox.Show("ERROR: Couldn't save to companies database file. Please try again.");
                }
            }
            try
            {
                if (companies != null)
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
                    File.Create(filename).Close();
                }
                catch
                {
                    MessageBox.Show("ERROR: Couldn't save to capture log file. Please try again.");
                }
            }
            try
            {
                if (captureLogs != null)
                    File.WriteAllText(filename, JsonConvert.SerializeObject(captureLogs));
            }
            catch
            {
                MessageBox.Show("ERROR: Couldn't write to capture log file. Please try again.");
                Application.Exit();
            }
        }
        public static int CalculateCompanyTimePassed(string filename, string company)
        {
            int TimePassed = 0;
            List<CaptureLog> captureLogs = LoadCaptureLogs(filename);
            if (captureLogs == null)
                return 0;
            foreach (var x in captureLogs)
            {
                if (x.CompanyName == company && DateTime.Today.Date == x.DateTime.Date)
                {
                    TimePassed += x.TimePassed;
                }
            }
            return TimePassed;
        }
    }
}
