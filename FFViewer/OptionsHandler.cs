using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace FFViewer_cs
{
    [DataContract]
    class AppOptions
    {
        [DataMember]
        public int width = 1000;
        [DataMember]
        public int height = 600;
        [DataMember]
        public string lastFolder = "";
        [DataMember]
        public bool rememberLastFolder = true;
        [DataMember]
        public bool deleteTemporary = false;
    }

    /// <summary>
    /// A handler to simplify work with JSON de-\serialization and accessing saved preferences.
    /// </summary>
    public class OptionsHandler
    {
        /// <summary>
        /// Raised when exception occured.
        /// </summary>
        event HandleException_d OnExceptionRaised;

        /// <summary>
        /// Gets or sets width of application window.
        /// </summary>
        public int Width { get { return opt.width; } set { opt.width = value; } }

        /// <summary>
        /// Gets or sets height of application window.
        /// </summary>
        public int Height { get { return opt.height; } set { opt.height = value; } }

        /// <summary>
        /// Gets or sets last folder used by various dialogs.
        /// </summary>
        public string LastFolder { get { return opt.lastFolder; } set { opt.lastFolder = value; } }

        /// <summary>
        /// Gets or sets whether to remember last used folder.
        /// </summary>
        public bool RememberLastFolder { get { return opt.rememberLastFolder; } set { opt.rememberLastFolder = value; } }

        /// <summary>
        /// Gets or sets whether to delete temporary files such as decompressed zone.
        /// </summary>
        public bool DeleteTemporaryFiles { get { return opt.deleteTemporary; } set { opt.deleteTemporary = value; } }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="appDir">Path to directory of application.</param>
        public OptionsHandler(string appDir)
        {
            opt = new AppOptions();
            appDirectory = appDir;
            json = new DataContractJsonSerializer(typeof(AppOptions));
            LoadOptions();
        }

        /// <summary>
        /// Destructor.
        /// </summary>
        ~OptionsHandler()
        {
            SaveOptions();
        }

        private void LoadOptions()
        {
            try
            {
                if (!Directory.Exists(appDirectory + "\\prefs"))
                {
                    Directory.CreateDirectory(appDirectory + "\\prefs");
                    return;
                }
                
                if (!File.Exists(appDirectory + "\\prefs\\config.json"))
                    return;

                using (FileStream config = new FileStream(appDirectory + "\\prefs\\config.json", FileMode.OpenOrCreate, FileAccess.Read, FileShare.None))
                    opt = json.ReadObject(config) as AppOptions;
            }
            catch(Exception ex)
            {
                OnExceptionRaised?.Invoke(ex);
            }
        }

        private void SaveOptions()
        {
            try
            {
                using (FileStream config = new FileStream(appDirectory + "\\prefs\\config.json", FileMode.Create, FileAccess.Write, FileShare.None))
                    json.WriteObject(config, opt);
            }
            catch(Exception ex)
            {
                OnExceptionRaised?.Invoke(ex);
            }
        }

        AppOptions opt;
        DataContractJsonSerializer json;
        string appDirectory;
    }
}
