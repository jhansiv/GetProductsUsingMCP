using GetProductsUsingMCP.Services;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add controllers
builder.Services.AddControllers();

// Register services
builder.Services.AddSingleton<IProductRepository, ProductRepository>();

// ---- OAuth2 / JWT Bearer Authentication ----
var jwt = builder.Configuration.GetSection("Jwt");
var key = Encoding.UTF8.GetBytes(jwt["Key"]!);

builder.Services
    .AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwt["Issuer"],
            ValidAudience = jwt["Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ClockSkew = TimeSpan.Zero
        };
    });

builder.Services.AddAuthorization();

// Add the MCP services: the transport to use (http) and the tools to register.
builder.Services
    .AddMcpServer()
     .AddAuthorizationFilters()
    .WithHttpTransport()
    .WithToolsFromAssembly();

var app = builder.Build();

// Map MCP endpoint first
app.MapMcp("mcp");

// Map controllers
app.MapControllers();

app.UseHttpsRedirection();

app.Run("http://localhost:5201");
