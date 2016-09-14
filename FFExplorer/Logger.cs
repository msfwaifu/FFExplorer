using System;
using System.IO;

namespace FFExplorer
{
    /// <summary>
    /// A delegate used to apply some logic when logger prints line.
    /// </summary>
    /// <param name="timestamp">Contains line timestamp.</param>
    /// <param name="line">Contains line logger wanted to print.</param>
    public delegate void OnWriteLine_d(string timestamp, string line);

    /// <summary>
    /// A delegate used to apply some logic when logger prints exception.
    /// </summary>
    /// <param name="timestamp">Contains line timestamp.</param>
    /// <param name="ex">Contains exception logger wanted to print.</param>
    public delegate void OnWriteException_d(string timestamp, Exception ex);

    class Logger
    {
        static string appWorkingDirectory = System.Windows.Forms.Application.StartupPath;
        static string logsDirectory = appWorkingDirectory + "/logs/";
        static string logPathFormat = logsDirectory + "ffviewer_log_{0}.log";

        public event OnWriteLine_d OnWriteLine;
        public event OnWriteException_d OnWriteException;

        public Logger()
        {
            thislock = new object();

            if (!Directory.Exists(logsDirectory))
                Directory.CreateDirectory(logsDirectory);

            UpdateTime();

            string logTime = string.Format("{0}.{1}.{2}.{3}.{4}.{5}", time.Year, time.Month, time.Day, time.Hour, time.Minute, time.Second);
            logPath = string.Format(logPathFormat, logTime);
            sw = new StreamWriter(logPath, true);
        }
        
        ~Logger()
        {
            //sw.Flush();
            //sw.Dispose(); // What do you mean object already disposed? How?!
        }

        public void PrintLine(string line)
        {
            UpdateTime();
            sw.WriteLine(timestamp + line);
            sw.Flush();
            OnWriteLine?.Invoke(timestamp, line);
        }

        public void PrintException(Exception ex)
        {
            UpdateTime();
            sw.WriteLine(timestamp + ex.Message + "\r\n" + ex.StackTrace);
            sw.Flush();
            OnWriteException?.Invoke(timestamp, ex);
        }

        public void LogsCleanup(int logDaysLimit)
        {
            System.Threading.Tasks.Task.Run(()=> { LogsCleanupSync(logDaysLimit); });
        }

        private void LogsCleanupSync(int logDaysLimit)
        {
            UpdateTime();
            DirectoryInfo di = new DirectoryInfo(logsDirectory);

            foreach (FileInfo fi in di.GetFiles("*.log"))
                if (time.Subtract(fi.CreationTime).Days > logDaysLimit)
                    File.Delete(fi.Name);
            
        }

        private void UpdateTime()
        {
            lock (thislock)
            {
                time = DateTime.Now;
                timestamp = string.Format("[{0:0000}/{1:00}/{2:00}, {3:00}:{4:00}:{5:00}]: ", time.Year, time.Month, time.Day, time.Hour, time.Minute, time.Second);
            }
        }

        StreamWriter sw;
        DateTime time;
        string logPath = "";
        string timestamp = "";
        object thislock;
    }
}
