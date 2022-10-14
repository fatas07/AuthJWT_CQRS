using AuthJWT_CQRS.Business.Extensions.ServiceCollection;
using AuthJWT_CQRS.Data.Extensions.ServiceCollection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
                .ConfigureApiBehaviorOptions(o =>
                {
                    o.SuppressModelStateInvalidFilter = true;
                })
                .AddJsonOptions(o =>
                {
                    o.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                    o.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                });

builder.Services.AddServiceData();
builder.Services.AddServiceBusiness();

var app = builder.Build();

//app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
