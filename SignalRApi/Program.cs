using SignalRApi.Extensions;
using SignalRApi.Hubs;

var builder = WebApplication.CreateBuilder(args);

// SignalR ve CORS
BusinessModule.CORSExtensions(builder.Services);

// DbContext kaydetme
builder.Services.ConfigureDbContext(builder.Configuration);

// Veri eriþim katmanýný kaydetme
BusinessModule.DataAccessLayerExtensions(builder.Services);

// Servisleri kaydetme
BusinessModule.BusinessLayerExtensions(builder.Services);

//Auto Mapper
BusinessModule.AutoMapperExtensions(builder.Services);

//Validation
BusinessModule.ValidationExtensions(builder.Services);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapHub<SignalRHub>("/signalrhub");//localhost://1234/swagger/category/index //localhost://1234/signalrhub
app.ConfigureAndCheckMigration();
app.Run();