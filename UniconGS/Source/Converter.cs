using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Text.RegularExpressions;

namespace UniconGS.Source
{
    public static class Converter
    {
        public static bool IsNaturalNumber(String strNumber)
        {
            Regex objNotNaturalPattern = new Regex("[^0-9]");
            Regex objNaturalPattern = new Regex("0*[1-9][0-9]*");
            return !objNotNaturalPattern.IsMatch(strNumber) &&
            objNaturalPattern.IsMatch(strNumber);
        }

        public static BitArray GetBitsFromWord(ushort word)
        {
            var tmp = BitConverter.GetBytes(word);
            var x = tmp[0];
            tmp[0] = tmp[1];
            tmp[1] = x;
            return new BitArray(BitConverter.GetBytes(word));
        }
        /// <summary>
        /// Получает массив битов из массива слов
        /// </summary>
        /// <param name="words">Массив слов</param>
        /// <returns></returns>
        public static BitArray GetBitsFromWords(ushort[] words)
        {
            List<byte> bytes = new List<byte>();
            foreach (var word in words)
            {
                bytes.AddRange(BitConverter.GetBytes(word));
            }
            return new BitArray(bytes.ToArray());
        }
        public static ushort GetWordFromBits(BitArray bArray)
        {
            /*Тут магет быть ошибка*/
            byte[] bytes = new byte[bArray.Length];
            bArray.CopyTo(bytes, 0);
            return BitConverter.ToUInt16(bytes, 0);
        }

        public static ushort[] GetWordsFromBits(BitArray[] bits)
        {
            ushort[] tmp = new ushort[bits.Length];
            for (int i = 0; i < bits.Length; i++)
            {
                byte[] bytes = new byte[bits[i].Length];
                bits[i].CopyTo(bytes, 0);
                tmp[i] = BitConverter.ToUInt16(bytes, 0);
            }
            return tmp;
        }

        public static string GetStringFromWords(ushort[] value)
        {
            string tmp = string.Empty;
            int a = 0;
            foreach (var item in value)
            {
                foreach (var @byte in BitConverter.GetBytes(item))
                {
                    if (@byte == 0)
                    {
                        break;
                    }
                    else
                    {
                        tmp += Convert.ToChar(@byte);
                    }
                }
                a++;
            }
            return tmp;
        }

        public static string GetStringWithNullsFromWords(ushort[] value)
        {
            Encoding ascii = Encoding.GetEncoding(1251);
            string tmp = string.Empty;
            foreach (var item in value)
            {
                foreach (var @byte in BitConverter.GetBytes(item))
                {
                    tmp += ascii.GetChars(new byte[1] { @byte }).First();
                }
            }
            return tmp;
        }

        public static List<ushort> GetWordsFromString(string value, byte maxLength)
        {
            List<ushort> tmp = new List<ushort>();
            var chars = value.ToCharArray();
            for (int i = 0; i < value.Length / 2; i++)
            {
                tmp.Add(BitConverter.ToUInt16(new byte[2] { (byte)chars[2 * i], (byte)chars[2 * i + 1] }, 0));
            }
            if (value.Length % 2 != 0)
            {
                tmp.Add(BitConverter.ToUInt16(new byte[2] { (byte)chars[chars.Length - 1], (byte)0 }, 0));
            }
            if (tmp.Count < maxLength)
            {
                int count = maxLength - tmp.Count;
                for (int i = 0; i < count; i++)
                {
                    tmp.Add(0);
                }
            }
            return tmp;
        }

        public static ushort[] GetWordsFromBits(List<bool> value)
        {
            List<ushort> tmp = new List<ushort>();
            if (value.Count % 16 == 0)
            {
                for (int i = 0; i < value.Count / 16; i++)
                {
                    tmp.Add(GetWordFromBits(new BitArray(value.GetRange(i * 16, 16).ToArray())));
                }
                return tmp.ToArray();
            }
            else
                return null;
        }
    }
}
