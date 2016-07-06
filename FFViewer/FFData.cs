using System;
using System.Text;
using System.IO;
using System.Linq; //SequenceEqual

namespace FFViewer_cs
{
    enum FastFileType
    {
        UNKNOWN,
        IW3_UNSIGNED,
    }

    class FFData
    {
        static byte[] HeaderIW3Unsigned = Encoding.ASCII.GetBytes("IWffu100");
        static byte[] HeaderIW3VersionUnsigned = new byte[] { 5, 0, 0, 0 };

        public FFData(string filePath)
        {
            this.filePath = filePath;  
        }

        /// <summary>
        /// Detects header type and calls appropriate header parser.
        /// </summary>
        public void Parse()
        {
            byte[] ffContents;
            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                ffContents = new byte[fs.Length];
                originalSize = fs.Read(ffContents, 0, (int)fs.Length);
            }

            originalSize = ffContents.Length;
            if (originalSize < 8)
                throw new Exception("Not a fastfile"); //TODO: new exception and correct message.

            byte[] ffHeader = ByteHandling.GetBytes(ffContents, 0, 8);
            if (ffHeader.SequenceEqual(HeaderIW3Unsigned))
                Parse_IW3_Unsigned(ffContents);
            else
                throw new Exception("Unknown fastfile type"); //TODO: new exception and correct message.
        }

        public void Clear()
        {
            filePath = "";
            originalSize = 0;
            Array.Clear(version, 0, version.Length);
            Array.Clear(compressedZone, 0, compressedZone.Length);
            ver = FastFileType.UNKNOWN;
        }
        
        public string FilePath
        {
            get
            {
                return filePath;
            }
        }
        
        public byte[] Header
        {
            get
            {
                if (ver == FastFileType.IW3_UNSIGNED)
                    return HeaderIW3Unsigned;
                else if (ver == FastFileType.UNKNOWN)
                    throw new Exception("FFData not parsed"); //TODO: change exception type and message

                return null;
            }
        }

        
        public byte[] Version
        {
            get
            {
                return version;
            }
        }
             
        public byte[] CompressedZone
        {
            get
            {
                return compressedZone;
            }
            set
            {
                compressedZone = value;
            }
        }

        public int OriginalSize
        {
            get
            {
                return originalSize;
            }
        }

        private void Parse_IW3_Unsigned(byte[] ff)
        {
            version = ByteHandling.GetBytes(ff, 8, 12);
            compressedZone = ByteHandling.GetBytes(ff, 12);

            if (!version.SequenceEqual(HeaderIW3VersionUnsigned))
                throw new Exception("Warning: fastfile version differs from default for this fastfile type."); //TODO: change exception type and message
        }

        string filePath;
        int originalSize;
        byte[] version = new byte[4]; // Version can be different than default for fastfile.
        byte[] compressedZone;
        FastFileType ver = FastFileType.UNKNOWN;
    }
}
