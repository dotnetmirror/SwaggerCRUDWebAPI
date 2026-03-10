using Microsoft.OpenApi;
using SwaggerCRUDWebAPI.Data;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IDAL, DAL>();

builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(options => {
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "dotnetmirror Certfication API",
        Version = "v1",
        Description = "CRUD operations using ADO.NET & SQL",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "DotnNetMirror",
            Url = new Uri("https://dotnetmirror.com/Misc/ContactUs.aspx")
        },
        License = new OpenApiLicense
        {
            Name = "dotnetmirror License",
            Url = new Uri("https://dotnetmirror.com/Misc/TermsofUse.aspx")
        }

    });

    // using System.Reflection;
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

});


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseSwagger(); 
app.UseSwaggerUI();

app.Run();
