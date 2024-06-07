using Common.Behavior;
using Common.Exception.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCarter();
builder.Services.AddMediatR(cfg => {
  cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
  cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
});
builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);
builder.Services.AddMarten(cfg => {
  cfg.Connection(builder.Configuration.GetConnectionString("WishlistDbContext")!);
})
.UseLightweightSessions();
builder.Services.AddStackExchangeRedisCache(cfg => {
  cfg.Configuration = builder.Configuration.GetConnectionString("HomeRedis")!;
});
builder.Services.AddScoped<IDbRepository, DbRepository>();
builder.Services.Decorate<IDbRepository, CachedWishlistRepository>();

var app = builder.Build();
app.MapCarter();
app.UseExceptionHandler(exceptionHandlerApp => exceptionHandlerApp.ConfigureExceptionHandler());

app.Run();
