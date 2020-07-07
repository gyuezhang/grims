using Stylet;
using StyletIoC;


namespace GRCLNT
{
    /// <summary>
    /// 用于Stylet设置启动VM
    /// </summary>
    public class Bootstrapper : Bootstrapper<WndLoginViewModel>
    {
        protected override void ConfigureIoC(IStyletIoCBuilder builder)
        {
            // Configure the IoC container in here
        }

        protected override void Configure()
        {
            // Perform any other configuration before the application starts
        }
    }
}
