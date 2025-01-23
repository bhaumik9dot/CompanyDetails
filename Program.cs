using CompanyDetails.Data;
using CompanyDetails.Extensions;
using CompanyDetails.Helpers;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddDbContext<AppDbContext>(opts =>
{
    opts.UseNpgsql(builder.Configuration["ConnectionStrings:AppConnection"], options => options.EnableRetryOnFailure());
});

builder.Services.AddControllers();

// Add dependency injection services
builder.Services.AddDependencyInjection(configuration);
// Add JWT Bearer authentication
builder.Services.AddJwtBearerAuthentication(configuration);
// Get the base URL of the application (http(s)://www.api.com) from the HTTP Request and Context.
builder.Services.AddHttpContextAccessor();
// Configure JWT Bearer
builder.Services.Configure<JwtConfig>(builder.Configuration.GetSection("JwtConfig"));

// Multipart body length limit
builder.Services.Configure<FormOptions>(options =>
{
    // Set the limit to 104 MB
    options.MultipartBodyLengthLimit = 109051904; // Bytes
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddControllers(options =>
{
    // Adds a custom ModelBinderProviders
    options.ModelBinderProviders.Insert(0, new QueryStringModelBinderProvider());
}).ConfigureApiBehaviorOptions(options =>
{
    // Adds a custom error response factory when ModelState is invalid
    options.InvalidModelStateResponseFactory = InvalidResponseFactory.ProduceErrorResponse;
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.WithOrigins("*",
            "http://192.168.1.37:8080/swagger/index.html"
        )
        .AllowAnyMethod()         // Allow all HTTP methods (GET, POST, PUT, DELETE, etc.)
        .AllowAnyHeader()         // Allow all headers (e.g., Authorization)
        .AllowCredentials();      // Allow credentials if necessary
    });
});

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCors("AllowAll");       // Apply the CORS policy
app.UseRouting();
app.UseAuthentication();       // JWT authentication middleware
app.UseAuthorization();        // Apply user authorization


app.MapControllers();
app.Run();