using Application.Services;
using Domain.Common;
using Domain.Entities;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class CPSContext : IdentityDbContext <ApplicationUser>  
                                            // nuget MS entity framework core
                                            // MS EFC sql server
                                            //MS EFC Tools
                                            //MS EFC design here and instal it  to web api too
    {
        private readonly UserResolverService _userService ; // need it to return user name
        public CPSContext(  DbContextOptions<CPSContext> options, UserResolverService userService) : base(options)  // tu dodane dla identity ! 
        {
            _userService = userService;
        }

        public DbSet<Order> Orders { get; set; } // co mapujemy na tabele i bazy danych 
        public DbSet<Product> Products { get; set; } // co mapujemy na tabele i bazy danych 
       // public DbSet<Client> Clients { get; set; } // co mapujemy na tabele i bazy danych !!!!! tu uwasga 

        // potem nalezy zadeklarowac connection string w web api w appsetings json

        //przesłoniecie metody save changes :

        public  async Task< int> SaveChangesAsync()  // was public override int SaveChanges() 
        {
            // wyszukujemy wszystkie encje ktore sa typu auditable entity, zostaly dodane lub zaktualizowane

            var entries = ChangeTracker  // wszystkie wejscia wg wymogów
                .Entries()
                .Where(e => e.Entity is AuditibleEntity && (e.State == EntityState.Added || e.State == EntityState.Modified));


            foreach (var entityEntry in entries)
            {
                ((AuditibleEntity)entityEntry.Entity).LastModified = DateTime.UtcNow;
                ((AuditibleEntity)entityEntry.Entity).LastModifiedBy = _userService.GetUser(); 

                if (entityEntry.State == EntityState.Added)
                {
                    ((AuditibleEntity)entityEntry.Entity).Created = DateTime.UtcNow;
                    ((AuditibleEntity)entityEntry.Entity).CreatedBy = _userService.GetUser();

                }

            }

            return await base.SaveChangesAsync();
        }
    }
}
