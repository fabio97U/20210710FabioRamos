﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using VentaAutos.Server.ModelosSps;
using VentaAutos.Shared.Modelos;

namespace VentaAutos.Server.Context
{
    public partial class EasycarContext : DbContext
    {
        public EasycarContext()
        {
        }

        public EasycarContext(DbContextOptions<EasycarContext> options)
            : base(options)
        {
        }

        public virtual DbSet<cliente> cliente { get; set; }
        public virtual DbSet<marca> marca { get; set; }
        public virtual DbSet<modelo> modelo { get; set; }
        public virtual DbSet<precio> precio { get; set; }
        public virtual DbSet<servicio> servicio { get; set; }
        public virtual DbSet<tipo_negocio> tipo_negocio { get; set; }
        public virtual DbSet<vehiculo> vehiculo { get; set; }

        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<cliente>(entity =>
            {
                entity.HasKey(e => e.id_cliente)
                    .HasName("PK__cliente__677F38F593841C16");

                entity.HasIndex(e => e.dui)
                    .HasName("UQ__cliente__D876F1BF13492BE1")
                    .IsUnique();

                entity.HasIndex(e => e.nombre_completo)
                    .HasName("UQ__cliente__FE74C6CC02F8EA78")
                    .IsUnique();

                entity.Property(e => e.dui).IsUnicode(false);

                entity.Property(e => e.email).IsUnicode(false);

                entity.Property(e => e.fecha_registro).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.nombre_completo).IsUnicode(false);

                entity.Property(e => e.telefono).IsUnicode(false);
            });

            modelBuilder.Entity<marca>(entity =>
            {
                entity.HasKey(e => e.id_marca)
                    .HasName("PK__marca__7E43E99EC220DD74");

                entity.HasIndex(e => e.nombre_marca)
                    .HasName("UQ__marca__6059F5722E92FB46")
                    .IsUnique();

                entity.Property(e => e.nombre_marca).IsUnicode(false);
            });

            modelBuilder.Entity<modelo>(entity =>
            {
                entity.HasKey(e => e.id_modelo)
                    .HasName("PK__modelo__B3BFCFF19F121D52");

                entity.HasIndex(e => e.nombre_modelo)
                    .HasName("UQ__modelo__0C6EF414B25F09C6")
                    .IsUnique();

                entity.Property(e => e.nombre_modelo).IsUnicode(false);
            });

            modelBuilder.Entity<precio>(entity =>
            {
                entity.HasKey(e => e.id_precio)
                    .HasName("PK__precio__A70EF6ED8EEE4FEA");
            });

            modelBuilder.Entity<servicio>(entity =>
            {
                entity.HasKey(e => e.id_servicio)
                    .HasName("PK__servicio__6FD07FDCEAB79775");

                entity.Property(e => e.fecha_creacion).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<tipo_negocio>(entity =>
            {
                entity.HasKey(e => e.id_tipo_negocio)
                    .HasName("PK__tipo_neg__D3EEC9283608912A");

                entity.HasIndex(e => e.nombre_negocio)
                    .HasName("UQ__tipo_neg__01DE965EAC73BD1C")
                    .IsUnique();

                entity.Property(e => e.nombre_negocio).IsUnicode(false);
            });

            modelBuilder.Entity<vehiculo>(entity =>
            {
                entity.HasKey(e => e.id_vehiculo)
                    .HasName("PK__vehiculo__F5DC0F3903A9BC36");

                entity.Property(e => e.estado).IsUnicode(false);

                entity.Property(e => e.fecha_registro).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.nombre_vehiculo).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}