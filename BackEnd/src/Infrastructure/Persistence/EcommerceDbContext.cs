using Ecommer.Domain;
using Ecommerce.Domain;
using Ecommerce.Domain.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Persistence;

public class EcommerceDbContext : IdentityDbContext <User> {

    public EcommerceDbContext(DbContextOptions<EcommerceDbContext> options) : base(options) 
    {}

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder); // in charge to build the table in the database
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
    public DbSet<OrderAdress>? orderAdresses { get; set; }   

}