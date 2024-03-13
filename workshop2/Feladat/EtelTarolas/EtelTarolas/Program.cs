using EtelTarolas.Data;
using EtelTarolas.Helpers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IFoodRepository, FoodRepository>();
builder.Services.AddTransient<TableBuilder>();

builder.Services.AddDbContext<FoodDbContext>(opt =>
{
    //opt.UseInMemoryDatabase("db");
    opt.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=HeroDb;Trusted_Connection=True;MultipleActiveResultSets=true");
});

var app = builder.Build();
app.UseRouting();
app.MapControllers();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
