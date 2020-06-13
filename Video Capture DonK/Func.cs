using System;
using System.IO;

namespace Video_Capture_DonK
{
    public static class Func
    {
        public static string GetTimeText(int sec)
        {
            TimeSpan time = TimeSpan.FromSeconds(sec);
            string hour = time.Hours.ToString("00");
            string mins = time.Minutes.ToString("00");
            string secs = time.Seconds.ToString("00");
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
