using Business.Abstracts;
using Business.Concretes;
using DataAccess.Abstacts;
using DataAccess.Concretes;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IModelService,ModelManager>();
builder.Services.AddScoped<IModelDal, ModelDal>();

builder.Services.AddCors(opt=> opt.AddDefaultPolicy(p=> { p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); }));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.UseCors(opt =>
    opt.WithOrigins("http://localhost:4200")
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowCredentials());
app.Run();
