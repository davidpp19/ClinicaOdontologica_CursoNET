using Microsoft.EntityFrameworkCore;

public class ClinicaOdontologicaAPIContext(DbContextOptions<ClinicaOdontologicaAPIContext> options) : DbContext(options)
{
    public DbSet<ClinicaOdontologica.Modelos.Cita> Citas { get; set; } = default!;
    public DbSet<ClinicaOdontologica.Modelos.Consultorio> Consultorios { get; set; } = default!;
    public DbSet<ClinicaOdontologica.Modelos.DetalleCita> DetalleCitas { get; set; } = default!;
    public DbSet<ClinicaOdontologica.Modelos.Especialidad> Especialidades { get; set; } = default!;
    public DbSet<ClinicaOdontologica.Modelos.Factura> Facturas { get; set; } = default!;
    public DbSet<ClinicaOdontologica.Modelos.HistorialMedico> HistorialMedicos { get; set; } = default!;
    public DbSet<ClinicaOdontologica.Modelos.Odontologo> Odontologos { get; set; } = default!;
    public DbSet<ClinicaOdontologica.Modelos.Paciente> Pacientes { get; set; } = default!;
    public DbSet<ClinicaOdontologica.Modelos.Receta> Recetas { get; set; } = default!;
    public DbSet<ClinicaOdontologica.Modelos.Tratamiento> Tratamientos { get; set; } = default!;


}
