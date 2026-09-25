using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaOdontologica.Modelos
{
    [Table("pacientes")]
    public class Paciente
    {
        [Key]
        [Column("id_paciente")]
        public int IdPaciente { get; set; }

        [MaxLength(10)]
        [Required]
        public string dni { get; set; }

        [MaxLength(50)]
        [Required]
        public string nombre { get; set; }

        [MaxLength(50)]
        [Required]
        public string apellido { get; set; }

        [Column("fecha_nacimiento", TypeName = "date")]
        [Required]
        public DateTime fechaNacimiento { get; set; }

        [MaxLength(100)]
        [Required]
        public string email { get; set; }

        [MaxLength(10)]
        public string? telefono { get; set; }

        //Relaciones
        List<Cita>? Citas { get; set; } = new List<Cita>();
    }
}
