using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using Newtonsoft.Json;
using System;

namespace GRSVR
{
    public class AddUserAuthority : CommandBase<GRSession, StringRequestInfo>
    {
        public override string Name
        {
            get { return "AddUserAuthority"; }
        }

        public override void ExecuteCommand(GRSession session, StringRequestInfo requestInfo)
        {
            Authority auth = JsonConvert.DeserializeObject<Authority>(string.Join("", requestInfo.Parameters));
            Tuple<bool, string> dbRes = GRDbTabAuthority.AddUser(auth);

            if (dbRes.Item1)
            {
                session.Send(ApiId.AddUserAuthority, ApiRes.OK, null, null);
            }
            else
            {
                session.Send(ApiId.AddUserAuthority, ApiRes.FAILED, null, dbRes.Item2);
            }
        }
    }
}
