using System;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using Newtonsoft.Json;

namespace GRSVR
{
    public class AddUser : CommandBase<GRSession, StringRequestInfo>
    {
        public override string Name
        {
            get { return "AddUser"; }
        }

        public override void ExecuteCommand(GRSession session, StringRequestInfo requestInfo)
        {
            User user = JsonConvert.DeserializeObject<User>(string.Join("", requestInfo.Parameters));
            Tuple<bool, string> dbRes = GRDbTabUser.Add(user);

            if (dbRes.Item1)
            {
                session.Send(ApiId.AddUser, ApiRes.OK, null, null);
            }
            else
            {
                session.Send(ApiId.AddUser, ApiRes.FAILED, null, dbRes.Item2);
            }
        }
    }
}
