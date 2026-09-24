using Microsoft.EntityFrameworkCore;

public class ClinicaOdontologicaAPIContext(DbContextOptions<ClinicaOdontologicaAPIContext> options) : DbContext(options)
{
    public DbSet<ClinicaOdontologica.Modelos.Cita> Citas { get; set; } = default!;
    public DbSet<ClinicaOdontologica.Modelos.Consultorio> Consultorios { get; set; } = default!;
    public DbSet<ClinicaOdontologica.Modelos.DetalleCita> DetalleCitas { get; set; } = default!;
    public DbSet<ClinicaOdontologica.Modelos.Especialidad> Especialidades { get; set; } = default!;
    public DbSet<ClinicaOdontologica.Modelos.Factura> Facturas { get; set; } = default!;
    public DbSet<ClinicaOdontologica.Modelos.HistorialMedico> HistorialMedico { get; set; } = default!;
    public DbSet<ClinicaOdontologica.Modelos.Odontologo> Odontologo { get; set; } = default!;
    public DbSet<ClinicaOdontologica.Modelos.Paciente> Paciente { get; set; } = default!;
    public DbSet<ClinicaOdontologica.Modelos.Receta> Receta { get; set; } = default!;
    public DbSet<ClinicaOdontologica.Modelos.Tratamiento> Tratamiento { get; set; } = default!;


}
