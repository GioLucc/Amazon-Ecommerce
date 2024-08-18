using Ecommerce.Domain;
using Ecommerce.Domain.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrastructure.Persistence;

public class EcommerceDbContext : IdentityDbContext <User> {

    public EcommerceDbContext(DbContextOptions<EcommerceDbContext> options) : base(options) 
    {}

    public override Task <int> SaveChangesAsync(CancellationToken cancellationToken=default)
    {
        var userName = "system";

        foreach (var entry in ChangeTracker.Entries<BaseDomainModel>()) 
        {
            switch(entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedDate = DateTime.Now;
                    entry.Entity.CreatedBy = userName;
                break;
                case EntityState.Modified:
                    entry.Entity.LastModifiedDate = DateTime.Now;
                    entry.Entity.LastModifiedBy = userName;
                break;

            }
        }

        return base.SaveChangesAsync(cancellationToken);
            
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder); // in charge to build the table in the database

        builder.Entity<Category>()
            .HasMany(c =>c.Products) // c (Category) has many products
            .WithOne(p => p.Category) // p (product) has one Category
            .HasForeignKey(p => p.CategoryId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict); // if you delete a category his products wont be deleted

        builder.Entity<Product>()
            .HasMany(p =>p.Reviews) // p (Product) has many products
            .WithOne(r =>r.Product) // r (Review) has one Product
            .HasForeignKey(r => r.ProductId) // r (Review) has to be linked to a certain product
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade); // if you delete a product every review will be deleted
        
        builder.Entity<Product>()
            .HasMany(p =>p.Images) // p (Product) has many images
            .WithOne(i =>i.Product) // i (Image) has one Product
            .HasForeignKey(i => i.ProductId) // r (Review) has to be linked to a certain product
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade); // if you delete a product every image will be deleted

        builder.Entity<ShoppingCart>()
            .HasMany(sc =>sc.ShoppingCartItems) // sc (Shopping Cart) has many items
            .WithOne(ci =>ci.ShoppingCart) // ci (Cart item) is from a shopping cart
            .HasForeignKey(ci => ci.ShoppingCartId) // r (Review) has to be linked to a certain product
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade); // if you delete de shopping cart every item will be deleted

        builder.Entity<User>().Property(u => u.Id).HasMaxLength(36); // Property to set max length for column Id
        builder.Entity<User>().Property(u => u.NormalizedUserName).HasMaxLength(90); 
        builder.Entity<IdentityRole>().Property(u => u.Id).HasMaxLength(36); 
        builder.Entity<IdentityRole>().Property(u => u.NormalizedName).HasMaxLength(96); 
    }
    public DbSet<Product>? Products { get; set; }   
    public DbSet<Category>? Categories { get; set; }   
    public DbSet<Image>? Images { get; set; }   
    public DbSet<Adress>? Adresses { get; set; }   
    public DbSet<Order>? Orders { get; set; }   
    public DbSet<OrderItem>? OrderItems { get; set; }   
    public DbSet<Review>? Reviews { get; set; }   
    public DbSet<ShoppingCart>? ShoppingCarts { get; set; }   
    public DbSet<ShoppingCartItem>? shoppingCartItems { get; set; }   
    public DbSet<Country>? Countries { get; set; }   
    public DbSet<OrderAddress>? orderAdresses { get; set; }   

}