using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using Newtonsoft.Json;
using System;

namespace GRSVR
{
    public class AdminLogin : CommandBase<GRSession, StringRequestInfo>
    {
        public override string Name
        {
            get { return "AdminLogin"; }
        }

        public override void ExecuteCommand(GRSession session, StringRequestInfo requestInfo)
        {
            session.userId = 0;

            string pwd = JsonConvert.DeserializeObject<string>(string.Join("", requestInfo.Parameters));
            Tuple<bool, string> dbRes = GRDbTabUser.AdminLogin(pwd);

            if (dbRes.Item1)
            {
                session.Send(ApiId.AdminLogin, ApiRes.OK, null, null);
            }
            else
            {
                session.Send(ApiId.AdminLogin, ApiRes.FAILED, null, dbRes.Item2);
            }
        }
    }
}
