using Ecommerce.Database;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Ecommerce.BLL;
using Ecommerce.BLL.Abstruction;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Ecommerce.Repository.Abstruction;
using Ecommerce.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

namespace Ecommerce.Configuration
{
    public static class ConfigureServices
    {
        public static void GlobalConfigureServices(IConfiguration configuration, IServiceCollection services)
        {
            services.AddDbContext<EcommerceDbContext>(options =>
                {
                    options.UseSqlServer(configuration.GetSection("ConnectionString").Value);
                });

            services.AddTransient<DbContext, EcommerceDbContext>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserManager, UserManager>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<ICategoryManager, CategoryManager>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IProductManager, ProductManager>();
            services.AddTransient<IShoppingCartManager, ShoppingCartManager>();
            services.AddTransient<IShoppingCartRepository, ShoppingCartRepository>();
            services.AddTransient<ICartItemRepository, CartItemRepository>();
            services.AddTransient<ICartItemManager, CartItemManager>();


            services.AddCors();

        }

        public static void Configure(IApplicationBuilder app)
        {
            app.UseCors(options =>
            
                options.WithOrigins("http://localhost:4200")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
            );
        }
    }
}
