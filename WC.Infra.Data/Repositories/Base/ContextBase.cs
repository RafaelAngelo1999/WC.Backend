using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using WC.Infra.Data.Entities;
using WC.Infra.Data.Repositories;

namespace Infrastructure.Repository.Generics
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<ProdutoEntity> Produtos { get; set; }
        public DbSet<ImagemProdutoEntity> ImagensProdutos { get; set; }
        public DbSet<RotaRamificadaEntity> RotaRamificadaEntity { get; set; }
        public DbSet<RotaSementeEntity> RotaSementeEntity { get; set; }
        public DbSet<MarcaEntity> MarcaEntity { get; set; }
        public DbSet<EcommerceEntity> EcommerceEntity { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.Entity<UsuarioEntity>()
            //    .HasData( new UsuarioEntity { Id = Guid.NewGuid(), Name = "Rafael", Email = "rafael.angelo@gmail.com", Password = "123", Role = "manager"} );

            modelBuilder.Entity<ImagemProdutoEntity>()
                .HasData(new ImagemProdutoEntity { Id = Guid.NewGuid(), Name = "Rafael", Url = "rafael.angelo@gmail.com", Create_At = DateTime.Now, Update_At = DateTime.Now });
        }
    }
}

