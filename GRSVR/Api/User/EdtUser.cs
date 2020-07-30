using System;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using Newtonsoft.Json;
using System.Linq;

namespace GRSVR
{
    public class EdtUser : CommandBase<GRSession, StringRequestInfo>
    {
        public override string Name
        {
            get { return "EdtUser"; }
        }

        public override void ExecuteCommand(GRSession session, StringRequestInfo requestInfo)
        {
            User user = JsonConvert.DeserializeObject<User>(string.Join("", requestInfo.Parameters));
            Tuple<bool, string> dbRes = GRDbTabUser.Edt(user);


            if (dbRes.Item1)
            {
                session.Send(ApiId.Login, ApiRes.OK, JsonConvert.SerializeObject(GRDbTabUser.Get().Item2.Where(x => x.id == session.userId).ToList()[0]), null);
            }
            else
            {
                session.Send(ApiId.Login, ApiRes.FAILED, null, dbRes.Item2);
            }
        }
    }
}
