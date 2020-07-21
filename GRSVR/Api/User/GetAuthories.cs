using System;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using Newtonsoft.Json;

namespace GRSVR
{
    public class GetAuthories : CommandBase<GRSession, StringRequestInfo>
    {
        public override string Name
        {
            get { return "GetAuthories"; }
        }

        public override void ExecuteCommand(GRSession session, StringRequestInfo requestInfo)
        {
            Tuple<string, string> resetPwdInputs = JsonConvert.DeserializeObject<Tuple<string, string>>(string.Join("", requestInfo.Parameters));
            Tuple<bool, string> dbRes = GRDbTabUser.GetAuthories(resetPwdInputs.Item1, resetPwdInputs.Item2);

            if (dbRes.Item1)
            {
                session.Send(ApiId.GetAuthories, ApiRes.OK, null, null);
            }
            else
            {
                session.Send(ApiId.GetAuthories, ApiRes.FAILED, null, dbRes.Item2);
            }
        }
    }
}
