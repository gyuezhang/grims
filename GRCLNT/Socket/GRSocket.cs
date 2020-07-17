using SuperSocket.ClientEngine;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GRCLNT
{
    public class GRSocket
    {
        private static EasyClient ezClient;

        private static string Ip;

        private static string Port { get; set; } = "6868";

        public static void Conn(string ip)
        {
            Ip = ip;
            ezClient = new EasyClient();
            ezClient.Initialize(new GRSocketFilter(), (request) =>
            {
                switch (request.apiId)
                {
                    case ApiId.Conn:
                        GRSocketHandler.OnConnState(request);
                        break;
                    case ApiId.AdminLogin:
                        GRSocketHandler.OnAdminLogin(request);
                        break;
                    case ApiId.AdminResetPwd:
                        GRSocketHandler.OnAdminResetPwd(request);
                        break;
                    default:
                        break;
                }
            });
            _ = SyncConn();
        }

        public static bool IsConnected => ezClient.IsConnected;

        private static async Task SyncConn()
        {
            await ezClient.ConnectAsync(new IPEndPoint(IPAddress.Parse(Ip), int.Parse(Port)));
        }

        public static void Send(ApiId id, string para)
        {
            if (IsConnected)
                ezClient.Send(Encoding.UTF8.GetBytes(id.ToString() + " " + para + "\r\n"));
            else
            {
                GRSocketStringPackageInfo request = new GRSocketStringPackageInfo(0, ApiRes.FAILED, null);
                GRSocketHandler.OnConnState(request);
            }
        }
    }
}