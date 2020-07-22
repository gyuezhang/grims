using System;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace GRSVR
{
    public class GetUsers : CommandBase<GRSession, StringRequestInfo>
    {
        public override string Name
        {
            get { return "GetUsers"; }
        }

        public override void ExecuteCommand(GRSession session, StringRequestInfo requestInfo)
        {
            Tuple<bool, List<User>, string> dbRes = GRDbTabUser.Get();

            if (dbRes.Item1)
            {
                session.Send(ApiId.GetUsers, ApiRes.OK, JsonConvert.SerializeObject(dbRes.Item2), null);
            }
            else
            {
                session.Send(ApiId.GetUsers, ApiRes.FAILED, null, dbRes.Item3);
            }
        }
    }
}
