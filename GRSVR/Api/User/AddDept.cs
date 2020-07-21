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
            Tuple<string, string> resetPwdInputs = JsonConvert.DeserializeObject<Tuple<string, string>>(string.Join("", requestInfo.Parameters));
            Tuple<bool, string> dbRes = GRDbTabUser.AddDept(resetPwdInputs.Item1, resetPwdInputs.Item2);

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
