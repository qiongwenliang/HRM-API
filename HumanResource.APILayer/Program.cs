using Hrm.ApplicationCore.Contract.Repository;
using Hrm.ApplicationCore.Contract.Service;
using Hrm.Infrastructure.Data;
using Hrm.Infrastructure.Repository;
using Hrm.Infrastructure.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();//add openAPI
builder.Services.AddControllers(); //it will allow you to work with webAPI
builder.Services.AddDbContext<HrmDbContext>(options => {

    options.UseSqlServer(builder.Configuration.GetConnectionString("HrmApiDb"));

});

//Dependency injection
builder.Services.AddScoped<ICandidateServiceAsync, CandidateServiceAsync>();
builder.Services.AddScoped<ICandidateRepositoryAsync, CandidateRepositoryAsync>();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin();
        policy.AllowAnyMethod();
        policy.AllowAnyHeader();
    });
});


var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting(); //middleware, we need to specify so that the route in program.cs will work, allows to use routing

app.UseCors();

app.UseEndpoints(endpoints => { endpoints.MapControllers(); }); //map your request to the particular controller


app.Run();

