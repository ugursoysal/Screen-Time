using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Video_Capture_DonK
{
    public static class Func
    {
        public static string GetTimeText(int sec)
        {
            int hours = (sec > 3600) ? sec % 3600 : 0;
            int seconds = sec % 60;
            int minutes = sec / 60;
            string hour = hours.ToString();
            string mins = minutes.ToString();
            string secs = seconds.ToString();
            if (hours < 10)
                hour = "0" + hours;
            if (minutes < 10)
                mins = "0" + mins;
            if (seconds < 10)
                secs = "0" + secs;
            return $"{hour}:{mins}:{secs}";
        }
    }
}
