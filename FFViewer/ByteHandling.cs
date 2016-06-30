using System;
using System.Windows.Forms;

namespace FFViewer_cs
{
    /// <summary>
    /// NI
    /// </summary>
    public class ByteHandling
    {
        /// <summary>
        /// NI
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="seekBytes"></param>
        /// <param name="offset"></param>
        /// <param name="endOffset"></param>
        /// <returns></returns>
        public static int CountBytes(byte[] bytes, byte[] seekBytes, int offset = 0, int endOffset = -1)
        {
            int endPos = endOffset == -1 ? bytes.Length : endOffset;
            int currentByte = 0;
            int count = 0;
            for (int i = offset; i < endPos; ++i)
            {
                if (bytes[i] == seekBytes[currentByte])
                    currentByte++;
                else
                    currentByte = 0;

                if (currentByte >= seekBytes.Length)
                {
                    count++;
                    currentByte = 0;
                }
            }
            return count;
        }

        /// <summary>
        /// NI
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="seekBytes"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static int FindBytes(byte[] bytes, byte[] seekBytes, int offset)
        {
            int currentByte = 0;

            for (int i = offset; i < bytes.Length; ++i)
            {
                if (bytes[i] == seekBytes[currentByte])
                    currentByte++;
                else
                    currentByte = 0;

                if (currentByte >= seekBytes.Length)
                    return i - (seekBytes.Length - 1);
            }

            return -1;
        }

        /// <summary>
        /// NI
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="seekByte"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static int FindByte(byte[] bytes, byte seekByte, int offset)
        {
            if (offset > bytes.Length)
                return -1;

            for (int i = offset; i < bytes.Length; ++i)
                if (bytes[i] == seekByte)
                    return i;

            return -1;
        }

        /// <summary>
        /// NI
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="seekByte"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static int FindByteBackward(byte[] bytes, byte seekByte, int offset)
        {
            if (offset > bytes.Length)
                return -1;

            for (int i = offset; i >= 0; --i)
                if (bytes[i] == seekByte)
                    return i;

            return -1;
        }

        /// <summary>
        /// NI
        /// </summary>
        /// <param name="allBytes"></param>
        /// <param name="startOffset"></param>
        /// <param name="reverseBytes"></param>
        /// <returns></returns>
        public static int GetDWORD(byte[] allBytes, int startOffset, bool reverseBytes = true)
        {
            byte[] tableIndexBytes = new byte[4];
            for (int i = 0; i < 4; ++i)
                tableIndexBytes[i] = allBytes[startOffset + i];

            int result = 0;
            try
            {
                if (!reverseBytes)
                    Array.Reverse(tableIndexBytes);

                result = BitConverter.ToInt32(tableIndexBytes, 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show("При получении данных из массива произошла ошибка:\n" + ex.Message + "\n\nСтек вызовов:\n" + ex.StackTrace, "Ошибка", MessageBoxButtons.OK);
                Application.Exit();
            }
            return result;
        }

        /// <summary>
        /// NI
        /// </summary>
        /// <param name="allBytes"></param>
        /// <param name="startOffset"></param>
        /// <param name="reverseBytes"></param>
        /// <returns></returns>
        public static int GetDWORD3(byte[] allBytes, int startOffset, bool reverseBytes = true)
        {
            byte[] tableIndexBytes = new byte[4];
            for (int i = 1; i < 5; ++i)
                tableIndexBytes[i] = allBytes[startOffset + i];

            int result = 0;
            try
            {
                if (!reverseBytes)
                    Array.Reverse(tableIndexBytes);

                result = BitConverter.ToInt32(tableIndexBytes, 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show("При получении данных из массива произошла ошибка:\n" + ex.Message + "\n\nСтек вызовов:\n" + ex.StackTrace, "Ошибка", MessageBoxButtons.OK);
                Application.Exit();
            }

            return result;
        }

        /// <summary>
        /// NI
        /// </summary>
        /// <param name="allBytes"></param>
        /// <param name="startOffset"></param>
        /// <param name="dword"></param>
        /// <param name="reverse"></param>
        /// <returns></returns>
        public static byte[] SetDWORD(byte[] allBytes, int startOffset, int dword, bool reverse = true)
        {
            try
            {
                byte[] wordBytes = BitConverter.GetBytes(dword);
                if (!reverse)
                    Array.Reverse(wordBytes);

                for (int i = 0; i < 4; ++i)
                    allBytes[i] = wordBytes[i];
            }
            catch (Exception ex)
            {
                MessageBox.Show("При изменении данных в массиве произошла ошибка:\n" + ex.Message + "\n\nСтек вызовов:\n" + ex.StackTrace, "Ошибка", MessageBoxButtons.OK);
                Application.Exit();
            }
            return allBytes;
        }

        /// <summary>
        /// NI
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="offset"></param>
        /// <param name="endoffset"></param>
        /// <returns></returns>
        public static string GetString(byte[] bytes, int offset, int endoffset)
        {
            byte[] byteselection = new byte[endoffset - offset];
            for (int i = offset; i < endoffset; ++i)
                byteselection[i - offset] = bytes[i];
            string result = "";
            try
            {
                result = System.Text.Encoding.ASCII.GetString(byteselection);
            }
            catch (Exception ex)
            {
                MessageBox.Show("При получении строки произошла ошибка:\n" + ex.Message, "Ошибка", MessageBoxButtons.OK);
                Application.Exit();
            }
            return result;
        }

        /// <summary>
        /// NI
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="startOffset"></param>
        /// <param name="endOffset"></param>
        /// <returns></returns>
        public static byte[] RemoveBytes(byte[] bytes, int startOffset, int endOffset)
        {

            byte[] result = new byte[bytes.Length - endOffset + startOffset];
            try
            {
                Array.ConstrainedCopy(bytes, 0, result, 0, startOffset);
                Array.ConstrainedCopy(bytes, endOffset, result, startOffset, bytes.Length - endOffset);
            }
            catch (Exception ex)
            {
                MessageBox.Show("При добавлении данных в массив произошла ошибка:\n" + ex.Message + "\n\nСтек вызовов:\n" + ex.StackTrace, "Ошибка", MessageBoxButtons.OK);
                Application.Exit();
            }
            return result;
        }

        /// <summary>
        /// NI
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="add"></param>
        /// <param name="startOffset"></param>
        /// <returns></returns>
        public static byte[] AddBytes(byte[] bytes, byte[] add, int startOffset)
        {
            int newLength = bytes.Length + add.Length;
            byte[] result = new byte[newLength];
            try {
                Array.ConstrainedCopy(bytes, 0, result, 0, startOffset);
                Array.ConstrainedCopy(add, 0, result, startOffset, add.Length);
                Array.ConstrainedCopy(bytes, startOffset, result, startOffset + add.Length, bytes.Length - startOffset);
            }
            catch (Exception ex)
            {
                MessageBox.Show("При добавлении данных в массив произошла ошибка:\n" + ex.Message + "\n\nСтек вызовов:\n" + ex.StackTrace, "Ошибка", MessageBoxButtons.OK);
                Application.Exit();
            }
            return result;
        }

        /// <summary>
        /// NI
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="offset"></param>
        /// <param name="replacement"></param>
        /// <param name="finishWithNullByte"></param>
        /// <returns></returns>
        public static byte[] ReplaceBytes(byte[] bytes, int offset, byte[] replacement, bool finishWithNullByte = true)
        {
            try
            {
                Array.ConstrainedCopy(replacement, 0, bytes, offset, replacement.Length);
                if (finishWithNullByte)
                    bytes[offset + replacement.Length] = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("При замене данных в массиве произошла ошибка:\n" + ex.Message + "\n\nСтек вызовов:\n" + ex.StackTrace, "Ошибка", MessageBoxButtons.OK);
                Application.Exit();
            }
            return bytes;
        }

        /// <summary>
        /// NI
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="startOffset"></param>
        /// <param name="endOffset"></param>
        /// <returns></returns>
        public static byte[] GetBytes(byte[] bytes, int startOffset, int endOffset = -1)
        {
            endOffset = endOffset == -1 ? bytes.Length : endOffset;

            byte[] result = new byte[endOffset - startOffset];

            try
            {
                Array.ConstrainedCopy(bytes, startOffset, result, 0, endOffset - startOffset);
            }
            catch (Exception ex)
            {
                MessageBox.Show("При получении данных из массива произошла ошибка:\n" + ex.Message + "\n\nСтек вызовов:\n" + ex.StackTrace, "Ошибка", MessageBoxButtons.OK);
                Application.Exit();
            }

            return result;
        }

        /// <summary>
        /// NI
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="startOffset"></param>
        /// <param name="length"></param>
        /// <param name="setByte"></param>
        /// <returns></returns>
        public static byte[] SetBytes(byte[] bytes, int startOffset, int length, byte setByte)
        {
            for (int i = startOffset; i < startOffset + length; ++i)
                bytes[i] = setByte;

            return bytes;
        }
    }
}