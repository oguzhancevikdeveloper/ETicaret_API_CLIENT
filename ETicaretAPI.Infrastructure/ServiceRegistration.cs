using ETicaretAPI.Application.Abstractions.Storage;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Infrastructure.Enums;
using ETicaretAPI.Infrastructure.Services;
using ETicaretAPI.Infrastructure.Services.Storage;
using ETicaretAPI.Infrastructure.Services.Storage.Local;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection servicesCollection)
        {
            servicesCollection.AddScoped<IStorageService, StorageService>();

        }

        //public static void AddStorage<T>(this IServiceCollection servicesCollection) where T : class, IStorage 
        //{
        //    servicesCollection.AddScoped<IStorage,T>();
        //}

        public static void AddStorage(this IServiceCollection servicesCollection, StorageType storageType)
        {
            switch (storageType)
            {
                case StorageType.Local:
                    servicesCollection.AddScoped<IStorage, LocalStorage>();
                    break;
                case StorageType.Azure:

                    break;
                case StorageType.AWS:

                    break;
                default:
                    break;

            }
        }
    }
}
