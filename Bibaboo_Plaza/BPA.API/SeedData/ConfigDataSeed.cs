using BPA.BusinessObject.Entities;
using BPA.DAO.Context;
using Microsoft.EntityFrameworkCore;

namespace BPA.API.SeedData
{
    public static class ConfigDataSeed
    {
        public static async Task SeedData(this IServiceCollection services)
        {
            string path = "./SeedData/";

            using var scope = services.BuildServiceProvider().CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            await context.Database.MigrateAsync();

            IList<Account> accounts = null!;
            //IList<Brand> categorys = null!;
            //IList<Product> products = null!;
            //IList<Order> orders = null!;
            //IList<OrderDetail> orderDetails = null!;

            //Account
            if (!context.Accounts.Any())
            {
                accounts = FileExtension<Account>.LoadJson(path, "ACCOUNT.json");
                await context.Accounts.AddRangeAsync(accounts);
                await context.SaveChangesAsync();
            }

            //Product
            //if (!context.Products.Any())
            //{
            //    products = FileExtension<Product>.LoadJson(path, "PRODUCT.json");
            //   await context.Products.AddRangeAsync(products);
            //    await context.SaveChangesAsync();
            //}

            //Brand&Product
            //if (!context.Products.Any())
            //{
            //    if (!context.Categorys.Any())
            //    {
            //        categorys = FileExtension<Category>.LoadJson(path, "CATEGORY.json");
            //        await context.Categorys.AddRangeAsync(categorys);
            //        await context.SaveChangesAsync();
            //    }
            //    products = FileExtension<Product>.LoadJson(path, "PRODUCT.json");
            //    await context.Products.AddRangeAsync(products);
            //    await context.SaveChangesAsync();
            //}
        }
    }
}
