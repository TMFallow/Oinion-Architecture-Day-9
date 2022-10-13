using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using OA.Repository;
using OA.Service;
using System.Configuration;

namespace Onion_Architecture
{
    public class StartUp
    {

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddOptions();

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddTransient<IUserService, UserService>();

            services.AddTransient<IUserInfoService, UserInfoService>();

        }
    }
}
