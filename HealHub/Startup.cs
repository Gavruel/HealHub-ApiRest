using HealHub.Domain.Interfaces;
using HealHub.Infra;
using HealHub.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

namespace HealHub
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<OracleDbContext>(options =>
            options.UseOracle("Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=oracle.fiap.com.br)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=ORCL)));User Id=rm95725;Password=040418;"));

            services.AddScoped<IUserService, UserService>();
            services.AddHttpContextAccessor();
        }
    }
}
