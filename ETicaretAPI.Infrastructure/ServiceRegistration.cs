using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Application.Services;
using ETicaretAPI.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Infrastructure
{
    public static  class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection servicesCollection)
        {
            servicesCollection.AddScoped<IFileService, FileService>(); // İstenildiğinde geliyor 1 requeste bir tane

        }
    }
}
