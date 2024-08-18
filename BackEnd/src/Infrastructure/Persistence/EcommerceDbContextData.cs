using Ecommerce.Domain;
using Ecommerce.Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Ecommerce.Application.Models.Authorization;
using System.Formats.Asn1;
using Newtonsoft.Json;
using Ecommer.Domain;
using Ecommerce.Domain.Common;

namespace Ecommerce.Infrastructure.Persistance;

public class EcommerceDbContextData
{
    public static async Task LoadDataAsync(EcommerceDbContext context, UserManager<User> userManager, RoleManager <IdentityRole> roleManager, ILoggerFactory loggerFactory)
    {
        try
        {
            if(!roleManager.Roles.Any())
            {
                await roleManager.CreateAsync(new IdentityRole(Role.ADMIN));
                await roleManager.CreateAsync(new IdentityRole(Role.USER));
            }

            if (!userManager.Users.Any())
            {
                var adminUser = new User
                {
                    Name = "Giovanni",
                    Surname = "Lucchetta",
                    Email = "Giovanni1399@hotmail.com",
                    UserName ="Tano",
                    Phone = "12345678",
                    AvatarUrl = "https://firebasestorage.googleapis.com/v0/b/edificacion-app.appspot.com/o/tv_1.jpg?alt=media&token=31afb4f4-db06-4f7c-8626-1eabf1f4b7a7",
                };
                await userManager.CreateAsync(adminUser, "PasswordTano123$");
                await userManager.AddToRoleAsync(adminUser, Role.ADMIN);

                var user = new User
                {
                    Name = "Nicolas",
                    Surname = "Galeano",
                    Email = "nicogaleano123@hotmail.com",
                    UserName ="Niico",
                    Phone = "87654321",
                    AvatarUrl = "https://firebasestorage.googleapis.com/v0/b/edificacion-app.appspot.com/o/tv_1.jpg?alt=media&token=31afb4f4-db06-4f7c-8626-1eabf1f4b7a7",
                };
                await userManager.CreateAsync(user, "PasswordNico123$");
                await userManager.AddToRoleAsync(user, Role.USER);
            }

            if(!context.Categories!.Any())
            {
                var categoryData = File.ReadAllText("../Infrastructure/Data/category.json");
                var categories = JsonConvert.DeserializeObject<List<Category>>(categoryData);
                await context.Categories!.AddRangeAsync(categories!);
                await context.SaveChangesAsync();
            }

            if(!context.Products!.Any())
            {
                var productData = File.ReadAllText("../Infrastructure/Data/product.json");
                var products = JsonConvert.DeserializeObject<List<Product>>(productData);
                await context.Products!.AddRangeAsync(products!);
                await context.SaveChangesAsync();
            }

            if(!context.Images!.Any())
            {
                var imageData = File.ReadAllText("../Infrastructure/Data/image.json");
                var images = JsonConvert.DeserializeObject<List<Image>>(imageData);
                await context.Images!.AddRangeAsync(images!);
                await context.SaveChangesAsync();
            }

            if(!context.Reviews!.Any())
            {
                var reviewData = File.ReadAllText("../Infrastructure/Data/review.json");
                var reviews = JsonConvert.DeserializeObject<List<Review>>(reviewData);
                await context.Reviews!.AddRangeAsync(reviews!);
                await context.SaveChangesAsync();
            }

            if(!context.Countries!.Any())
            {
                var countriesData = File.ReadAllText("../Infrastructure/Data/countries.json");
                var countries = JsonConvert.DeserializeObject<List<Country>>(countriesData);
                await context.Countries!.AddRangeAsync(countries!);
                await context.SaveChangesAsync();
            }
        }
        catch (Exception e)
        {
            var logger = loggerFactory.CreateLogger<EcommerceDbContextData>();
            logger.LogError(e.Message);
        }
    }
}