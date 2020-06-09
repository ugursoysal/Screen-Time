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
            int seconds = sec % 60;
            int minutes = sec / 60;
            string mins = minutes.ToString();
            string secs = seconds.ToString();
            if (minutes < 10)
                mins = "0" + mins;
            if (seconds < 10)
                secs = "0" + secs;
            return $"{mins}:{secs}";
        }
    }
}
