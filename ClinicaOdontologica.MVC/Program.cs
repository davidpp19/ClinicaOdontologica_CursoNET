using ClinicaOdontologica.Consumer;
using ClinicaOdontologica.Modelos;

CRUD<Cita>.Endpoint = "https://localhost:7079/api/Citas";
CRUD<Consultorio>.Endpoint = "https://localhost:7079/api/Consultorios";
CRUD<DetalleCita>.Endpoint = "https://localhost:7079/api/DetallesCitas";
CRUD<Especialidad>.Endpoint = "https://localhost:7079/api/Especialidades";
CRUD<Factura>.Endpoint = "https://localhost:7079/api/Facturas";
CRUD<HistorialMedico>.Endpoint = "https://localhost:7079/api/HistorialMedicos";
CRUD<Odontologo>.Endpoint = "https://localhost:7079/api/Odontologos";
CRUD<Paciente>.Endpoint = "https://localhost:7079/api/Pacientes";
CRUD<Receta>.Endpoint = "https://localhost:7079/api/Recetas";
CRUD<Tratamiento>.Endpoint = "https://localhost:7079/api/Tratamientos";

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
