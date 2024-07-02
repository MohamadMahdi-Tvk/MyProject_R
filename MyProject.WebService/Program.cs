using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MyProject.Application;
using MyProject.Application.MapProfiles;
using MyProject.DataAccess.Context;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();

builder.Services.AddDbContext<DataBaseContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfiles(new List<Profile>
    {
        new MappingProfile()
    });
});
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddApplication();



builder.Services.AddValidator();
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));



var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
