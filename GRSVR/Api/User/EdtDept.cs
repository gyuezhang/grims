using System;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using Newtonsoft.Json;

namespace GRSVR
{
    public class EdtDept : CommandBase<GRSession, StringRequestInfo>
    {
        public override string Name
        {
            get { return "EdtDept"; }
        }

        public override void ExecuteCommand(GRSession session, StringRequestInfo requestInfo)
        {
            Dept dept = JsonConvert.DeserializeObject<Dept>(string.Join("", requestInfo.Parameters));
            Tuple<bool, string> dbRes = GRDbTabDept.Edt(dept);

            if (dbRes.Item1)
            {
                session.Send(ApiId.EdtDept, ApiRes.OK, null, null);
            }
            else
            {
                session.Send(ApiId.EdtDept, ApiRes.FAILED, null, dbRes.Item2);
            }
        }
    }
}
