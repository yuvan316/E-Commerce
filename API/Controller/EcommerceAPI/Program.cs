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

    // Adding repository dependency injection
    builder.Services.AddTransient<IProductRepository, ProductRepository>();
    builder.Services.AddTransient<ICartandOrderRepository, CartandOrderRepository>();
    builder.Services.AddTransient<IUserRepository, UserRepository>();
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


    app.UseHttpsRedirection();
    app.UseStaticFiles();
    app.UseRouting();
    app.UseAuthorization();
    app.MapControllers();
    app.MapRazorPages();
    app.UseMiddleware<ExceptionMiddleware>();
    app.Run();
}
catch(Exception ex)
{
    Log.Logger.Error(ex.Message + ex.StackTrace);
}
