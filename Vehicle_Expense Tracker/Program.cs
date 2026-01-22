using BusinessLayer.Interface;
using DatabaseLayer;
using DatabaseLayer.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IVehicle_Type,Vehicle_TypeRepositories>();
builder.Services.AddScoped<ICrane_Vehicle, Crane_VehicleRepositories>();
builder.Services.AddScoped<IService_Master,Service_MasterRepositories>();
builder.Services.AddScoped<IVehicle_Loan,Vehicle_LoanRepositories>();
builder.Services.AddScoped<ILoan_Installment,Loan_InstallmentRepositories>();
builder.Services.AddScoped<IService_Parts,Service_PartsRepositories>();
builder.Services.AddScoped<ICraneOilChangeLog,CraneOilChangeLogRepositories>();
builder.Services.AddScoped<IFuel_Expenses,Fuel_ExpensesRepositories>();
builder.Services.AddScoped<ICraneOtherExpenses, CraneOtherExpensesRepositories>();
builder.Services.AddScoped<ICrane_Insurance, Crane_InsuranceRepositories>();
builder.Services.AddScoped<IInsurance_Premium, InsurancePremiumRepositories>();
builder.Services.AddDBService();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
