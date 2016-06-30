using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System;
using System.IO;
using System.Net;

namespace FFViewer_cs
{
    /// <summary>
    /// A delegate used when updating process done.
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

    class Updater
    {
        public event HandleException_d OnExceptionRaised;
        public event UpdateAvailable_d OnUpdateAvailable;
        public event UpdateDone_d OnUpdateDone;
        public event FileDownloadComplete_d OnFileDownloaded;

        /// <summary>
        /// Initializes new <see cref="Updater"/> instance.
        /// </summary>
        public Updater()
        {
            WC = new WebClient();
            WC.DownloadStringCompleted += WC_DownloadStringCompleted;
            WC.DownloadDataCompleted += WC_DownloadDataCompleted;

            wipCount = 0;
            thislock = new object();
            GetUpdateInfo();
        }

        ~Updater()
        {
            WC.Dispose();
        }

        /// <summary>
        /// Applies newly downloaded files and restarting program from correct location.
        /// </summary>
        /// <param name="appArgs">All arguments that should be passed to application after updating. "-u" or "--update" will be ignored</param>
        static public void ApplyUpdate(string[] appArgs)
        {
            throw new NotImplementedException();
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
        public void DownloadUpdate()
        {
            if (!updInfo.Loaded)
                throw new ArgumentException("Error: attempting to download update whereas no update information available");

            int filesCount = updInfo.FilePath.Length == updInfo.FileURL.Length ? (updInfo.FileURL.Length == updInfo.MD5.Length ? updInfo.MD5.Length : 0) : 0;
            if (filesCount == 0)
                throw new ArgumentException("Error: update information is corrupted or incomplete");

            wipCount = filesCount;
            for (int i = 0; i < filesCount; ++i)
                WC.DownloadDataAsync(new Uri(rawUrl + updInfo.FileURL[i]), i);
        }

        private void WC_DownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e)
        {
            try
            {
                int fileIndex = (int)sender;
                File.WriteAllBytes(updatesPath + updInfo.FilePath[fileIndex], e.Result);
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
            try
            {
                DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(UpdateInfo));
                using (MemoryStream ms = new MemoryStream(System.Text.Encoding.ASCII.GetBytes(e.Result)))
                {
                    updInfo = js.ReadObject(ms) as UpdateInfo;
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

        private void GetUpdateInfo()
        {
            WC.DownloadStringAsync(new Uri(releaseUrl + "updateInformation.json"));         
        }

        private UpdateInfo updInfo;
        private WebClient WC;
        private int wipCount;
        private object thislock;

        private const string baseUrl = "https://github.com/T-Maxxx/FFViewer/";
        private const string rawUrl = baseUrl + "raw/master/";
        private const string releaseUrl = rawUrl + "bin/Release/";
        private string updatesPath = System.Windows.Forms.Application.StartupPath + "updates/";
        private string exePath = System.Windows.Forms.Application.ExecutablePath;
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
