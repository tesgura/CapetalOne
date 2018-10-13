using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using JusticePack.CapetalOne.BusinessLogic.Core.Services;
using JusticePack.CapetalOne.BusinessLogic.Core.Services.Interfaces;
using JusticePack.CapetalOne.BusinessLogic.Interfaces;
using JusticePack.CapetalOne.BusinessLogic.Services;
using JusticePack.CapetalOne.BusinessLogic.Services.Interfaces;
using JusticePack.CapetalOne.CrossCutting.Identity;
using JusticePack.CapetalOne.DataAccess.Core.Interfaces;
using JusticePack.CapetalOne.DataAccess.DynamoDb.Services;
using System;

namespace JusticePack.CapetalOne.CrossCutting.IoC
{
    public class DependencyInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services,
                                            IHostingEnvironment env, 
                                            IConfiguration configuration)
        {
            // Business Logic
            services.AddScoped<IAppSettingQueryService, AppSettingQueryService>();
            services.AddScoped<IAppSettingService, AppSettingService>();

            services.AddScoped<IBusinessManagerService, BusinessManagerService>();

            // Data Access
            services.AddScoped<IAppSettingDataService, AppSettingDynamoDbDataService>();

            // CrossCutting
            services.AddScoped<IIdentityService, IdentityService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }
    }
}
