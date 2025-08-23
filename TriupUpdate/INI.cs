using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

/// <summary>
/// 업데이트 관련 내용 INI 파일에 저장하기 위한 클래스
/// </summary>
namespace Kiosk.TriupUpdate
{
    public static class INI
    {
        #region Define
        public static string m_path;
        #endregion

        #region Extern
        [DllImport("kernel32")]
        static extern int GetPrivateProfileInt(int section, string key, string value, [MarshalAs(UnmanagedType.LPArray)] byte[] result, int size, string fileName);

        [DllImport("kernel32")]
        static extern int GetPrivateProfileString(string section, int key, string value, [MarshalAs(UnmanagedType.LPArray)] byte[] result, int size, string fileName);

        // C의 dll함수 마샬링	
        // 함수의 파라미터는 section명, 키명, 값, 파일 위치    
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

        // C의 dll함수 마샬링	
        // 함수의 파라미터는 section명, 키명, 디폴트 값(값이 없을 때, 나오는 값), String pointer, 크기, 파일 위치    
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
        #endregion

        #region Method
        // ini파일에 값을 작성하는 함수
        public static void WriteConfig(string file, string section, string key, string val)
        {
            if (string.IsNullOrEmpty(section) || string.IsNullOrEmpty(key)) return;

            // 값이 null 또는 빈 문자열인 경우
            if (string.IsNullOrEmpty(val))
            {
                // 해당 section에서 key를 삭제합니다.
                WritePrivateProfileString(section, key, null, GetFile(file));

                // 해당 section의 모든 key를 가져옵니다.
                GetSectionKeys(file, section, out string[] keys);

                // key가 없는 경우, section을 삭제합니다.
                if (keys.Length == 0)
                {
                    WritePrivateProfileString(section, null, null, GetFile(file));
                }
            }
            else
            {
                // 정상적으로 key와 value를 저장합니다.
                WritePrivateProfileString(section, key, val, GetFile(file));
            }
        }

        // ini파일에서 값을 가져오는 함수
        public static string ReadConfig(string file, string section, string key)
        {
            StringBuilder temp = new StringBuilder(400);
            int ret = GetPrivateProfileString(section, key, null, temp, 400, GetFile(file));
            return temp.ToString();
        }

        public static Dictionary<string, string> ReadConfig(string file, string section)
        {
            Dictionary<string, string> datas = new Dictionary<string, string>();
            string[] keys;
            string value;

            //// 모든 Section 가져오기
            //string[] sections;
            //INI.GetSectionNames(file, out sections);

            // 가져온 Section으로 Key 가져오기
            INI.GetSectionKeys(file, section, out keys);

            // 가져온 Section과 Key로 Read하기.
            for (int i = 0; i < keys.Length; i++)
            {
                value = ReadConfig(file, section, keys[i]);
                if (datas.Keys.Contains(keys[i]) == false)
                    datas.Add(keys[i], value);
            }

            // 조합해서 Dictionary에 넣어서 return.
            return datas;
        }

        private static void GetSectionNames(string file, out string[] sections)
        {
            sections = new string[] { };

            for (int maxsize = 500; true; maxsize *= 2)
            {
                byte[] bytes = new byte[maxsize];
                int size = GetPrivateProfileInt(0, "", "", bytes, maxsize, GetFile(file));

                if (size < maxsize - 2)
                {
                    string selected = Encoding.ASCII.GetString(bytes, 0, size - (size > 0 ? 1 : 0));
                    sections = selected.Split(new char[] { '\0' });
                    return;
                }
            }
        }

        private static void GetSectionKeys(string file, string section, out string[] keys)
        {
            keys = new string[] { };

            for (int maxsize = 500; true; maxsize *= 2)
            {
                byte[] bytes = new byte[maxsize];
                int size = GetPrivateProfileString(section, 0, "", bytes, maxsize, GetFile(file));

                if (size < maxsize - 2 && 0 < size)
                {
                    string selected = Encoding.ASCII.GetString(bytes, 0, size - (size > 0 ? 1 : 0));
                    keys = selected.Split(new char[] { '\0' });
                    return;
                }
                else if (size == 0)
                {
                    return;
                }
            }
        }

        private static string GetFile(string file)
        {
            string folderPath = AppDomain.CurrentDomain.BaseDirectory + "INI";
            DirectoryInfo directory = new DirectoryInfo(folderPath);
            if (directory.Exists == false)
            {
                directory.Create();
            }

            return m_path = folderPath + "\\" + file + ".ini";
        }

        //해당 내용 존재하는지 확인하고 없으면 쓰기
        public static void WriteConfigIfNotExists(string file, string section, string key, string val)
        {
            string existingValue = ReadConfig(file, section, key);
            if (string.IsNullOrEmpty(existingValue))
            {
                WriteConfig(file, section, key, val);
            }
        }
        #endregion
    }
}
