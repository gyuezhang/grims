using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Config;
using SuperSocket.SocketBase.Protocol;
using System.Text;

namespace GRSVR
{
    public class GRServer : AppServer<GRSession>
    {
        public GRServer()
            : base(new TerminatorReceiveFilterFactory("\r\n", Encoding.UTF8))
        {
            GRDb.ConnDbSvr("localhost", 3306, "root", "123456");
        }

        protected override bool Setup(IRootConfig rootConfig, IServerConfig config)
        {
            return base.Setup(rootConfig, config);
        }

    }

    public class GRSession : AppSession<GRSession>
    {
        public const string RESTMNT = "<RESTMNT>";
        public int userId = -1;
        public void Send(ApiId apiId, ApiRes res, string json, string exLog)
        {
            //Send
            string strMsg;

            if (json == null || json.Length == 0)
                strMsg = apiId.ToString() + " " + res.ToString();
            else
                strMsg = apiId.ToString() + " " + res.ToString() + " " + json;
            strMsg += RESTMNT;
            base.Send(strMsg);
                    }
        protected override void HandleUnknownRequest(StringRequestInfo requestInfo)
        {
            base.HandleUnknownRequest(requestInfo);
        }

        protected override void OnSessionStarted()
        {
            this.Send(ApiId.Conn, ApiRes.OK, null, null);
        }
    }
}
