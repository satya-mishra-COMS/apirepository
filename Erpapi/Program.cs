using dbrepository;
using Erpapi.Extensions;
using Models.Admin;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<DbConnection>(builder.Configuration.GetSection("ConnectionStrings"));
builder.Services.ConfigureCors();
builder.Services.AddScoped<IAdminRepo, Adminrepo>();
builder.Services.AddScoped<ICommonUtility, CommonUtility>();
builder.Services.AddScoped<IBiddingFiling, BiddingFiling>();
builder.Services.AddScoped<IVehicle, Vehicle>();



var app = builder.Build();

//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}
//else
//{
//    app.UseHsts();
//}
app.UseSwagger();
app.UseSwaggerUI();
app.UseCors("LGQLogisticPolicy");
app.UseHttpsRedirection();

//app.UseSwagger();
//app.UseSwaggerUI();
//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
