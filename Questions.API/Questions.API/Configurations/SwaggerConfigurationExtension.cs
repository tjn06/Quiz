using System;
using Microsoft.OpenApi.Models;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;

namespace Questions.API.Configurations
{
    /// <summary>
    /// Swagger example setup using versioning and jwt authentication schema
    /// </summary>
    public static class SwaggerConfigExtensions
    {

        static string PathToXMLComments => Path.Combine(AppContext.BaseDirectory, XmlFileNameFromExecutedAssembly);
        static string XmlFileNameFromExecutedAssembly => $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";

        public static IServiceCollection AddSwaggerConfigurations(this IServiceCollection service)
        {
            service.AddEndpointsApiExplorer();
            //service.AddSwaggerGen();

            service.AddApiVersioning(setup =>
            {
                setup.DefaultApiVersion = new ApiVersion(1, 0);
                setup.AssumeDefaultVersionWhenUnspecified = true;
                setup.ReportApiVersions = true;
            });

            service.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", V1);

                options.IncludeXmlComments(PathToXMLComments);
            });

            return service;
        }

        public static WebApplication UseSwaggerConfigurations(this WebApplication app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(options => {
                options.RoutePrefix = "swagger";
                string swaggerJsonBasePath = string.IsNullOrWhiteSpace(options.RoutePrefix) ? "." : "..";
                options.SwaggerEndpoint("v1/swagger.json", "Demo doc V1");
            });

            return app;
        }

        static OpenApiInfo V1 => new OpenApiInfo
        {
            Title = "ITHS QUIZ - V1",
            Version = "v1",
            Description = "This API provides comprehensive management of questions and answers through CRUD operations, while also offering a quiz experience with dedicated endpoints for retrieving questions, responding to them, and submitting the results for assessment",
            //TermsOfService = new Uri("http://toSomewhere.com"),
            Contact = ContactIInformation,
        };


        static OpenApiContact ContactIInformation => new OpenApiContact
        {
            Name = "Tobias Johnsson",
            Email = "tobb-on@hotmail.com"
        };

    }
}


//Implement this?
//public static class SwaggerConfigurationExtension
//{
//    public static IServiceCollection AddSwaggerConfigurations(this IServiceCollection service)
//    {

//        service.AddEndpointsApiExplorer();

//        service.AddApiVersioning(setup =>
//        {
//            setup.DefaultApiVersion = new ApiVersion(1, 0);
//            setup.AssumeDefaultVersionWhenUnspecified = true;
//            setup.ReportApiVersions = true;
//        });
//    }
//}


