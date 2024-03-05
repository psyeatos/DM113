var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ApplicationDbContext>();
var app = builder.Build();

var routeGroup = app.MapGroup("message");
/* new MessageEndpoints(routeGroup); */

app.Run();

public record Message(string Content, bool IsUrgente);

public record MessageDTO(string Content, bool IsUrgent);