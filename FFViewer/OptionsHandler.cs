using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace FFViewer_cs
{
    [DataContract]
    class AppOptions
    {
        public AppOptions()
        {
            width = 1000;
            height = 600;
            lastFolder = "";
            rememberLastFolder = true;
            deleteTemporary = false;
        }

        [DataMember]
        public int width;
        [DataMember]
        public int height;
        [DataMember]
        public string lastFolder;
        [DataMember]
        public bool rememberLastFolder;
        [DataMember]
        public bool deleteTemporary;
    }

    public class OptionsHandler
    {
        public int Width { get { return opt.width; } set { opt.width = value; } }
        public int Height { get { return opt.height; } set { opt.height = value; } }
        public string LastFolder { get { return opt.lastFolder; } set { opt.lastFolder = value; } }
        public bool RememberLastFolder { get { return opt.rememberLastFolder; } set { opt.rememberLastFolder = value; } }
        public bool DeleteTemporaryFiles { get { return opt.deleteTemporary; } set { opt.deleteTemporary = value; } }

        public OptionsHandler(string appDir, HandleException_d hndlr)
        {
            opt = new AppOptions();
            appDirectory = appDir;
            handler = hndlr;
            json = new DataContractJsonSerializer(typeof(AppOptions));
            LoadOptions();
        }

        ~OptionsHandler()
        {
            SaveOptions();
        }

        private void LoadOptions()
        {
            try
            {
                if (!Directory.Exists(appDirectory + "\\prefs"))
                    Directory.CreateDirectory(appDirectory + "\\prefs");

                FileStream config = new FileStream(appDirectory + "\\prefs\\config.json", FileMode.OpenOrCreate, FileAccess.Read, FileShare.None);
                if (config.Length == 0)
                    return;

                opt = (AppOptions)json.ReadObject(config);
                config.Dispose();
            }
            catch(Exception ex)
            {
                handler(ex);
            }
        }

        private void SaveOptions()
        {
            try
            {
                FileStream config = new FileStream(appDirectory + "\\prefs\\config.json", FileMode.Create, FileAccess.Write, FileShare.None);
                json.WriteObject(config, opt);
                config.Dispose();
            }
            catch(Exception ex)
            {
                handler(ex);
            }
        }

        AppOptions opt;
        DataContractJsonSerializer json;
        string appDirectory;
        HandleException_d handler;
    }
}
