using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using AppDAEMovil.Models;

namespace AppDAEMovil.Data
{

    public class FicDataBaseContex : DbContext
    {
        private readonly string FicLoDataBasePath;
        
        //Gestion de Inventarios
        public DbSet<zt_cat_estatus> zt_cat_estatus { get; set; }
        public DbSet<zt_cat_cedis> zt_cat_cedis { get; set; }
        public DbSet<zt_cat_almacenes> zt_cat_almacenes { get; set; }
        public DbSet<zt_inventarios> zt_inventarios { get; set; }
        public DbSet<zt_inventarios_acumulados> zt_inventarios_acumulados { get; set; }
        public DbSet<zt_inventarios_conteos> zt_inventarios_conteos { get; set; }
        //Catalogos Unidades de Medida
        public DbSet<zt_cat_grupos_sku> zt_cat_grupos_sku { get; set; }
        public DbSet<zt_cat_productos> zt_cat_productos { get; set; }
        public DbSet<zt_cat_unidad_medidas> zt_cat_unidad_medidas { get; set; }
        public DbSet<zt_cat_productos_medidas> zt_cat_productos_medidas { get; set; }
        //Catalogo CEDIS y Almacenes
        public DbSet<zt_cat_ubicaciones> zt_cat_ubicaciones { get; set; }
        public DbSet<zt_almacenes_ubicaciones> zt_almacenes_ubicaciones { get; set; }

        public FicDataBaseContex(string FicPaDataBasePath)
        {   //FIC: /data/user/0/com.companyname.AppEvaMovilRoot/files/DB_COCACOLA_NAY.db3
            this.FicLoDataBasePath = FicPaDataBasePath;
            //FIC: Se manda llamar el metodo que crea la BD localmente en la plataforma.
            FicMetCreateDataBase();
        }//BUILDER

        //This method is responsible for creating the database locally
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
        }//Database creation method

        //https://hintdesk.com/2014/03/07/sqlite-with-entity-framework-code-first-and-migration/
        //public static int RequiredDatabaseVersion = 1;
        //public void Initialize()
        //{
        //    using (FicDataBaseContex courseraContext = new FicDataBaseContex())
        //    {
        //        int currentVersion = 0;
        //        if (courseraContext.SchemaInfoes.Count() > 0)
        //            currentVersion = courseraContext.SchemaInfoes.Max(x => x.Version);
        //        CourseraContextHelper mmSqliteHelper = new CourseraContextHelper();
        //        while (currentVersion < RequiredDatabaseVersion)
        //        {
        //            currentVersion++;
        //            foreach (string migration in mmSqliteHelper.Migrations[currentVersion])
        //            {
        //                courseraContext.Database.ExecuteSqlCommand(migration);
        //            }
        //            courseraContext.SchemaInfoes.Add(new SchemaInfo() { Version = currentVersion });
        //            courseraContext.SaveChanges();
        //        }
        //    }

        //}

        protected async override void OnModelCreating(ModelBuilder modelBuilder)
        {
            try
            {
              #region INVENTARIOS
                /*CREACION DE LLAVES PRIMARIAS*/
                modelBuilder.Entity<zt_cat_cedis>()
                    .HasKey(c => new { c.IdCEDI });

                modelBuilder.Entity<zt_cat_almacenes>()
                    .HasKey(c => new { c.IdAlmacen });

                modelBuilder.Entity<zt_cat_grupos_sku>()
                    .HasKey(c => new { c.IdGrupoSKU });

                modelBuilder.Entity<zt_cat_productos>()
                    .HasKey(c => new { c.IdSKU });

                modelBuilder.Entity<zt_cat_unidad_medidas>()
                    .HasKey(c => new { c.IdUnidadMedida });

                modelBuilder.Entity<zt_almacenes_ubicaciones>()
                    .HasKey(c => new { c.IdAlmacen, c.IdUbicacion });

                modelBuilder.Entity<zt_cat_estatus>()
                    .HasKey(c => new { c.IdEstatus });

                modelBuilder.Entity<zt_inventarios>()
                    .HasKey(c => new { c.IdInventario });

                modelBuilder.Entity<zt_cat_ubicaciones>()
                    .HasKey(c => new { c.IdUbicacion });

                modelBuilder.Entity<zt_inventarios_conteos>()
                    .HasKey(c => new { c.NumConteo, c.IdInventario, c.IdAlmacen, c.IdSKU, c.IdUnidadMedida, c.IdUbicacion });

                modelBuilder.Entity<zt_inventarios_conteos>().HasIndex(x => x.NumConteo).IsUnique(false);

                modelBuilder.Entity<zt_cat_productos_medidas>()
                    .HasKey(c => new { c.IdSKU, c.IdUnidadMedida });

                modelBuilder.Entity<zt_inventarios_acumulados>()
                   .HasKey(c => new { c.IdInventario, c.IdSKU, c.IdUnidadMedida });

                /*CREACION DE LLAVES FORANEAS*/
                modelBuilder.Entity<zt_cat_almacenes>()
                .HasOne(s => s.zt_cat_cedis).
                WithMany().HasForeignKey(s => new { s.IdCEDI });

                modelBuilder.Entity<zt_inventarios>()
                .HasOne(s => s.zt_cat_cedis).
                WithMany().HasForeignKey(s => new { s.IdCEDI });

                modelBuilder.Entity<zt_inventarios>()
                .HasOne(s => s.zt_cat_almacenes).
                WithMany().HasForeignKey(s => new { s.IdAlmacen });

                modelBuilder.Entity<zt_inventarios>()
                .HasOne(s => s.zt_cat_estatus).
                WithMany().HasForeignKey(s => new { s.IdEstatus });

                modelBuilder.Entity<zt_cat_productos>()
                .HasOne(s => s.zt_cat_grupos_sku).
                WithMany().HasForeignKey(s => new { s.IdGrupoSKU });

                modelBuilder.Entity<zt_cat_productos>()
                .HasOne(s => s.zt_cat_unidad_medidas).
                WithMany().HasForeignKey(s => new { s.IdUMedidaBase });

                modelBuilder.Entity<zt_almacenes_ubicaciones>()
                .HasOne(s => s.zt_cat_almacenes).
                WithMany().HasForeignKey(s => new { s.IdAlmacen });

                modelBuilder.Entity<zt_almacenes_ubicaciones>()
                .HasOne(s => s.zt_cat_ubicaciones).
                WithMany().HasForeignKey(s => new { s.IdUbicacion });

                modelBuilder.Entity<zt_inventarios_conteos>()
                .HasOne(s => s.zt_inventarios).
                WithMany().HasForeignKey(s => new { s.IdInventario });

                modelBuilder.Entity<zt_inventarios_conteos>()
                .HasOne(s => s.zt_cat_almacenes).
                WithMany().HasForeignKey(s => new { s.IdAlmacen });

                modelBuilder.Entity<zt_inventarios_conteos>()
                .HasOne(s => s.zt_cat_productos).
                WithMany().HasForeignKey(s => new { s.IdSKU });

                modelBuilder.Entity<zt_inventarios_conteos>()
                .HasOne(s => s.zt_cat_unidad_medidas).
                WithMany().HasForeignKey(s => new { s.IdUnidadMedida });

                modelBuilder.Entity<zt_inventarios_conteos>()
                .HasOne(s => s.zt_cat_ubicaciones).
                WithMany().HasForeignKey(s => new { s.IdUbicacion });

                modelBuilder.Entity<zt_cat_productos_medidas>()
                .HasOne(s => s.zt_cat_productos).
                WithMany().HasForeignKey(s => new { s.IdSKU });

                modelBuilder.Entity<zt_cat_productos_medidas>()
                .HasOne(s => s.zt_cat_unidad_medidas).
                WithMany().HasForeignKey(s => new { s.IdUnidadMedida });

                modelBuilder.Entity<zt_inventarios_acumulados>()
                .HasOne(s => s.zt_inventarios).
                WithMany().HasForeignKey(s => new { s.IdInventario });

                modelBuilder.Entity<zt_inventarios_acumulados>()

                .HasOne(s => s.zt_cat_productos).
                WithMany().HasForeignKey(s => new { s.IdSKU });

                modelBuilder.Entity<zt_inventarios_acumulados>()
                .HasOne(s => s.zt_cat_unidad_medidas).
                WithMany().HasForeignKey(s => new { s.IdUnidadMedida });
                #endregion
            }
            catch (Exception e)
            {
                await new Page().DisplayAlert("Alerta", e.ToString(), "Ok");
            }
        }//Configuration of the models

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
        }//Configuration of the connection


        //class CourseraContextMigration : DbContext
        //{
        //    public static int RequiredDatabaseVersion = 1;

        //    public DbSet<Course> Courses { get; set; }

        //    public DbSet<Student> Students { get; set; }

        //    public DbSet<SchemaInfo> SchemaInfoes { get; set; }

        //    public void Initialize()
        //    {
        //        using (CourseraContextMigration courseraContext = new CourseraContextMigration())
        //        {
        //            int currentVersion = 0;
        //            if (courseraContext.SchemaInfoes.Count() > 0)
        //                currentVersion = courseraContext.SchemaInfoes.Max(x => x.Version);
        //            CourseraContextHelper mmSqliteHelper = new CourseraContextHelper();
        //            while (currentVersion < RequiredDatabaseVersion)
        //            {
        //                currentVersion++;
        //                foreach (string migration in mmSqliteHelper.Migrations[currentVersion])
        //                {
        //                    courseraContext.Database.ExecuteSqlCommand(migration);
        //                }
        //                courseraContext.SchemaInfoes.Add(new SchemaInfo() { Version = currentVersion });
        //                courseraContext.SaveChanges();
        //            }
        //        }

        //    }
        //}



    }//CLASS

}
