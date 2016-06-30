using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System;
using System.IO;
using System.Net;

namespace FFViewer_cs
{
    /// <summary>
    /// A delegate used when updating process is done.
    /// </summary>
    public delegate void UpdateDone_d();

    /// <summary>
    /// A delegate used when downloading of file completed.
    /// </summary>
    /// <param name="fileName">Contains actual file name of saved file.</param>
    public delegate void FileDownloadComplete_d(string fileName);

    /// <summary>
    /// A delegate used when some updates becomes available.
    /// </summary>
    public delegate void UpdateAvailable_d();

    /// <summary>
    /// A class used for update whole application.
    /// </summary>
    class Updater
    {
        public event HandleException_d OnExceptionRaised;
        public event UpdateAvailable_d OnUpdateAvailable;
        public event UpdateDone_d OnUpdateDone;
        public event FileDownloadComplete_d OnFileDownloaded;

        /// <summary>
        /// Constructor.
        /// </summary>
        public Updater()
        {
            WC = new WebClient();
            WC.DownloadStringCompleted += WC_DownloadStringCompleted;
            WC.DownloadDataCompleted += WC_DownloadDataCompleted;

            wipCount = 0;
            thislock = new object();
        }

        ~Updater()
        {
            WC.Dispose();
        }

        /// <summary>
        /// Applies newly downloaded files and restarting program from correct location.
        /// </summary>
        /// <param name="appArgs">All arguments that should be passed to application after updating. "-u" or "--update" will be ignored</param>
        public static void ApplyUpdate(string[] appArgs)
        {
            if (!File.Exists(updateInfoFilePath))
                return;

            using (FileStream fs = new FileStream(updateInfoFilePath, FileMode.Open))
                updInfo = jsonSerializer.ReadObject(fs) as UpdateInfo;

            for(int i = 0; i < updInfo.FilePath.Length; ++i)
            {
                string oldFilePath = exeDir.Replace("updates/", "") + updInfo.FilePath[i];
                string newFilePath = exeDir + updInfo.FilePath[i];

                if (!File.Exists(newFilePath))
                    continue;

                File.Copy(newFilePath, oldFilePath, true);
                File.Delete(newFilePath);
            }

            File.Delete(updateInfoFilePath);
            string args = "";
            string newExePath = exeDir.Replace("updates/", "/FFViewer.exe");
            foreach (string s in appArgs)
                if(s != "-u" && s != "--update")
                    args += s;

            System.Diagnostics.Process.Start(newExePath, args);
        }

        /// <summary>
        /// Aborts current updating procedure.
        /// </summary>
        public void Abort()
        {
            WC.CancelAsync();
        }

        /// <summary>
        /// Downloads all required files using asynchoronous operations.
        /// </summary>
        /// <exception cref="WebException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidDataContractException"></exception>
        /// <exception cref="SerializationException"></exception>
        public void DownloadUpdate()
        {
            if (!updInfo.Loaded)
                throw new ArgumentException("Error: attempting to download update whereas no update information available");

            int filesCount = updInfo.FilePath.Length == updInfo.FileURL.Length ? (updInfo.FileURL.Length == updInfo.MD5.Length ? updInfo.MD5.Length : 0) : 0;
            if (filesCount == 0)
                throw new ArgumentException("Error: update information is corrupted or incomplete");

            using (FileStream fs = new FileStream(updateInfoFilePath, FileMode.Create))
            {
                jsonSerializer.WriteObject(fs, updInfo);
                fs.Flush();
            }

            wipCount = filesCount;
            for (int i = 0; i < filesCount; ++i)
                WC.DownloadDataAsync(new Uri(rawUrl + updInfo.FileURL[i]), i);
        }

        private void WC_DownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e)
        {
            try
            {
                int fileIndex = (int)sender;
                File.WriteAllBytes(updateDir + updInfo.FilePath[fileIndex], e.Result);
                OnFileDownloaded?.Invoke(updInfo.FilePath[fileIndex]);
                lock (thislock)
                {
                    wipCount--;
                    if (wipCount == 0)
                        OnUpdateDone?.Invoke();
                }
            }
            catch(Exception ex)
            {
                OnExceptionRaised?.Invoke(ex);
            }
        }

        private void WC_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error != null)
                return;

            try
            {
                using (MemoryStream ms = new MemoryStream(System.Text.Encoding.ASCII.GetBytes(e.Result)))
                {
                    updInfo = jsonSerializer.ReadObject(ms) as UpdateInfo;
                    updInfo.Loaded = true;
                }

                if (IsNewerVersionAvailable())
                    OnUpdateAvailable?.Invoke();
            }
            catch(Exception ex)
            {
                OnExceptionRaised?.Invoke(ex);
            }
        }

        private bool IsNewerVersionAvailable()
        {
            Version currentVersion = new Version(System.Windows.Forms.Application.ProductVersion);
            Version newVersion = new Version(updInfo.Version);
            return currentVersion.CompareTo(newVersion) < 0;
        }

        /// <summary>
        /// Download update information from github.
        /// </summary>
        public void GetUpdateInfo()
        {
            if (!Directory.Exists(updateDir))
                Directory.CreateDirectory(updateDir);

            WC.DownloadStringAsync(new Uri(updateInfoFileUrl));         
        }

        static DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(UpdateInfo));
        
        private WebClient WC;
        private int wipCount;
        private object thislock;

        private static UpdateInfo updInfo;

        private static string baseUrl = "https://github.com/T-Maxxx/FFViewer/";
        private static string rawUrl = baseUrl + "raw/master/";
        private static string releaseUrl = rawUrl + "bin/Release/";
        
        private static string exePath = System.Windows.Forms.Application.ExecutablePath;
        private static string exeDir = System.Windows.Forms.Application.StartupPath;
        private static string updateInfoFilename = "updateInformation.json";
        private static string updateDir = exeDir + "/updates/";
        private static string updateInfoFileUrl = releaseUrl + updateInfoFilename;
        private static string updateInfoFilePath = updateDir + updateInfoFilename;
    }

    [DataContract]
    class UpdateInfo
    {
        [DataMember]
        public string Version = "";
        [DataMember]
        public string Changelog = "";
        [DataMember]
        public string[] FileURL = null;
        [DataMember]
        public string[] FilePath = null;
        [DataMember]
        public string[] MD5 = null;

        public bool Loaded
        {
            get
            {
                return loaded;
            }
            set
            {
                loaded = value;
            }
        }

        private bool loaded = false;
    }
}
