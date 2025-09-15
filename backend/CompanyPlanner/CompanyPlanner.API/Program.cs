using CompanyPlanner.BusinessService.Implementations;
using CompanyPlanner.BusinessService.Interfaces;
using CompanyPlanner.DataService.DBContext;
using CompanyPlanner.DataService.Repositories.Implementations;
using CompanyPlanner.DataService.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("CrmDb"));
builder.Services.AddScoped<ILeadImageService, LeadImageService>();
builder.Services.AddScoped<ICustomerImageService, CustomerImageService>();
builder.Services.AddScoped<ILeadDataService, LeadDataService>();
builder.Services.AddScoped<ICustomerDataService, CustomerDataService>();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
