using api.Data;
using api.Helpers;
using api.Services;
using Microsoft.EntityFrameworkCore;
using Quartz;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(option => option.UseSqlite(builder.Configuration.GetConnectionString("ApiDatabase")));

builder.Services.AddControllers()
    .AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.Converters.Add(new DateOnlyJsonConverter());
        }
    );


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


/// Scheduled Jobs config
builder.Services.AddQuartz(configure => {
    configure.UseMicrosoftDependencyInjectionJobFactory();
});

builder.Services.AddQuartzHostedService(options => {
    options.WaitForJobsToComplete = true;
});
builder.Services.AddQuartz(configure =>
{
    var jobKey = new JobKey(nameof(LotteryScheduledTask));

    configure
        .AddJob<LotteryScheduledTask>(jobKey)
        .AddTrigger(
            trigger => trigger.ForJob(jobKey)
                .WithCronSchedule("0 * * * * ?") /// chạy định kỳ vào đầu mỗi giờ
                /// chạy định kỳ sau mỗi 600 giây
                // .WithSimpleSchedule(schedule => schedule.WithIntervalInSeconds(600).RepeatForever())
            );
    configure.UseMicrosoftDependencyInjectionJobFactory();
});




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await AppDbInitializer.Seed(app);

app.Run();
