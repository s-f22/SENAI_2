using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //Define o mapeamento dos Controllers. LINHA ADICIONADA 1/5
            services.AddControllers();


            
            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "inLock.webAPI",                               
                });
            });


            // ------------------------------------- VALIDAÇÃO DO TOKEN 3/5 -----------------------------------------------

            // --- Definindo a forma de autenticação
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "JwtBearer";    // Esquema de autenticação padrão
                options.DefaultChallengeScheme = "JwtBearer";       // Define o esquema padrão que faz a verificação entre o token emitido e recebido
            })
            // Define os parâmetros de validação do token
            .AddJwtBearer("JwtBearer", options => 
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    // Valida quem está emitindo o token
                    ValidateIssuer = true,

                    // Valida qem está recebendo o token
                    ValidateAudience = true,

                    // Valida o tempo de expiração do token
                    ValidateLifetime = true,
                    
                    //DEFINIÇÃO DOS 4 PARAMETROS QUE VALIDAM O TOKEN:
                    //Defindo a chave (frase) de segurança
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("inLock-chave-webApi-autenticacao")),      
                    
                    // Tempo de expiração do token
                    ClockSkew = TimeSpan.FromMinutes(30),

                    // Define o nome do issuer, ou seja, quem emite o token
                    ValidIssuer = "inLock.webAPI",

                    // Define o audience, ou seja, quem recebe o token
                    ValidAudience = "inLock.webAPI"
                };
            });

            // ------------------------------------- VALIDAÇÃO DO TOKEN 3/5 -----------------------------------------------
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "inLock.webAPI");
                c.RoutePrefix = string.Empty;
            });


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            //4/5 Habilita a autenticação, 401
            app.UseAuthentication();

            //5/5 Habilita a autorização, 403
            app.UseAuthorization();

            
            app.UseEndpoints(endpoints =>
            {
                //Define o mapeamento dos Controllers. LINHA ADICIONADA 2/5
                endpoints.MapControllers();
            });
        }
    }
}
