using eCommerce.API.Middlewares;
using eCommerce.Core;
using eCommerce.Infrastructure;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddInfrastructure();
builder.Services.AddCore();



//Add Controllers
builder.Services.AddControllers();

var app = builder.Build();

app.UseExceptionHandlingMiddleware();   

//Routing 
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();
