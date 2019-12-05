using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using AppDAEMovil.Models;

namespace AppDAEMovil.Data
{

    public class FicDBContext : DbContext
    {
        private readonly string FicLoDataBasePath;
        
        public DbSet<zt_inventarios_acumulados> zt_inventarios_acumulados { get; set; }
        public DbSet<zt_inventarios_conteos> zt_inventarios_conteos { get; set; }

        public FicDBContext(string FicPaDataBasePath)
        {
            this.FicLoDataBasePath = FicPaDataBasePath;
         
            FicMetCreateDataBase();
        }

        private async void FicMetCreateDataBase()
        {
            try
            {
                await Database.EnsureCreatedAsync();
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("Alerta", e.Message.ToString(), "Ok");
            }
        }

        protected async override void OnModelCreating(ModelBuilder modelBuilder)
        {
            try
            {
              #region INVENTARIOS
                
                modelBuilder.Entity<zt_inventarios_conteos>()
                    .HasKey(c => new { c.NumConteo, c.IdInventario, c.IdAlmacen, c.IdSKU, c.IdUnidadMedida, c.IdUbicacion });

                modelBuilder.Entity<zt_inventarios_conteos>().HasIndex(x => x.NumConteo).IsUnique(false);

              
                modelBuilder.Entity<zt_inventarios_acumulados>()
                   .HasKey(c => new { c.IdInventario, c.IdSKU, c.IdUnidadMedida });



                modelBuilder.Entity<zt_inventarios_acumulados>();

                #endregion
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("Alerta", e.ToString(), "Ok");
            }
        }

        protected async override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            try
            {
                optionsBuilder.UseSqlite($"Filename={FicLoDataBasePath}");
                optionsBuilder.EnableSensitiveDataLogging();
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("ALERTA", e.Message.ToString(), "Ok");
            }
        }

    }

}
