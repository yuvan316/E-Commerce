#region namespaces
using CoreComponents.ExceptionHandler;
using Ecommerce_BL.BusinessDomain;
using Ecommerce_BL.BusinessDomain.Models;
using Ecommerce_BL.Interface;
using Ecommerce_Repository.DBContext.Admin;
using Ecommerce_Repository.DBContext.Core;
using Ecommerce_Repository.DBContext.Master;
using Ecommerce_Repository.IRepository;
using Ecommerce_Repository.Models;
using Ecommerce_Repository.Repository;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Serilog;
#endregion

try
{
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    builder.Services.AddRazorPages();
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "EcommerceAPI", Version = "v1" });
    });

    // Adding database context dependency injection
    builder.Services.AddDbContext<AdminContext>(options =>
    {
        options.UseNpgsql(builder.Configuration.GetConnectionString("AdminConnection"));
    });

    builder.Services.AddDbContext<CoreContext>(options =>
    {
        options.UseNpgsql(builder.Configuration.GetConnectionString("CoreConnection"));
    });

    builder.Services.AddDbContext<MasterContext>(options =>
    {
        options.UseNpgsql(builder.Configuration.GetConnectionString("MasterConnection"));
    });

    // Adding business domain dependency injection
    builder.Services.AddTransient<IUserBL, UserBL>();
    builder.Services.AddTransient<IProductBL, ProductBL>();
    builder.Services.AddTransient<ICartOrderBL, CartOrderBL>();
    builder.Services.AddTransient<IAdminBL, AdminBL>();

    // Adding repository dependency injection
    builder.Services.AddTransient<IProductRepository, ProductRepository>();
    builder.Services.AddTransient<ICartandOrderRepository, CartandOrderRepository>();
    builder.Services.AddTransient<IUserRepository, UserRepository>();
    builder.Services.AddTransient<IAdminRepository, AdminRepository>();
    builder.Services.AddTransient<ExceptionMiddleware>();
    TypeAdapterConfig<LoginBM, LoginDM>.NewConfig();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ecommerce API v1");
        });
    }
    //minimal api to fetch category data 
    app.MapGet("/GetCategories", async (IProductRepository repository) =>
    {
        var categories = await repository.Categories();
        if (categories == null)
        {
            return Results.NotFound("No categories found");
        }

        return Results.Ok(categories);
    });

    //minimal api to fetch brands data 
    app.MapGet("/GetBrands/{CategoryId}", async (String categoryId, IProductRepository repository) =>
    {
        var brands = await repository.Brands(categoryId);
        if (brands == null)
        {
            return Results.NotFound("No brands found");
        }

        return Results.Ok(brands);
    });

    //minimal api to fetch category data 
    app.MapGet("/GetProducts/{BrandId}", async (String brandId, IProductRepository repository) =>
    {
        var products = await repository.Products(brandId);
        if (products == null)
        {
            return Results.NotFound("No products found");
        }

        return Results.Ok(products);
    });

    app.UseHttpsRedirection();
    app.UseStaticFiles();
    app.UseRouting();
    app.UseAuthorization();
    app.MapControllers();
    app.MapRazorPages();
    app.UseMiddleware<ExceptionMiddleware>();
    app.Run();
}
catch (Exception ex)
{
    Log.Logger.Error(ex.Message + ex.StackTrace);
}
