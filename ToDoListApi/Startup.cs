using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OLA1_SofQuality.ToDoListApi.Data;
using OLA1_SofQuality.ToDoListApi.Repositories;
using OLA1_SofQuality.ToDoListApi.Services;

namespace OLA1_SofQuality.ToDoListApi;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<ToDoListContext>(options =>
            options.UseSqlite("Data Source=ToDoList.db"));

        services.AddScoped<ITaskRepository, TaskRepository>();
        services.AddScoped<ITaskService, TaskService>();

        services.AddControllers();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}