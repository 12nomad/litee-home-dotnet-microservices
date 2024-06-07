using Common.Behavior;
using Common.Exception.Extensions;
using Weasel.Core;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCarter();
builder.Services.AddMediatR(cfg => {
  cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
  cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
});
builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);
builder.Services.AddMarten(cfg => {
  cfg.Connection(builder.Configuration.GetConnectionString("ListingsDbContext")!);
  cfg.AutoCreateSchemaObjects = AutoCreate.All;
})
.UseLightweightSessions();
// .InitializeWith<Seed>();

var app = builder.Build();
app.MapCarter();
app.UseExceptionHandler(exceptionHandlerApp => exceptionHandlerApp.ConfigureExceptionHandler());

app.Run();
