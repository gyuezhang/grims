using System;
using SuperSocket.ProtoBase;
using System.Linq;
using System.Text;

namespace GRCLNT
{
    /// <summary>
    /// 客户端接收过滤器
    /// </summary>
    public class GRSocketFilter : SuperSocket.ProtoBase.TerminatorReceiveFilter<GRSocketStringPackageInfo>
    {
        public GRSocketFilter()
            : base(Encoding.UTF8.GetBytes("<RESTMNT>"))
        {
            clntSp = new GRSocketStringParse();
        }

        public override GRSocketStringPackageInfo ResolvePackage(IBufferStream bufferStream)
        {
            return new GRSocketStringPackageInfo(bufferStream.ReadString((int)bufferStream.Length, Encoding.UTF8), clntSp);
        }

        private GRSocketStringParse clntSp;
    }

    /// <summary>
    /// 服务器响应字符串格式化类
    /// </summary>
    public class GRSocketStringPackageInfo : IPackageInfo<string>
    {
        public ApiId apiId { get; protected set; }
        public ApiRes resState { get; protected set; }
        public string Parameters { get; protected set; }
        public string Key { get; protected set; }

        protected GRSocketStringPackageInfo()
        {

        }

        public GRSocketStringPackageInfo(string source, IGRSocketStringParse sourceParser)
        {
            InitializeData(source, sourceParser);
        }

        public GRSocketStringPackageInfo(ApiId id, ApiRes state, string para)
        {
            apiId = id;
            resState = state;
            Parameters = para;
        }

        protected void InitializeData(string source, IGRSocketStringParse sourceParser)
        {
            ApiId _key;
            ApiRes _body;
            string _parameters;

            sourceParser.Parse(source, out _key, out _body, out _parameters);

            apiId = _key;
            resState = _body;
            Parameters = _parameters;
        }
    }

    /// <summary>
    /// 解析字符串接口
    /// </summary>
    public interface IGRSocketStringParse
    {
        void Parse(string source, out ApiId apiId, out ApiRes resState, out string parameters);
    }

    /// <summary>
    /// 解析字符串接口实现
    /// </summary>
    public class GRSocketStringParse : IGRSocketStringParse
    {
        public void Parse(string source, out ApiId apiId, out ApiRes resState, out string parameters)
        {
            source = source.Replace("\r\n", string.Empty);
            source = source.Replace("<RESTMNT>", string.Empty);
            source = source.Trim();
            string[] tmp = source.Split(' ');
            tmp = tmp.Where(s => !string.IsNullOrEmpty(s)).ToArray();
            apiId = (ApiId)Enum.Parse(typeof(ApiId), tmp[0]);
            resState = (ApiRes)Enum.Parse(typeof(ApiRes), tmp[1]);
            parameters = string.Join("", tmp.CloneRange(2, tmp.Length - 2));
        }
    }
}
