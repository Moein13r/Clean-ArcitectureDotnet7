using Dot7.Architecture.Api.Controllers;
using Dot7.Architecture.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dot7.Architecture.Infrastructure
{
    public static class Migrations
    {
        public static WebApplication MigrateDatabase(this WebApplication webApp)
        {
            using (var scope = webApp.Services.CreateScope())
            {
                using (var appContext = scope.ServiceProvider.GetRequiredService<CustomerDbContext>())
                {
                    try
                    {
                        appContext.Database.Migrate();
                        var t = (RelationalDatabaseCreator)appContext.Database.GetService<IDatabaseCreator>();
                        if (!t.HasTables())
                            t.CreateTables();
                    }
                    catch (Exception ex)
                    {
                        //Log errors or do anything you think it's needed
                        throw;
                    }
                }
            }
            return webApp;
        }
    }
}
