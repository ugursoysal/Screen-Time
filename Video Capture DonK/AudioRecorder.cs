using NAudio.Wave;
using System.IO;

namespace Video_Capture_DonK
{
    public class AudioRecorder
    {

        WaveInEvent waveIn = null;
        WaveFileWriter writer = null;
        readonly string FilePath;
        readonly string FileName;
        //readonly int InputDeviceIndex;

        public AudioRecorder(string filePath, string fileName)
        {
            //this.InputDeviceIndex = inputDeviceIndex;
            this.FileName = fileName;
            this.FilePath = filePath;
            string path = Path.Combine(FilePath, FileName + ".wav");
            int version = 0;
            while (File.Exists(path))
            {
                version++;
                path = Path.Combine(FilePath, FileName + "_" + version.ToString("00") + ".wav");
            }

            waveIn = new WaveInEvent();
            waveIn.DataAvailable += this.SourceStreamDataAvailable;

            writer = new WaveFileWriter(path, waveIn.WaveFormat);
            waveIn.StartRecording();
        }

        public void SourceStreamDataAvailable(object sender, WaveInEventArgs e)
        {
            writer.Write(e.Buffer, 0, e.BytesRecorded);
        }

        public void StopRecording()
        {
            waveIn.StopRecording();
            writer?.Dispose();
            writer = null;
            waveIn?.Dispose();
            waveIn = null;
        }
    }
}
