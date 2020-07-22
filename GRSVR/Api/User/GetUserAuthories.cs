using System;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace GRSVR
{
    public class GetUserAuthorities : CommandBase<GRSession, StringRequestInfo>
    {
        public override string Name
        {
            get { return "GetUserAuthorities"; }
        }

        public override void ExecuteCommand(GRSession session, StringRequestInfo requestInfo)
        {
            Tuple<bool, List<Authority>, string> dbRes = GRDbTabAuthority.GetUser();

            if (dbRes.Item1)
            {
                session.Send(ApiId.GetUserAuthorities, ApiRes.OK, JsonConvert.SerializeObject(dbRes.Item2), null);
            }
            else
            {
                session.Send(ApiId.GetUserAuthorities, ApiRes.FAILED, null, dbRes.Item3);
            }
        }
    }
}
