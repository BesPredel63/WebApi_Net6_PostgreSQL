using System.Text.Json.Serialization;
using WebApi_Net6_PostgreSQL.Helpers;
using WebApi_Net6_PostgreSQL.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to DI container
{
    var services = builder.Services;
    var env = builder.Environment;

    services.AddDbContext<DataContext>();
    services.AddCors();
    services.AddControllers().AddJsonOptions(x => {
        // serialize enums as string in api response (e.g. Role)
        x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        // ignore omitted parameters om model to enable optional params (e.g. User update)
        x.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    });
    services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    // configure DI for application services
    services.AddScoped<IUserService, UserService>();
}

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

var app = builder.Build(); 

{
    // global cors policy
    app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()
    );

    // global error handle
    app.UseMiddleware<ErrorHandlerMiddleware>();

    app.MapControllers();
}

app.Run("http://localhost:9080");

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment()) {
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseAuthorization();

//app.MapControllers();

//app.Run();
