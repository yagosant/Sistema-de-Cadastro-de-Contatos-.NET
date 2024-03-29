using Microsoft.EntityFrameworkCore;
using SistemaContatos.Data;
using SistemaContatos.Repositorio;

namespace SistemaContatos
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //configurando o entity framwework
            builder.Services.AddEntityFrameworkSqlServer().AddDbContext<BancoContext>(

                options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase"))

            );

            //configurando as dependencias, toda vez q a interface for chamada ele vai instanciar
            builder.Services.AddScoped<IContatoRepositorio, ContatoRepositorio>();

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
        }
    }
}