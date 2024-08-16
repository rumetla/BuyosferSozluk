using BuyosferSozluk.Api.Application.Extensions;
using BuyosferSozluk.Api.Infrastructure.Persistence.Extensions;
using FluentValidation.AspNetCore;
//using BuyosferSozluk.Api.WebApi.Infrastructure.ActionFilters;
//using BuyosferSozluk.Api.WebApi.Infrastructure.Extensions;
//using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddControllers()//(opt => opt.Filters.Add<ValidateModelStateFilter>())
    .AddJsonOptions(opt =>
    {
        opt.JsonSerializerOptions.PropertyNamingPolicy = null;
    })
    .AddFluentValidation();
                                  //.AddJsonOptions(opt =>
                                  //{
                                  //    opt.JsonSerializerOptions.PropertyNamingPolicy = null;
                                  //})
                                  
                                  //    .ConfigureApiBehaviorOptions(o => o.SuppressModelStateInvalidFilter = true);


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplicationRegistration();
builder.Services.AddInfrastructureRegistration(builder.Configuration);
//builder.Services.ConfigureAuth(builder.Configuration);

// Add Cors
builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.ConfigureExceptionHandling(app.Environment.IsDevelopment());

app.UseAuthentication();
app.UseAuthorization();

app.UseCors("MyPolicy");

app.MapControllers();

app.Run();