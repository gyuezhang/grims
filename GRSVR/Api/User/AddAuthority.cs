using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using Newtonsoft.Json;
using System;

namespace GRSVR
{
    public class AddAuthority : CommandBase<GRSession, StringRequestInfo>
    {
        public override string Name
        {
            get { return "AddAuthority"; }
        }

        public override void ExecuteCommand(GRSession session, StringRequestInfo requestInfo)
        {
            Tuple<string, string> resetPwdInputs = JsonConvert.DeserializeObject<Tuple<string, string>>(string.Join("", requestInfo.Parameters));
            Tuple<bool, string> dbRes = GRDbTabUser.AddAuthority(resetPwdInputs.Item1, resetPwdInputs.Item2);

            if (dbRes.Item1)
            {
                session.Send(ApiId.AddAuthority, ApiRes.OK, null, null);
            }
            else
            {
                session.Send(ApiId.AddAuthority, ApiRes.FAILED, null, dbRes.Item2);
            }
        }
    }
}
