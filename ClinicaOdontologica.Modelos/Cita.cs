using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaOdontologica.Modelos
{
    [Table("citas")]
    public class Cita
    {
        [Key]
        [Column("id_cita")]
        public int IdCita { get; set; }

        [Column("fecha_cita")]
        [Required]
        public DateTime fechaCita { get; set; }

        [MaxLength(200)]
        [Required]
        public string? motivo { get; set; }

        [Column("estado_cita")]
        [MaxLength(20)]
        public string? estadoCita { get; set; }

        [ForeignKey("Paciente")]
        [Column("id_paciente")]
        [Required]
        public int IdPaciente { get; set; }

        [ForeignKey("Odontologo")]
        [Column("id_odontologo")]
        [Required]
        public int IdOdontologo { get; set; }

        [ForeignKey("Consultorio")]
        [Column("id_consultorio")]
        [Required]
        public int IdConsultorio { get; set; }

        // Objetos de navegación

        public Paciente? Paciente { get; set; }
        public Odontologo? Odontologo { get; set; }
        public Consultorio? Consultorio { get; set; }

        //Relaciones

        public List<DetalleCita>? DetallesCita { get; set; } = new List<DetalleCita>();
        public List<Receta>? Recetas { get; set; } = new List<Receta>();
    }
}
