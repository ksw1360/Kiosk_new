using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace Kiosk.TriupUpdate
{
    public partial class FrmUpdateHistory : Form
    {
        #region Field
        string Program_kidns = "";
        string FTP_Server = "";
        string EXE_Version = "";
        public static string SQL_CONN_COMMON;

        //FTP 서버
        string user = "triup-auth";
        string pwd = "mX1bvgimfpcp";

        FrmWaitingBar waitingForm;

        bool updateStart = false;

        internal static List<M.version_List> update_list = new List<M.version_List>();
        internal static List<M.EXE_Version_List> exe_version_list = new List<M.EXE_Version_List>();

        internal static List<string> downLoad_list = new List<string>();

        List<UpdateHistoryInfo> updateHistoryInfo = new List<UpdateHistoryInfo>();

        #endregion

        #region Constructor
        public FrmUpdateHistory()
        {
            InitializeComponent();

            INI_File.WriteIniFile("UpdateRestartCheck", "Check", "False", Application.StartupPath + @"\UpdateCheck.INI");

            this.SetIP();

            if (string.IsNullOrEmpty(DBContactor.SQL_CONN_COMMON) != true)
                SQL_CONN_COMMON = DBContactor.SQL_CONN_COMMON;

            //ini파일에 업데이트 내용 없으면 일단 기록
            INI.WriteConfigIfNotExists("config", "Program_Setting", "FTP_Server", "ftp://61.97.189.180:21/TEST/");
            INI.WriteConfigIfNotExists("config", "Program_Setting", "Program_kidns", "Kiosk");
            INI.WriteConfigIfNotExists("config", "Program_Version", "EXE_version", "1.0.0.0");

            FTP_Server = INI.ReadConfig("config", "Program_Setting", "FTP_Server");
            Program_kidns = INI.ReadConfig("config", "Program_Setting", "Program_kidns");
            EXE_Version = INI.ReadConfig("config", "Program_Version", "EXE_version");

            //#region update 존재 유무
            CheckForUpdates("EXE", true);
            //#endregion 
        }
        #endregion

        #region Method

        protected void SetIP()
        {
            cMasterList list = cMasterData.GetMasterDB();

            if (list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    // 메인 DB
                    if (list[i].ITEM == 0)
                    {
                        DBContactor.SetIP(DBContactor.DBName.ChartDB, list[i].IP);
                        DBContactor.SetID(DBContactor.DBName.ChartDB, list[i].ID);
                        DBContactor.SetPassword(DBContactor.DBName.ChartDB, list[i].PASSWORD);
                        DBContactor.SetName(DBContactor.DBName.ChartDB, list[i].NAME);
                        //ClsMotionDB.DB_Name = list[i].NAME;
                        DBContactor.SetPort(DBContactor.DBName.ChartDB, list[i].PORT);
                        DBContactor.SetDBInformation(DBContactor.DBName.ChartDB);
                    }
                    //// MESSAGE 
                    //else if (list[i].ITEM == 1)
                    //{
                    //    DBContactor.SetIP(DBContactor.DBName.MessageDB, list[i].IP);
                    //    DBContactor.SetID(DBContactor.DBName.MessageDB, list[i].ID);
                    //    DBContactor.SetPassword(DBContactor.DBName.MessageDB, list[i].PASSWORD);
                    //    DBContactor.SetName(DBContactor.DBName.MessageDB, list[i].NAME);
                    //    DBContactor.SetPort(DBContactor.DBName.MessageDB, list[i].PORT);
                    //    DBContactor.SetDBInformation(DBContactor.DBName.MessageDB);
                    //}
                    // QR
                    else if (list[i].ITEM == 2)
                    {
                        DBContactor.SetIP(DBContactor.DBName.QRDB, list[i].IP);
                        DBContactor.SetID(DBContactor.DBName.QRDB, list[i].ID);
                        DBContactor.SetPassword(DBContactor.DBName.QRDB, list[i].PASSWORD);
                        DBContactor.SetName(DBContactor.DBName.QRDB, list[i].NAME);
                        DBContactor.SetPort(DBContactor.DBName.QRDB, list[i].PORT);
                        DBContactor.SetDBInformation(DBContactor.DBName.QRDB);
                    }
                    //// FTP
                    //else if (list[i].ITEM == 3)
                    //{

                    //    MotionChart.Common.FTPFileClass.Ftp_ = list[i].IP;
                    //    MotionChart.Common.FTPFileClass.id_ = list[i].ID;
                    //    MotionChart.Common.FTPFileClass.pw_ = list[i].PASSWORD;
                    //}
                    // COMMON
                    //else 
                    else if (list[i].ITEM == 4)
                    {
                        DBContactor.SetIP(DBContactor.DBName.CommonDB, list[i].IP);
                        DBContactor.SetID(DBContactor.DBName.CommonDB, list[i].ID);
                        DBContactor.SetPassword(DBContactor.DBName.CommonDB, list[i].PASSWORD);
                        DBContactor.SetName(DBContactor.DBName.CommonDB, list[i].NAME);
                        //ClsMotionDB.DB_Name = list[i].NAME;
                        DBContactor.SetPort(DBContactor.DBName.CommonDB, list[i].PORT);
                        DBContactor.SetDBInformation(DBContactor.DBName.CommonDB);
                    }
                }
            }
        }

        /// <summary>
        /// 업데이트 버전 확인
        /// </summary>
        /// <param name="Kinds"> Fetch, EXE 종류</param>
        public void CheckForUpdates(string Kinds, bool LoadBool)
        {
            try
            {
                FtpWebRequest request = CreateFtpWebRequest(FTP_Server + Program_kidns + "/" + Kinds, user, pwd, true);
                request.Method = WebRequestMethods.Ftp.ListDirectory;
                FtpWebResponse resFtp = (FtpWebResponse)request.GetResponse();
                StreamReader reader;
                reader = new StreamReader(resFtp.GetResponseStream(), System.Text.Encoding.Default);
                string strData = reader.ReadToEnd();
                string[] filesInDirectory = strData.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                Input_list(filesInDirectory, Kinds, LoadBool);

                resFtp.Close();
            }
            catch (Exception ex)
            {
                LOG_FILE.LogWrite(ex.ToString());
            }
        }

        /// <summary>
        /// 버전확인해서 해당 버전보다 높은건만 출력
        /// </summary>
        /// <param name="Str_">목록</param>
        /// <param name="Kinds">Fetch, EXE 종류</param>
        /// <param name="LoadBool">Load인지 아닌지</param>
        public void Input_list(string[] Str_, string Kinds, bool LoadBool)
        {
            #region version 비교

            string[] versionList = EXE_Version.Split('.');
            string num_version_now = Regex.Replace(EXE_Version, @"\D", "");
            int version_now_ = int.Parse(num_version_now);
            update_list.Clear();
            exe_version_list.Clear();

            #region Max 버전

            //# MAX 버전 구하기  1.0.0.1
            int num0 = 1;
            int num1 = 0;
            int num2 = 0;
            int num3 = 1;

            //# 첫번째 자리 비교
            num0 = Str_.Select(r => int.Parse(r.Split('/')[1].Split('.')[0])).Max();
            var filterFtp0 = Str_.Where(r => r.Contains($"EXE/{num0}")).ToArray();

            //# 두번째 자리 비교
            num1 = filterFtp0.Select(r => int.Parse(r.Split('/')[1].Split('.')[1])).Max();
            var filterFtp1 = filterFtp0.Where(r => r.Contains($"EXE/{num0}.{num1}")).ToArray();

            //# 세번째 자리 비교
            num2 = filterFtp1.Select(r => int.Parse(r.Split('/')[1].Split('.')[2])).Max();
            var filterFtp2 = filterFtp1.Where(r => r.Contains($"EXE/{num0}.{num1}.{num2}")).ToArray();

            //# 네번째 자리 비교
            num3 = filterFtp2.Select(r => int.Parse(r.Split('/')[1].Split('.')[3])).Max();
            var filterFtp3 = filterFtp2.Where(r => r.Contains($"EXE/{num0}.{num1}.{num2}.{num3}")).ToArray();

            //# 최종 업데이트 버전
            string[] updateVersion = filterFtp3;

            #endregion

            string version = updateVersion[0].Split('/')[1];
            string[] num_v = version.Split('.');

            int Nversion_ = int.Parse(versionList[0]); // 현재버전
            int Sversion_ = int.Parse(num_v[0]); // 가져온버전
            if (Nversion_ < Sversion_)
            {
                update_list.Add(new M.version_List(updateVersion[0].Split('/')[1]));
            }

            int Nversion_2 = int.Parse(versionList[1]); // 현재버전
            int Sversion_2 = int.Parse(num_v[1]);       // 가져온버전 
            if (Nversion_ <= Sversion_ && Nversion_2 < Sversion_2)
            {
                update_list.Add(new M.version_List(updateVersion[0].Split('/')[1]));
            }

            int Nversion_3 = int.Parse(versionList[2]); // 현재버전
            int Sversion_3 = int.Parse(num_v[2]);       // 가져온버전 
            if (Nversion_ <= Sversion_ && Nversion_2 <= Sversion_2 && Nversion_3 < Sversion_3)
            {
                update_list.Add(new M.version_List(updateVersion[0].Split('/')[1]));
            }

            int Nversion_4 = int.Parse(versionList[3]); // 현재버전
            int Sversion_4 = int.Parse(num_v[3]);       // 가져온버전 
            if (Nversion_ <= Sversion_ && Nversion_2 <= Sversion_2 && Nversion_3 <= Sversion_3 && Nversion_4 < Sversion_4)
            {
                update_list.Add(new M.version_List(updateVersion[0].Split('/')[1]));
            }

            #endregion

            if (Kinds.Equals("EXE"))
            {
                if (update_list.Count != 0)
                {
                    string last_EXE = update_list[update_list.Count - 1].Version_;
                    update_list.Clear();
                    update_list.Add(new M.version_List(last_EXE));
                    exe_version_list.Add(new M.EXE_Version_List(last_EXE));
                }
            }
        }


        #region FTP File 다운 

        /// <summary>
        /// FTP 다운로프
        /// </summary>
        /// <param name="version">다운로드 버전</param>
        /// <param name="SaveFilePath">저장 경로</param>
        public void DownLoad(string version, string SaveFilePath, string EXE)
        {
            List<string> lstFolder = downLoad_list.Where(r => r.Substring(0, 3) == "[D]").ToList();
            List<string> lstFile = downLoad_list.Where(r => r.Substring(0, 3) == "[F]").ToList();

            //# 폴더 생성
            for (int i = 0; i < lstFolder.Count; i++)
            {
                DirectoryInfo directory = new DirectoryInfo($"{SaveFilePath}\\{lstFolder[i].Substring(3).Replace($"{Program_kidns}/EXE/{version}/", "")}");

                if (!directory.Exists)
                    directory.Create();
            }

            //# 파일 다운
            for (int i = 0; i < lstFile.Count; i++)
            {
                string url = $"{FTP_Server}/{lstFile[i].Substring(3)}";
                string filePath = lstFile[i].Substring(3).Replace($"{Program_kidns}/EXE/{version}/", "");

                DownloadFile(url, $"{SaveFilePath}\\{filePath}.$$");
            }
        }

        /// <summary>
        /// FTP 파일 다운로드
        /// </summary>
        /// <param name="ftpSourceFilePath">받는 프로그램</param>
        /// <param name="localDestinationFilePath">저장 프로그램 경로</param>
        private void DownloadFile(string ftpSourceFilePath, string localDestinationFilePath)
        {
            int bytesRead = 0;
            byte[] buffer = new byte[2048];

            FtpWebRequest request = CreateFtpWebRequest(ftpSourceFilePath, user, pwd, true);
            request.Method = WebRequestMethods.Ftp.DownloadFile;
            Stream reader = request.GetResponse().GetResponseStream();
            FileStream fileStream = new FileStream(localDestinationFilePath, FileMode.Create);

            while (true)
            {
                bytesRead = reader.Read(buffer, 0, buffer.Length);

                if (bytesRead == 0)
                    break;

                fileStream.Write(buffer, 0, bytesRead);
            }
            fileStream.Close();
        }

        private FtpWebRequest CreateFtpWebRequest(string ftpDirectoryPath, string userName, string password, bool keepAlive = false)
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(new Uri(ftpDirectoryPath));
            //Set proxy to null. Under current configuration if this option is not set then the proxy that is used will get an html response from the web content gateway (firewall monitoring system)
            request.KeepAlive = false;
            request.UseBinary = false;
            request.UsePassive = false;
            request.Credentials = new NetworkCredential(userName, password);

            return request;
        }

        /// <summary>
        /// 기존 프로그램과 업데이트된 프로그램 변경
        /// </summary>
        /// <param name="version">다운로드 받은 version</param>
        public void Change_Program_Name(string version)
        {
            List<string> lstFolder = downLoad_list.Where(r => r.Substring(0, 3) == "[D]").ToList();
            List<string> lstFile = downLoad_list.Where(r => r.Substring(0, 3) == "[F]").ToList();

            //# 폴더
            for (int i = 0; i < lstFolder.Count; i++)
            {
                string folder = lstFolder[i].Substring(3).Replace($"{Program_kidns}/EXE/{version}/", "");

                DirectoryInfo directory = new DirectoryInfo($"{Application.StartupPath}\\EXE\\{version}\\{folder}");

                if (!directory.Exists)
                    directory.Create();
            }

            //# 파일
            for (int i = 0; i < lstFile.Count; i++)
            {
                string file = lstFile[i].Substring(3).Replace($"{Program_kidns}/EXE/{version}/", "");

                //# 1.기존 프로그램 명
                string oldFile = $"{Application.StartupPath}\\{file}";

                //# 2.기존 프로그램 백업 명 ex) 파일.확장자[v.0.0.1] 
                if (!Directory.Exists($"{Application.StartupPath}\\EXE\\{version}"))
                {
                    Directory.CreateDirectory($"{Application.StartupPath}\\EXE\\{version}");
                }
                string newFile = $"{Application.StartupPath}\\EXE\\{version}\\{file}[{EXE_Version}]";

                //# 3.기존 프로그램 백업
                if (File.Exists(oldFile))
                {
                    if (File.Exists(newFile))
                        System.IO.File.Delete(newFile);

                    System.IO.File.Move(oldFile, newFile); //# 이름변경
                }

                Thread.Sleep(500);

                //# 3.FTP에서 다운받은 Update파일 ex) 파일.$$
                string DownFile = $"{Application.StartupPath}\\{file}.$$";

                //# 4.적용되야할 Update파일
                string DownnewFile = $"{Application.StartupPath}\\{file}";

                //# 5.Update파일 적용
                System.IO.File.Move(DownFile, DownnewFile); //# 이름변경
            }

            Change_Version(version);
            INI_File.WriteIniFile("UpdateResta rtCheck", "Check", "True", Application.StartupPath + @"\UpdateCheck.INI");

            Application.Restart();
        }
        #endregion

        #region version 변경

        /// <summary>
        /// 업데이트 후 버전 적용
        /// </summary>
        /// <param name="version"> 적용할 version </param>
        public void Change_Version(string version)
        {
            EXE_Version = version;
            INI.WriteConfig("config", "Program_Version", "EXE_version", version);
        }

        #endregion


        #region FTP Version File 목록 가져오기

        public void RetrieveAllFilesFromFTP(string version, string exe, string inputSourcePath = "") //모든 파일 검색해서 다운로드 목록 추가
        {
            string sourcePath = string.Empty;

            if (string.IsNullOrEmpty(inputSourcePath))
            {
                downLoad_list.Clear();
                sourcePath = Program_kidns + "/" + exe + "/" + version;
            }
            else
            {
                sourcePath = inputSourcePath;
            }

            List<string> fileList = new List<string>();
            List<string> folderList = new List<string>();

            FtpWebRequest request = (FtpWebRequest)WebRequest.Create($"{FTP_Server}{sourcePath}");
            request.Credentials = new NetworkCredential(user, pwd);
            request.KeepAlive = false;
            request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
            request.UsePassive = false;

            using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
            {
                using (var stream = response.GetResponseStream())
                {
                    using (var reader = new StreamReader(stream, System.Text.Encoding.UTF8))
                    {
                        while (!reader.EndOfStream)
                        {
                            string line = reader.ReadLine();
                            string fileName = GetFileNameFromResponseLine(line);

                            if (!string.IsNullOrEmpty(fileName))
                            {
                                string fullPath = sourcePath + "/" + fileName;

                                //# 폴더 여부 체크
                                if (IsDirectory(line))
                                {
                                    folderList.Add(fullPath);
                                    downLoad_list.Add("[D]" + fullPath);
                                }
                                else
                                {
                                    fileList.Add(fullPath);
                                    downLoad_list.Add("[F]" + fullPath);
                                }
                            }
                        }
                    }
                }
            }

            if (folderList.Count > 0)
            {
                for (int i = 0; i < folderList.Count; i++)
                {
                    RetrieveAllFilesFromFTP(version, exe, folderList[i]);
                }
            }
        }

        /// <summary>
        /// 폴더여부
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public bool IsDirectory(string line)
        {
            return line.StartsWith("d", StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// FTP에서 받아온 파일Detail 정보에서 파일명 위치
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public string GetFileNameFromResponseLine(string line)
        {
            int startIndex = line.LastIndexOf(' ') + 1;
            return line.Substring(startIndex);
        }


        #endregion

        /// <summary>
        /// 업데이트 내역 조회
        /// </summary>
        /// <returns></returns>
        private int UpdateHistorySearch(bool beforeUpdate = false)
        {
            int ret = 0;

            Uri uri = new Uri(this.FTP_Server);
            string ftpServer_ = uri.Segments[uri.Segments.Length - 1].TrimEnd('/');

            if ((ret = ClsMotionDB.GetUpdateHistory("T", ftpServer_, beforeUpdate ? "" : EXE_Version, out this.updateHistoryInfo)) != 0)
            {
                return -1;
            }

            if (this.updateHistoryInfo.Count > 0)
            {
                string newestVersion = this.updateHistoryInfo[0].UPDATE_VERSION;

                this.lblVersion.Text = $"Ver {newestVersion} 변경사항";
                this.txtContent.Text = "";

                for (int i = 0; i < this.updateHistoryInfo.Count; i++)
                {
                    string[] separator = new string[] { "||" };
                    string[] updateContent = this.updateHistoryInfo[i].UPDATE_CONTENT.Split(separator, StringSplitOptions.None);

                    if (i != 0)
                    {
                        this.txtContent.SelectionFont = new Font("Gadugi", 10, FontStyle.Bold);
                        this.txtContent.AppendText($"Ver {this.updateHistoryInfo[i].UPDATE_VERSION}\r\n");
                    }

                    for (int j = 0; j < updateContent.Count(); j++)
                    {
                        this.txtContent.SelectionColor = ColorTranslator.FromHtml("#787878");

                        this.txtContent.AppendText($"•    {updateContent[j].TrimEnd('\n').TrimEnd('\r').Replace("\r\n", "\r\n     ")}\r\n");
                    }

                    this.txtContent.AppendText($"\r\n\r\n");
                }
            }
            else
            {
                this.lblVersion.Text = $"Ver {EXE_Version} 변경사항";
                this.txtContent.Text = "내용없음.";
                // this.Close();
            }


            return ret;
        }

        #endregion

        #region Event

        private void FrmUpdateHistory_Shown(object sender, EventArgs e)
        {
            int ret = 0;

            if ((ret = this.UpdateHistorySearch()) != 0)
            {

            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            updateStart = true;
            this.Close();
        }

        private void chkBeforeUpdate_CheckStateChanged(object sender, EventArgs e)
        {
            int ret = 0;

            if ((ret = this.UpdateHistorySearch(this.chkBeforeUpdate.Checked)) != 0)
            {
            }
        }

        private void FrmUpdateHistory_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (updateStart)
            {
                try
                {
                    this.waitingForm = new FrmWaitingBar();
                    this.waitingForm.WaitingShow("업데이트 중입니다.\r\n잠시만 기다려주십시오.");

                    #region EXE Auto Update
                    if (exe_version_list.Count != 0)
                    {
                        string exe_Version = exe_version_list[0].Version_;

                        #region FTP Version File 목록 가져오기 

                        RetrieveAllFilesFromFTP(exe_Version, "EXE");

                        #endregion

                        #region DwonLoad FIle and Change Name
                        string Down_Load_Path = Application.StartupPath;
                        DownLoad(exe_Version, Down_Load_Path, "EXE");
                        Change_Program_Name(exe_Version);
                        #endregion
                        #region  EXE Auto INI File
                        EXE_Auto_INI_File(exe_Version);
                        #endregion
                    }
                    #endregion
                }
                catch (Exception ex)
                {
                    LOG_FILE.LogWrite(ex.ToString());
                }
                finally
                {
                    if (this.waitingForm != null)
                        this.waitingForm.WaitingClose();
                }
            }
        }

        private void FrmUpdateHistory_Load(object sender, EventArgs e)
        {
            //업데이트할거 없으면 안 열기
            if (update_list.Count == 0)
            {
                this.Close();
            }
        }
        #endregion

        #region EXE Auto INI File
        public void EXE_Auto_INI_File(string version)
        {
            INI.WriteConfig("config", "Program_Version", "EXE_version", version);
            EXE_Version = version;
        }
        #endregion
    }

    public class UpdateHistoryInfo
    {
        #region Field

        private string m_UPDATE_VERSION;
        private int m_SEQ;
        private string m_UPDATE_KIND;
        private string m_UPDATE_CONTENT;
        private string m_UPDATE_DT;

        #endregion

        #region Constructor
        public UpdateHistoryInfo()
        {
            this.UPDATE_VERSION = string.Empty;
            this.SEQ = 0;
            this.UPDATE_KIND = string.Empty;
            this.UPDATE_CONTENT = string.Empty;
            this.UPDATE_DT = string.Empty;
        }
        #endregion

        #region Property

        public string UPDATE_VERSION
        {
            get { return m_UPDATE_VERSION; }
            set { this.m_UPDATE_VERSION = value; }
        }
        public int SEQ
        {
            get { return m_SEQ; }
            set { this.m_SEQ = value; }
        }
        public string UPDATE_KIND
        {
            get { return m_UPDATE_KIND; }
            set { this.m_UPDATE_KIND = value; }
        }
        public string UPDATE_CONTENT
        {
            get { return m_UPDATE_CONTENT; }
            set { this.m_UPDATE_CONTENT = value; }
        }
        public string UPDATE_DT
        {
            get { return m_UPDATE_DT; }
            set { this.m_UPDATE_DT = value; }
        }
        #endregion
    }
}
