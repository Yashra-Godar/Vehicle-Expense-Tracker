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
builder.Services.AddScoped<IStaff_Master,Staff_MasterRepositories>();
builder.Services.AddScoped<IAdmin_Master,Admin_MasterRepositories>();
builder.Services.AddScoped<IServiceCentre, ServiceCentreRepositories>();

builder.Services.AddDBService();

// Add services to the container.
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
    });

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddSwaggerGen();  // Generates OpenAPI JSON
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy
            .AllowAnyOrigin()    // or specific origin (recommended below)
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();     // Serves JSON at /swagger/v1/swagger.json
    app.UseSwaggerUI();   // Serves UI at /swagger
}
//app.UseHttpsRedirection();

app.UseCors("AllowAll");   
app.UseAuthorization();

app.MapControllers();

app.Run();
