
using ETicaretAPI.Application.Validators.Products;
using ETicaretAPI.Infrastructure;
using ETicaretAPI.Infrastructure.Filters;

using ETicaretAPI.Persistence;

using FluentValidation.AspNetCore;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

using NpgsqlTypes;

using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();//Client'tan gelen request neticvesinde oluþturulan HttpContext nesnesine katmanlardaki class'lar üzerinden(busineess logic) eriþebilmemizi saðlayan bir servistir.
builder.Services.AddPersistenceServices();
builder.Services.AddInfrastructureServices();

//builder.Services.AddStorage<LocalStorage>();

//builder.Services.AddStorage();

builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>
    policy.WithOrigins("http://localhost:4200", "https://localhost:4200").AllowAnyHeader().AllowAnyMethod().AllowCredentials()
));



builder.Services.AddHttpLogging(logging =>
{
    logging.LoggingFields = HttpLoggingFields.All;
    logging.RequestHeaders.Add("sec-ch-ua");
    logging.MediaTypeOptions.AddText("application/javascript");
    logging.RequestBodyLogLimit = 4096;
    logging.ResponseBodyLogLimit = 4096;
});

builder.Services.AddControllers(options =>
{
    options.Filters.Add<ValidationFilter>();
    
})
    .AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssemblyContaining<CreateProductValidator>())
    .ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseHttpLogging();
app.UseCors();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();


app.Run();