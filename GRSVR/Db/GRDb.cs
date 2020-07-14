using MySql.Data.MySqlClient;
using System;

namespace GRSVR
{
    public class GRDb
    {
        private static string _ip;
        private static int _port;
        private static string _name;
        private static string _pwd;
        private static MySqlConnection _conn;

        private static MySqlConnection Conn()
        {
            string connStr = "datasource=" + _ip + ";port=" + _port.ToString() + ";user=" + _name + ";pwd=" + _pwd + ";";
            _conn = new MySqlConnection(connStr);
            _conn.Open();
            return _conn;
        }

        private static void Init()
        {
            Exec("create database If Not Exists grims Character Set UTF8");
            GRDbTabFile.InitTab();
            GRDbTabDept.InitTab();
            GRDbTabUser.InitTab();
            GRDbTabAnm.InitTab();
            GRDbTabAreaCode.InitTab();
            GRDbTabAuthority.InitTab();
            GRDbTabEntWell.InitTab();
            GRDbTabLog.InitTab();
            GRDbTabWell.InitTab();
        }

        public static void ConnDbSvr(string ServerIp, int Port, string DbUserName, string DbUserPwd)
        {
            _ip = ServerIp;
            _port = Port;
            _name = DbUserName;
            _pwd = DbUserPwd;

            Init();
        }

        public static Tuple<bool, MySqlDataReader, string> Query(string cmdStr)
        {
            try
            {
                MySqlDataReader _reader;
                MySqlCommand _cmd;
                _cmd = new MySqlCommand(cmdStr, Conn());
                _reader = _cmd.ExecuteReader();
                return new Tuple<bool, MySqlDataReader, string>(true, _reader, null);
            }
            catch (Exception e)
            {
                return new Tuple<bool, MySqlDataReader, string>(false, null, e.ToString());
            }
        }

        public static Tuple<bool, string> Exec(string cmdStr)
        {
            try
            {
                MySqlCommand _cmd;
                _cmd = new MySqlCommand(cmdStr, Conn());
                _cmd.ExecuteNonQuery();
                return new Tuple<bool, string>(true, null);
            }
            catch (Exception e)
            {
                return new Tuple<bool, string>(false, e.ToString());
            }
        }
    }
}
