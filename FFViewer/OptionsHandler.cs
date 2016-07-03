using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Windows.Forms;

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
        public bool saveTemporary = false;
        [DataMember]
        public bool showLog = true;
    }

    /// <summary>
    /// A handler to simplify work with JSON de-\serialization and accessing saved preferences.
    /// </summary>
    public class OptionsHandler
    {

        static string PreferencesDirName = "prefs";
        static string PreferencesDir = Application.StartupPath + "\\" + PreferencesDirName;
        static string ConfigFileName = "config.json";
        static string ConfigFilePath = PreferencesDir + "\\" + ConfigFileName;

        /// <summary>
        /// Constructor.
        /// </summary>
        public OptionsHandler()
        {
            opt = new AppOptions();
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

        /// <summary>
        /// Gets or sets width of application window.
        /// </summary>
        public int Width
        {
            get
            {
                return opt.width;
            }
            set
            {
                opt.width = value;
            }
        }

        /// <summary>
        /// Gets or sets height of application window.
        /// </summary>
        public int Height
        {
            get
            {
                return opt.height;
            }
            set
            {
                opt.height = value;
            }
        }

        /// <summary>
        /// Gets or sets last folder used by various dialogs.
        /// </summary>
        public string LastFolder
        {
            get
            {
                return opt.lastFolder;
            }
            set
            {
                opt.lastFolder = value;
            }
        }

        /// <summary>
        /// Gets or sets whether to remember last used folder.
        /// </summary>
        public bool RememberLastFolder
        {
            get
            {
                return opt.rememberLastFolder;
            }
            set
            {
                opt.rememberLastFolder = value;
            }
        }

        /// <summary>
        /// Gets or sets whether to delete temporary files such as decompressed zone.
        /// </summary>
        public bool SaveTemporaryFiles
        {
            get
            {
                return opt.saveTemporary;
            }
            set
            {
                opt.saveTemporary = value;
            }
        }

        /// <summary>
        /// Gets or sets whether to show log panel.
        /// </summary>
        public bool ShowLog
        {
            get
            {
                return opt.showLog;
            }
            set
            {
                opt.showLog = value;
            }
        }

        private void LoadOptions()
        {
            if (!Directory.Exists(PreferencesDir))
            {
                Directory.CreateDirectory(PreferencesDir);
                return;
            }
            
            if (!File.Exists(ConfigFilePath))
                return;

            using (FileStream config = new FileStream(ConfigFilePath, FileMode.OpenOrCreate, FileAccess.Read, FileShare.None))
                opt = json.ReadObject(config) as AppOptions;            
        }

        private void SaveOptions()
        {
            using (FileStream config = new FileStream(ConfigFilePath, FileMode.Create, FileAccess.Write, FileShare.None))
                json.WriteObject(config, opt);
        }

        AppOptions opt;
        DataContractJsonSerializer json;
    }
}
