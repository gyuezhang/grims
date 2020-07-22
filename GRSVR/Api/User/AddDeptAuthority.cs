using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using Newtonsoft.Json;
using System;

namespace GRSVR
{
    public class AddDeptAuthority : CommandBase<GRSession, StringRequestInfo>
    {
        public override string Name
        {
            get { return "AddDeptAuthority"; }
        }

        public override void ExecuteCommand(GRSession session, StringRequestInfo requestInfo)
        {
            Authority auth = JsonConvert.DeserializeObject<Authority>(string.Join("", requestInfo.Parameters));
            Tuple<bool, string> dbRes = GRDbTabAuthority.AddDept(auth);

            if (dbRes.Item1)
            {
                session.Send(ApiId.AddDeptAuthority, ApiRes.OK, null, null);
            }
            else
            {
                session.Send(ApiId.AddDeptAuthority, ApiRes.FAILED, null, dbRes.Item2);
            }
        }
    }
}
