using DataApiService;

var builder = WebApplication.CreateBuilder(args);

var apiWebAddress = builder.Configuration.GetValue<string>("ApiWebAddress", "https://localhost:7298/products");

builder.Services.AddScoped<BaseApiOptions>(o => new BaseApiOptions() { BaseUrl = apiWebAddress });

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IDataManager, DataManager>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
