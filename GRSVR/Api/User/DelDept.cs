using System;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using Newtonsoft.Json;

namespace GRSVR
{
    public class DelDept : CommandBase<GRSession, StringRequestInfo>
    {
        public override string Name
        {
            get { return "DelDept"; }
        }

        public override void ExecuteCommand(GRSession session, StringRequestInfo requestInfo)
        {
            int id = JsonConvert.DeserializeObject<int>(string.Join("", requestInfo.Parameters));
            Tuple<bool, string> dbRes = GRDbTabDept.Del(id);

            if (dbRes.Item1)
            {
                session.Send(ApiId.DelDept, ApiRes.OK, null, null);
            }
            else
            {
                session.Send(ApiId.DelDept, ApiRes.FAILED, null, dbRes.Item2);
            }
        }
    }
}
