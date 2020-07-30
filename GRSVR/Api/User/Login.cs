using System;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using Newtonsoft.Json;
using System.Linq;

namespace GRSVR
{
    public class Login : CommandBase<GRSession, StringRequestInfo>
    {
        public override string Name
        {
            get { return "Login"; }
        }

        public override void ExecuteCommand(GRSession session, StringRequestInfo requestInfo)
        {
            Tuple<string, string> resetPwdInputs = JsonConvert.DeserializeObject<Tuple<string, string>>(string.Join("", requestInfo.Parameters));
            Tuple<bool, string> dbRes = GRDbTabUser.Login(resetPwdInputs.Item1, resetPwdInputs.Item2);
            session.userId = GRDbTabUser.Get().Item2.Where(x => x.name == resetPwdInputs.Item1).ToList()[0].id;
            if (dbRes.Item1)
            {
                session.Send(ApiId.Login, ApiRes.OK, JsonConvert.SerializeObject(GRDbTabUser.Get().Item2.Where(x => x.name == resetPwdInputs.Item1).ToList()[0]), null);
            }
            else
            {
                session.Send(ApiId.Login, ApiRes.FAILED, null, dbRes.Item2);
            }
        }
    }
}
