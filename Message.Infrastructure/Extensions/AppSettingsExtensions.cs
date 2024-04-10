using Message.Infrastructure.AppSetting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Message.Infrastructure.Extensions
{

    public static class AppSettingsExtensions
    {
        public static IServiceCollection AddSettingdServices(this IServiceCollection svc, IConfiguration config)
        {

            svc.Configure<EmailSettings>(config.GetSection("EmailSetting"));
            
            return svc;
        }
    }
}
