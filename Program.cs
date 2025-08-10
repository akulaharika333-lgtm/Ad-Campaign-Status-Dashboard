using AdCampaignDashboard.Api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<CampaignService>();

builder.Services.AddControllers();
builder.Services.AddCors(o => o.AddPolicy("AllowAll", p => p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

var app = builder.Build();
app.UseCors("AllowAll");
app.MapControllers();
app.Run();
