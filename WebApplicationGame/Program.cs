using Microsoft.EntityFrameworkCore;
using WebApplicationGame;
using WebApplicationGame.repository;

var builder = WebApplication.CreateBuilder();

// �������� ������ ����������� �� ����� ������������
//string connection = builder.Configuration.GetConnectionString("DefaultConnection");
var connection = Environment.GetEnvironmentVariable("DefaultConnection");


// ��������� �������� ApplicationContext � �������� ������� � ����������
builder.Services.AddDbContext<ApplicationContext>(options => options.UseNpgsql(connection));
builder.Services.AddTransient<Repository>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();




var app = builder.Build();



app.MapGet("/", (ApplicationContext db) => db.Users.ToList());

app.UseHttpsRedirection();

app.MapControllers();

app.Run();


app.Run();