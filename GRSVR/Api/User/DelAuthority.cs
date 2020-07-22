using System;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using Newtonsoft.Json;

namespace GRSVR
{
    public class DelAuthority : CommandBase<GRSession, StringRequestInfo>
    {
        public override string Name
        {
            get { return "DelAuthority"; }
        }

        public override void ExecuteCommand(GRSession session, StringRequestInfo requestInfo)
        {
            int id = JsonConvert.DeserializeObject<int>(string.Join("", requestInfo.Parameters));
            Tuple<bool, string> dbRes = GRDbTabAuthority.Del(id);

            if (dbRes.Item1)
            {
                session.Send(ApiId.DelAuthority, ApiRes.OK, null, null);
            }
            else
            {
                session.Send(ApiId.DelAuthority, ApiRes.FAILED, null, dbRes.Item2);
            }
        }
    }
}
