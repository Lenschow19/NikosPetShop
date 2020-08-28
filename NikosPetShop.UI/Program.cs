using System;
using Microsoft.Extensions.DependencyInjection;
using NikosPetShop.Core.ApplicationServices;
using NikosPetShop.Core.ApplicationServices.Impl;
using NikosPetShop.Core.DomainServices;
using NikosPetShop.Core.Entity;
using NikosPetShop.InfraStructure.Static.Data.Repositories;

namespace NikosPetShop.UI
{
    class Program
    {
        #region Main

        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IPetRepository, PetRepository>();
            serviceCollection.AddScoped<IPetService, PetService>();
            serviceCollection.AddScoped<IPrinter, Printer>();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var printer = serviceProvider.GetRequiredService<IPrinter>();
            printer.StartUI();
        }
        #endregion
    }
}
