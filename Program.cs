var builder = WebApplication.CreateBuilder(args);

// A. Registrasi controller (WAJIB agar folder Controllers terbaca)
builder.Services.AddControllers();

// B. Swagger service
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// C. Swagger UI saat Development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// D. Pipeline app
app.UseHttpsRedirection();

app.UseAuthorization();

// E. Mapping Controller (Mengarahkan URL ke file Controller)
app.MapControllers();

app.Run();