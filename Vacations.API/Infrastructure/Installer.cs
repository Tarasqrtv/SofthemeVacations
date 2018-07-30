using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.DependencyInjection;
using Vacations.BLL.Services;

namespace Vacations.API.Infrastructure
{
    internal static class Installer
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddTransient<IUsersService, UsersService>();
            services.AddTransient<IEmployeesService, EmployeesService>();
            services.AddTransient<IVacationsService, VacationsService>(); 
            services.AddTransient<IProfileService, ProfileService>();
            services.AddTransient<ITeamsService, TeamsService>();
        }
    }
}
