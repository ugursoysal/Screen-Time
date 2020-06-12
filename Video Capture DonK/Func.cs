using System;
using System.Collections.Generic;
using System.IO;

namespace Video_Capture_DonK
{
    public static class Func
    {
        public static string GetTimeText(int sec)
        {
            int seconds = sec % 60;
            int minutes = sec / 60;
            int hours = (sec > 3600) ? sec / 3600 : 0;
            string hour = hours.ToString("00");
            string mins = minutes.ToString("00");
            string secs = seconds.ToString("00");
            return $"{hour}:{mins}:{secs}";
        }
        public static string GetVideosDirectory()
        {
            string path = Directory.GetParent(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)).FullName;
            if (Environment.OSVersion.Version.Major >= 6)
            {
                path = Path.Combine(Directory.GetParent(path).ToString(), "ScreenTime");
            }
            return path;
        }
    }
}
