using ECommerceAPI.Persistence;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPersistenceServices();
//builder.Services.AddCors(options => options.AddPolicy("AngularClient", builder => builder.WithOrigins("http://localhost:4200/").AllowAnyMethod().AllowAnyHeader()));
    builder.Services.AddCors(options =>
       options.AddPolicy("AngularClient", builder =>
           builder.WithOrigins("https://localhost:4200", "http://localhost:4200").AllowAnyMethod().AllowAnyHeader()));


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AngularClient");
app.UseAuthorization();

app.MapControllers();

app.Run();
