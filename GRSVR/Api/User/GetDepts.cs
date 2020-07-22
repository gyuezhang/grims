﻿using System;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace GRSVR
{
    public class GetDepts : CommandBase<GRSession, StringRequestInfo>
    {
        public override string Name
        {
            get { return "GetDepts"; }
        }

        public override void ExecuteCommand(GRSession session, StringRequestInfo requestInfo)
        {
            Tuple<bool, List<Dept>, string> dbRes = GRDbTabDept.Get();

            if (dbRes.Item1)
            {
                session.Send(ApiId.GetDepts, ApiRes.OK, JsonConvert.SerializeObject(dbRes.Item2), null);
            }
            else
            {
                session.Send(ApiId.GetDepts, ApiRes.FAILED, null, dbRes.Item3);
            }
        }
    }
}
