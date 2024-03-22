using Business.Interfaces;
using Business.Mapping;
using Database;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public static class DependencyInjection
    {

        public static IServiceCollection RegisterBusiness(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRecipeBusiness), typeof(RecipeBusiness));
            services.AddAutoMapper(typeof(MappingProfiles));
            return services;
        }

    }
}
