using NoteService.DataAccessLayer.Extensions;
using NoteService.BusinessLogic.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDataAccessLayer(builder.Configuration);
builder.Services.AddNoteService();

builder.Services.AddControllers();

builder.Services.AddAuth(builder.Configuration);
builder.Services.AddAuthorization();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
