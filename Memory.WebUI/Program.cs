using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Memory.Business.AutoMapper;
using Memory.Business.DependencyResolves;
using Memory.DataAccess.Concrete.EntityFramework.Context;
using Memory.Entites.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

//AutoFac
builder.Host.UseServiceProviderFactory(new
    AutofacServiceProviderFactory
    ()).ConfigureContainer<ContainerBuilder>(builder =>
    builder.RegisterModule(new BusinessModule()));

//Mapper
MapperConfiguration mapperConfiguration = new 
    MapperConfiguration(mc => mc.AddProfile(new MapperProfile()));
IMapper mapper = mapperConfiguration.CreateMapper();
builder.Services.AddSingleton(mapper);

//Context
builder.Services.AddDbContext<MemoryContext>();

//Identity
builder.Services.AddIdentity<AppIdentityUser, AppIdentityRole>().
    AddEntityFrameworkStores<MemoryContext>();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
