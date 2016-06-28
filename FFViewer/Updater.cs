using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System;
using System.IO;
using System.Net;

namespace FFViewer_cs
{
    public delegate void UpdateDone_d();
    public delegate void FileDownloadComplete_d(string fileName);
    public delegate void UpdateAvailable_d();

    class Updater
    {
        public event HandleException_d OnExceptionRaised;
        public event UpdateAvailable_d OnUpdateAvailable;
        public event UpdateDone_d OnUpdateDone;
        public event FileDownloadComplete_d OnFileDownloaded;

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

        static public void ApplyUpdate(string[] appArgs)
        {
            throw new NotImplementedException();
        }

        public void Abort()
        {
            WC.CancelAsync();
        }

        public void DownloadUpdate()
        {
            try
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
            catch(Exception ex)
            {
                OnExceptionRaised?.Invoke(ex);
            }
        }

        private void WC_DownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e)
        {
            try
            {
                int fileIndex = (int)sender;
                OnFileDownloaded?.Invoke(updInfo.FilePath[fileIndex]);
                //TODO: save files inside [app]/updates/...
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

                if (isNewerVersionAvailable())
                    OnUpdateAvailable?.Invoke();
            }
            catch(Exception ex)
            {
                OnExceptionRaised?.Invoke(ex);
            }
        }

        private bool isNewerVersionAvailable()
        {
            try
            {
                Version currentVersion = new Version(System.Windows.Forms.Application.ProductVersion);
                Version newVersion = new Version(updInfo.Version);
                return newVersion.Major > currentVersion.Major || newVersion.Minor > currentVersion.Minor ||
                    newVersion.Build > currentVersion.Build || newVersion.Revision > currentVersion.Revision;
            }
            catch(Exception ex)
            {
                OnExceptionRaised?.Invoke(ex);
            }
            return false;
        }

        private void GetUpdateInfo()
        {
            try
            {
                WC.DownloadStringAsync(new Uri(releaseUrl + "updateInformation.json"));
            }
            catch(Exception ex)
            {
                OnExceptionRaised?.Invoke(ex);
            }            
        }

        private UpdateInfo updInfo;
        private WebClient WC;
        private int wipCount;
        private object thislock;

        private const string baseUrl = "https://github.com/T-Maxxx/FFViewer/";
        private const string rawUrl = baseUrl + "raw/master/";
        private const string releaseUrl = rawUrl + "bin/Release/";
        private string appPath = System.Windows.Forms.Application.StartupPath;
        private string exePath = System.Windows.Forms.Application.ExecutablePath;
    }

    [DataContract]
    class UpdateInfo
    {
        [DataMember]
        public string Version;
        [DataMember]
        public string Changelog;
        [DataMember]
        public string[] FileURL;
        [DataMember]
        public string[] FilePath;
        [DataMember]
        public string[] MD5;

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
