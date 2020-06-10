using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Video_Capture_DonK.Models
{
    public class CaptureLog
    {
        public string CompanyName { get; set; }
        public DateTime DateTime { get; set; }
        string DateText { get; set; }
        string TimeText { get; set; }
        public int TimePassed { get; set; }
        public CaptureLog(string company)
        {
            CompanyName = company;
            DateTime dateTime = DateTime.Now;
            DateTime = DateTime.Now;
            DateText = $"{dateTime.Day:00}-{dateTime.Month:00}-{dateTime.Year:0000}";
            TimeText = $"{dateTime.Hour:00}.{dateTime.Minute:00}.{dateTime.Second:00}";
            TimePassed = 0;
        }
        public string GetFilename()
        {
            return $"{DateText}_{TimeText}";
        }
    }
}
