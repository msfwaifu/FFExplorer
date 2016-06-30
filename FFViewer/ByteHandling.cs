using System;

namespace FFViewer_cs
{
    /// <summary>
    /// NI
    /// </summary>
    public class ByteHandling
    {
        /// <summary>
        /// Count bytes in array.
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="seekBytes"></param>
        /// <param name="offset"></param>
        /// <param name="endOffset"></param>
        /// <returns>Count of bytes.</returns>
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
        /// Find first occurrence of bytes in array.
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="seekBytes"></param>
        /// <param name="offset"></param>
        /// <returns>Offset or -1 if not found.</returns>
        public static int FindBytes(byte[] bytes, byte[] seekBytes, int offset = 0)
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
        /// Find first occurrence of byte in array.
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="seekByte"></param>
        /// <param name="offset"></param>
        /// <returns>Offset or -1 if not found.</returns>
        public static int FindByte(byte[] bytes, byte seekByte, int offset = 0)
        {
            if (offset > bytes.Length)
                return -1;

            for (int i = offset; i < bytes.Length; ++i)
                if (bytes[i] == seekByte)
                    return i;

            return -1;
        }

        /// <summary>
        /// Find first occurrence of byte in array with backward seek logic.
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="seekByte"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static int FindByteBackward(byte[] bytes, byte seekByte, int offset = 0)
        {
            if (offset > bytes.Length)
                return -1;

            for (int i = offset; i >= 0; --i)
                if (bytes[i] == seekByte)
                    return i;

            return -1;
        }

        /// <summary>
        /// Read bytes and converts it to int.
        /// </summary>
        /// <param name="allBytes"></param>
        /// <param name="startOffset"></param>
        /// <param name="reverseBytes"></param>
        public static int GetDword(byte[] allBytes, int startOffset, bool reverseBytes = true)
        {
            byte[] tableIndexBytes = new byte[4];
            for (int i = 0; i < 4; ++i)
                tableIndexBytes[i] = allBytes[startOffset + i];

            if (!reverseBytes)
                Array.Reverse(tableIndexBytes);

            return BitConverter.ToInt32(tableIndexBytes, 0);
        }
/*
        /// <summary>
        /// Replaces bytes with int.
        /// </summary>
        /// <param name="allBytes"></param>
        /// <param name="startOffset"></param>
        /// <param name="dword"></param>
        /// <param name="reverse"></param>
        /// <returns></returns>
        //Unused for now so let it be commented out.
        public static byte[] SetDword(byte[] allBytes, int startOffset, int dword, bool reverse = true)
        {
            byte[] wordBytes = BitConverter.GetBytes(dword);
            if (!reverse)
                Array.Reverse(wordBytes);

            for (int i = 0; i < 4; ++i)
                allBytes[i] = wordBytes[i];
            return allBytes;
        }*/

        /// <summary>
        /// Reads bytes and converts them to string.
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="offset"></param>
        /// <param name="endoffset"></param>
        /// <returns>String corresponding passed arguments.</returns>
        public static string GetString(byte[] bytes, int offset, int endoffset)
        {
            byte[] byteselection = new byte[endoffset - offset];
            for (int i = offset; i < endoffset; ++i)
                byteselection[i - offset] = bytes[i];

            return System.Text.Encoding.ASCII.GetString(byteselection);
        }

        /// <summary>
        /// Deletes block of bytes from passed array.
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="startOffset"></param>
        /// <param name="endOffset"></param>
        /// <returns>New array without block [startOffset; endOffset].</returns>
        public static byte[] RemoveBytes(byte[] bytes, int startOffset, int endOffset)
        {
            byte[] result = new byte[bytes.Length - endOffset + startOffset];
            Array.ConstrainedCopy(bytes, 0, result, 0, startOffset);
            Array.ConstrainedCopy(bytes, endOffset, result, startOffset, bytes.Length - endOffset);
            return result;
        }

        /// <summary>
        /// Adds bytes from one array to another.
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="add"></param>
        /// <param name="startOffset"></param>
        /// <returns>New array.</returns>
        public static byte[] AddBytes(byte[] bytes, byte[] add, int startOffset)
        {
            int newLength = bytes.Length + add.Length;
            byte[] result = new byte[newLength];
            Array.ConstrainedCopy(bytes, 0, result, 0, startOffset);
            Array.ConstrainedCopy(add, 0, result, startOffset, add.Length);
            Array.ConstrainedCopy(bytes, startOffset, result, startOffset + add.Length, bytes.Length - startOffset);
            return result;
        }

        /// <summary>
        /// Replace bytes in array.
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="offset"></param>
        /// <param name="replacement"></param>
        /// <param name="finishWithNullByte"></param>
        /// <returns>Array with replaced bytes.</returns>
        public static byte[] ReplaceBytes(byte[] bytes, int offset, byte[] replacement, bool finishWithNullByte = true)
        {
            Array.ConstrainedCopy(replacement, 0, bytes, offset, replacement.Length);
            if (finishWithNullByte)
                bytes[offset + replacement.Length] = 0;
            return bytes;
        }

        /// <summary>
        /// Extract bytes from array.
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="startOffset"></param>
        /// <param name="endOffset"></param>
        /// <returns>Array of extracted bytes.</returns>
        public static byte[] GetBytes(byte[] bytes, int startOffset, int endOffset = -1)
        {
            endOffset = endOffset == -1 ? bytes.Length : endOffset;
            byte[] result = new byte[endOffset - startOffset];
            Array.ConstrainedCopy(bytes, startOffset, result, 0, endOffset - startOffset);
            return result;
        }

        /// <summary>
        /// Replaces all bytes in range with specified byte.
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="startOffset"></param>
        /// <param name="length"></param>
        /// <param name="setByte"></param>
        /// <returns>New array.</returns>
        public static byte[] SetBytes(byte[] bytes, int startOffset, int length, byte setByte)
        {
            for (int i = startOffset; i < startOffset + length; ++i)
                bytes[i] = setByte;
            return bytes;
        }
    }
}