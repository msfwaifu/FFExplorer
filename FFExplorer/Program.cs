﻿using System;
using System.Windows.Forms;

//TODO: localized strings export:
//      CSV
//      .str
//TODO: sound seek and extract

namespace FFExplorer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                string[] args = Environment.GetCommandLineArgs();
                foreach (string arg in args)
                {
                    if (arg == "-u" || arg == "--update")
                    {
                        Updater.ApplyUpdate(args);
                        return;
                    }
                }
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
            catch(Exception ex)
            {
                Form1.HandleException(ex);
            }
        }
    }
}
