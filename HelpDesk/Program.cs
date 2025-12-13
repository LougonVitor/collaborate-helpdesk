using HelpDesk.Data;
using HelpDesk.Helper;
using HelpDesk.Repositorios.Chamados;
using HelpDesk.Repositorios.Informacoes;
using HelpDesk.Repositorios.Usuario;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var stringDeConecao = builder.Configuration.GetConnectionString("DataBase");
builder.Services.AddDbContext<BancoContext>(o => o.UseMySql(stringDeConecao, ServerVersion.AutoDetect(stringDeConecao)));
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
   

builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
builder.Services.AddScoped<IChamadoInformacoesRepositorio, ChamadoInformacoesRepositorio>();
builder.Services.AddScoped<IChamadoRepositorio, ChamadoRepositorio>();
builder.Services.AddScoped<ISessionUser, Session>();

builder.Services.AddSession(o =>
{
    o.Cookie.HttpOnly = true;
    o.Cookie.IsEssential = true;
});

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

app.UseSession();


app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
