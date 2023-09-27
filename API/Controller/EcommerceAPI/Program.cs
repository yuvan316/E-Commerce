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

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

//adding db context dependency injection 
builder.Services.AddDbContext<AdminContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionStrings:AdminConnection"));
});
builder.Services.AddDbContext<CoreContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionStrings:CoreConnection"));
}); builder.Services.AddDbContext<MasterContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionStrings:MasterConnection"));
});

//adding business domain dependency injection
builder.Services.AddTransient<IUserBL, UserBL>();
builder.Services.AddTransient<IProductBL, ProductBL>();
builder.Services.AddTransient<ICartOrderBL, CartOrderBL>();

//adding repository dependency injection
builder.Services.AddTransient<IProductRepository,ProductRepository>();
builder.Services.AddTransient<ICartandOrderRepository,CartandOrderRepository>();
builder.Services.AddTransient<IUserRepository, UserRepository>();

TypeAdapterConfig<LoginBM, LoginDM>.NewConfig();
  
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
