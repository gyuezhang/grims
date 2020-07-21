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
            Tuple<string, string> resetPwdInputs = JsonConvert.DeserializeObject<Tuple<string, string>>(string.Join("", requestInfo.Parameters));
            Tuple<bool, string> dbRes = GRDbTabUser.DelDept(resetPwdInputs.Item1, resetPwdInputs.Item2);

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
