using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MyProject.Application;
using MyProject.Application.MapProfiles;
using MyProject.DataAccess.Context;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DataBaseContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

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


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");

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
