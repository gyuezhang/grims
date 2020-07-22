using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using Newtonsoft.Json;
using System;

namespace GRSVR
{
    public class AddDept : CommandBase<GRSession, StringRequestInfo>
    {
        public override string Name
        {
            get { return "AddDept"; }
        }

        public override void ExecuteCommand(GRSession session, StringRequestInfo requestInfo)
        {
            Dept dept = JsonConvert.DeserializeObject<Dept>(string.Join("", requestInfo.Parameters));
            Tuple<bool, string> dbRes = GRDbTabDept.Add(dept);

            if (dbRes.Item1)
            {
                session.Send(ApiId.AddDept, ApiRes.OK, null, null);
            }
            else
            {
                session.Send(ApiId.AddDept, ApiRes.FAILED, null, dbRes.Item2);
            }
        }
    }
}
