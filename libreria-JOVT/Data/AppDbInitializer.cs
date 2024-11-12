using libreria_JOVT.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace libreria_JOVT.Data
{
    public class AppDbInitializer
    {
        //metodo que agrega datos a la base de datos
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                if(!context.Books.Any())
                {
                    context.Books.AddRange(new Book()
                    {
                        Titulo = "1st Book Title",
                        Descripcion = "1st Book Description",
                        IsRead= true,
                        DateRead = DateTime.Now.AddDays(-10),
                        Rate = 4,
                        Genero = "Bibliografia",
                        ConverUrl = "https...",
                        DateAdded = DateTime.Now,
                    },
                    new Book()
                    {
                        Titulo = "2nd Book Title",
                        Descripcion = "2nd Book Description",
                        IsRead = true,
                        DateRead = DateTime.Now.AddDays(-10),
                        Rate = 4,
                        Genero = "Bibliografia",
                        ConverUrl = "https...",
                        DateAdded = DateTime.Now,
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
