using Eapproval.DatabaseSettings;
using Eapproval.services;
using Eapproval.Helpers;
using MongoDB.Driver;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Eapproval.Models;
using System.Text.Json;
using Newtonsoft;
using System.Text.Json.Serialization;
using Eapproval.Services;
using Eapproval.signalR;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;






var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddSignalR();
builder.Services.AddControllers();
builder.Services.AddSingleton<ConnectionsService>();
builder.Services.AddSingleton<HelperClass>();
builder.Services.AddSingleton<FileHandler>();
builder.Services.AddSingleton<UsersService>();
builder.Services.AddSingleton<TicketsService>();
builder.Services.AddSingleton<NotificationService>();
builder.Services.AddSingleton<BlogsService>();
builder.Services.AddSingleton<Notifier>();
builder.Services.AddSingleton<TeamsService>();
builder.Services.AddSingleton<TicketMailer>();
builder.Services.AddSingleton<ChatService>();
builder.Services.AddSingleton<UserApi>();
builder.Services.AddSingleton<JwtTokenService>();
builder.Services.AddSingleton<NotesService>();
builder.Services.AddSingleton<CounterService>();
builder.Services.AddSingleton<LocationService>();


builder.Services.AddCors((options) =>
{
    options.AddPolicy("FeedClientApp",
        new CorsPolicyBuilder()
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod()
            .Build());
});

builder.Services.AddHttpClient();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(p =>
{
    var key = Encoding.UTF8.GetBytes("secretKeyadfsssssssssssssssssssssssweewfewwwwwwwwwwwwwwwwwwwwwwwwwwwwwweqeqwewqeqweqweqweqweqwe");
   
    p.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
    
        IssuerSigningKey = new SymmetricSecurityKey(key)
    };
});


builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("admin", policy => policy.RequireClaim("userType", "admin"));
    options.AddPolicy("normal", policy => policy.RequireClaim("userType", "normal"));
    options.AddPolicy("support", policy => policy.RequireClaim("userType", "support"));
    options.AddPolicy("leader", policy => policy.RequireClaim("userType", "leader"));
    options.AddPolicy("power", policy => policy.RequireClaim("userType", "power"));
    options.AddPolicy("powerDepartment", policy => policy.RequireClaim("userType", "departmentPower"));
    options.AddPolicy("test", policy => policy.RequireClaim("empName", "Rabiul Islam"));
    options.AddPolicy("allpower", policy => policy.RequireClaim("userType", "departmentPower", "power", "admin"));
    
}); 



builder.Services.AddMvcCore();

builder.Services.AddControllersWithViews();





var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStaticFiles();

app.UseDefaultFiles();



app.UseHttpsRedirection();


app.UseRouting();
app.UseCors("FeedClientApp");
app.UseAuthentication();
app.UseAuthorization();



app.MapHub<ChatHub>("/chat");


/*app.Map(new PathString("/ticketing"), client =>
{
    var clientPath = Path.Combine(Directory.GetCurrentDirectory(), "./wwwroot");
    StaticFileOptions clientAppDist = new StaticFileOptions()
    {
        FileProvider = new PhysicalFileProvider(clientPath)
    };


    client.UseSpaStaticFiles(clientAppDist);

    client.UseSpa(spa =>
    {
        spa.Options.DefaultPageStaticFileOptions = clientAppDist;
    });
});*/

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");





app.Run();
