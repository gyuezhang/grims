using Stylet;
using System.IO;
using System.Xml;

namespace GRCLNT
{
    public class MCfg : PropertyChangedBase
    {
        private string _name;
        private string _pwd;
        private bool _recordPwd;
        private bool _autoLogin;
        private bool _svrMtd;
        private string _svrIp;

        public string Name
        {
            get { return _name; }
            set
            {
                SetAndNotify(ref _name, value);
            }
        }

        public string Pwd
        {
            get { return _pwd; }
            set
            {
                SetAndNotify(ref _pwd, value);
            }
        }

        public bool RecordPwd
        {
            get { return _recordPwd; }
            set
            {
                SetAndNotify(ref _recordPwd, value);
                if (!value)
                {
                    AutoLogin = value;
                }
            }
        }

        public bool AutoLogin
        {
            get { return _autoLogin; }
            set
            {
                SetAndNotify(ref _autoLogin, value);
                if (value)
                {
                    RecordPwd = value;
                }
            }
        }

        public bool SvrMtd
        {
            get { return _svrMtd; }
            set
            {
                SetAndNotify(ref _svrMtd, value);
            }
        }

        public string SvrIp
        {
            get { return _svrIp; }
            set
            {
                SetAndNotify(ref _svrIp, value);
            }
        }

    }

    public class Cfg
    {
        public Cfg()
        {
            Check();
        }
        private static string _cfgPath = System.Environment.CurrentDirectory + "\\Cfg.xml";
        private static MCfg _cfg { get; set; } = new MCfg();
        private static void Check()
        {
            try
            {
                if (!File.Exists(_cfgPath))
                {
                    XmlWriterSettings mySettings = new XmlWriterSettings();
                    mySettings.Indent = true;//是否进行缩进
                    mySettings.IndentChars = ("    ");

                    XmlWriter myWriter = XmlWriter.Create(_cfgPath, mySettings);

                    myWriter.WriteStartElement("Login");
                    myWriter.WriteElementString("UserName", "");
                    myWriter.WriteElementString("UserPwd", "");
                    myWriter.WriteElementString("RecordPwd", "0");
                    myWriter.WriteElementString("AutoLogin", "0");
                    myWriter.WriteElementString("ServerMethod", "1");
                    myWriter.WriteElementString("ServerIp", "");
                    myWriter.WriteEndElement();
                    myWriter.Flush();
                    myWriter.Close();
                }
            }
            catch
            {

            }
        }
        public static MCfg Get()
        {
            try
            {
                Check();

                XmlReader myReader = XmlReader.Create(_cfgPath);
                while (myReader.Read())
                {
                    if (myReader.NodeType == XmlNodeType.Element)
                    {
                        switch (myReader.Name)
                        {
                            case "UserName":
                                {
                                    _cfg.Name = myReader.ReadString();
                                }
                                break;
                            case "UserPwd":
                                {
                                    _cfg.Pwd = myReader.ReadString();
                                }
                                break;
                            case "RecordPwd":
                                {
                                    _cfg.RecordPwd = (myReader.ReadString() != "0");
                                }
                                break;
                            case "AutoLogin":
                                {
                                    _cfg.AutoLogin = (myReader.ReadString() != "0");
                                }
                                break;
                            case "ServerMethod":
                                {
                                    _cfg.SvrMtd = (myReader.ReadString() != "0");
                                }
                                break;
                            case "ServerIp":
                                {
                                    _cfg.SvrIp = myReader.ReadString();
                                }
                                break;
                            default:
                                break;
                        }
                    }
                }
                myReader.Close();
            }
            catch
            {

            }
            return _cfg;
        }

        public static void Set(MCfg cfg)
        {
            try
            {
                Check();
                _cfg = cfg;
                XmlWriterSettings mySettings = new XmlWriterSettings();
                mySettings.Indent = true;//是否进行缩进
                mySettings.IndentChars = ("    ");

                XmlWriter myWriter = XmlWriter.Create(_cfgPath, mySettings);

                myWriter.WriteStartElement("Login");

                myWriter.WriteElementString("UserName", _cfg.Name);
                if (_cfg.RecordPwd)
                {
                    myWriter.WriteElementString("RecordPwd", "1");
                    if (_cfg.Pwd.Length != 32)
                        myWriter.WriteElementString("UserPwd", Enc.GetMd5Hash(_cfg.Pwd));
                    else
                        myWriter.WriteElementString("UserPwd", _cfg.Pwd);

                }
                else
                {
                    myWriter.WriteElementString("RecordPwd", "0");
                    myWriter.WriteElementString("UserPwd", "");
                }

                if (_cfg.AutoLogin)
                    myWriter.WriteElementString("AutoLogin", "1");
                else
                    myWriter.WriteElementString("AutoLogin", "0");


                if (_cfg.SvrMtd)
                    myWriter.WriteElementString("ServerMethod", "1");
                else
                    myWriter.WriteElementString("ServerMethod", "0");

                myWriter.WriteElementString("ServerIp", _cfg.SvrIp);
                myWriter.WriteEndElement();
                myWriter.Flush();
                myWriter.Close();
            }
            catch
            {

            }
        }
    }
}
