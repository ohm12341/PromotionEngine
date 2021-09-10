﻿using Infrastructure.Shared.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PE.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Shared.Extensions
{
    public static class ServiceRegistration
    {
        public static void AddSharedInfrastructure(this IServiceCollection services, IConfiguration _config)
        {
       
            services.AddTransient<IDateTimeService, DateTimeService>();
           
        }
    }
}
