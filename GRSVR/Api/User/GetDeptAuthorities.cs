using System;
using System;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace GRSVR
{
    public class GetDeptAuthorities : CommandBase<GRSession, StringRequestInfo>
    {
        public override string Name
        {
            get { return "GetDeptAuthorities"; }
        }

        public override void ExecuteCommand(GRSession session, StringRequestInfo requestInfo)
        {
            Tuple<bool, List<Authority>, string> dbRes = GRDbTabAuthority.GetDept();

            if (dbRes.Item1)
            {
                session.Send(ApiId.GetDeptAuthorities, ApiRes.OK, JsonConvert.SerializeObject(dbRes.Item2), null);
            }
            else
            {
                session.Send(ApiId.GetDeptAuthorities, ApiRes.FAILED, null, dbRes.Item3);
            }
        }
    }
}
