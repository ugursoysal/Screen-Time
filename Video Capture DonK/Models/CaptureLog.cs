using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Video_Capture_DonK.Models
{
    class CaptureLog
    {
        public string CompanyName { get; set; }
        public string ClientName { get; set; }
        public DateTime DateTime { get; set; }
        string DateText { get; set; }
        string TimeText { get; set; }
        public int TimePassed { get; set; }
        public CaptureLog(string company, string client)
        {
            CompanyName = company;
            ClientName = client;
            DateTime dateTime = DateTime.Now;
            DateTime = DateTime.Now;
            DateText = "" + dateTime.Day + dateTime.Month + dateTime.Year;
            TimeText = "" + dateTime.Hour + dateTime.Minute + dateTime.Second;
            TimePassed = 0;
        }
        public string GetFilename()
        {
            return $"{CompanyName}_{ClientName}_{DateText}_{TimeText}";
        }
    }
}
