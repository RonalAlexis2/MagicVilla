using MagicVilla_API.Modelos;
using Microsoft.EntityFrameworkCore;

namespace MagicVilla_API.Datos
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }                 
        
        public DbSet<Villa> Villas { get; set; }
        public DbSet<NumeroVilla> NumeroVillas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Villa>().HasData(
                new Villa()
                {
                    Id = 1,
                    Nombre = "Villa Real",
                    Detalle = "Detalle de la Villa Real",
                    Tarifa = 200.0,
                    Ocupantes = 4,
                    MetrosCuadrados = 150,
                    ImagenUrl = "https://example.com/villa-real.jpg",
                    Amenidad = "",
                    FechaCreacion = new DateTime(2024, 1, 1),
                    FechaActualizacion = new DateTime(2024, 1, 1)
                },
                new Villa()
                {
                    Id = 2,
                    Nombre = "Villa Premium",
                    Detalle = "Detalle de la Villa Premium",
                    Tarifa = 350.0,
                    Ocupantes = 6,
                    MetrosCuadrados = 250,
                    ImagenUrl = "https://example.com/villa-premium.jpg",
                    Amenidad = "",
                    FechaCreacion = new DateTime(2024, 1, 1),
                    FechaActualizacion = new DateTime(2024, 1, 1)
                }
            );
        }

    }
}
