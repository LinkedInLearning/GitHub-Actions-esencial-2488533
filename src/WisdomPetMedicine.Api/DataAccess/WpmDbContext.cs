using Microsoft.EntityFrameworkCore;

namespace WisdomPetMedicine.Api.DataAccess;
public class WpmDbContext : DbContext
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Client> Clients { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("WisdomPetMedicine");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(
            new Category(1, "Baño y estética"),
            new Category(2, "Juguetes"),
            new Category(3, "Alimentos"),
            new Category(4, "Accesorios")
            );

        modelBuilder.Entity<Product>().HasData(
            new Product(1, "Shampoo", "Shampoo acondicionador y antipulgas", 100, 1),
            new Product(2, "Jabón", "Jabón antipulgas", 50, 1),
            new Product(3, "Cepillo", "Cepillo suave", 120, 1),
            new Product(4, "Collar", "Collar de cuero", 102.5M, 4),
            new Product(5, "Pelota verde", "Pelota de plástico verde con sonido", 82.5M, 2),
            new Product(6, "Pelota roja", "Pelota de plástico roja con sonido", 83, 2),
            new Product(7, "Collar", "Collar de cuero", 145, 4),
            new Product(8, "Hueso natural", "Hueso natural de 300 g", 90, 3),
            new Product(9, "Hueso de carnaza", "Hueso de carnaza de 400 g", 115, 3),
            new Product(10, "Correa de metal", "Correa de metal de 1.5 m", 133.5M, 4)
            );

        modelBuilder.Entity<Client>().HasData(
            new Client(1, "Wisdom Pet Medicine sucursal norte", Guid.NewGuid().ToString()),
            new Client(2, "Wisdom Pet Medicine sucursal centro", Guid.NewGuid().ToString()),
            new Client(3, "Wisdom Pet Medicine sucursal sur", Guid.NewGuid().ToString())
            );
    }
}

public record Category(int Id, string Name);
public record Product(int Id, string Name, string Description, decimal Price, int CategoryId)
{
    public Category Category { get; set; }
}
public record Client(int Id, string Name, string Address);