using ContosoCraft.Website.Models;
using ContosoCraft.Website.Services;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddControllers();
builder.Services.AddTransient<JsonFileProductService>();

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

app.MapControllers();
app.MapBlazorHub();
//app.MapGet("/products", (context) =>
//{
//    var productService = app.Services.GetRequiredService<JsonFileProductService>().GetProducts();
//    var json=JsonSerializer.Serialize<IEnumerable<Product>>(productService);
//    return context.Response.WriteAsJsonAsync(json);
    
//});

app.Run();
