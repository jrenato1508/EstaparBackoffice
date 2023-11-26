using EstaparGarage.Bussinees.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstaparGarage.Data.Context
{
    public class EstaparDbcontext : DbContext 
    {

        public EstaparDbcontext( DbContextOptions<EstaparDbcontext> options) : base(options) {}

        public DbSet<FormaPagamento> FormasPagamento { get; set; }
        public DbSet<Garagem> Garagens { get; set; }
        public DbSet<Passagem> Passagens { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EstaparDbcontext).Assembly);

            foreach(var relationship in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            foreach (var property in modelBuilder.Model.GetEntityTypes()
            .SelectMany(e => e.GetProperties()
            .Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("Varchar(50)");

            base.OnModelCreating(modelBuilder);
        }
    }




}
    

