using HelpDesk.Data;
using HelpDesk.Repositorios.Informacoes;
using HelpDesk.Repositorios.Usuario;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var stringDeConecao = builder.Configuration.GetConnectionString("DataBase");
builder.Services.AddDbContext<BancoContext>(o => o.UseMySql(stringDeConecao, ServerVersion.AutoDetect(stringDeConecao)));

builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
builder.Services.AddScoped<IChamadoInformacoesRepositorio, ChamadoInformacoesRepositorio>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
