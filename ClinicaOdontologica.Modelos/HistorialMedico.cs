using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaOdontologica.Modelos
{
    [Table("historialesmedicos")]
    public class HistorialMedico
    {
        [Key]
        [Column("id_historial", TypeName = "Serial")]
        public int IdHistorialMedico { get; set; }

        [Column("alergias")]
        [MaxLength(200)]
        public string alergia { get; set; }

        [Column("enfermedades_previas")]
        [MaxLength(200)]
        public string enfermedadesPrevias { get; set; }

        [Column("tipo_sangre")]
        [MaxLength(4)]
        public string tipoSangre { get; set; }

        [ForeignKey("IdPaciente")]
        [Column("id_paciente")]
        [Required]
        public int IdPaciente { get; set; }
        public Paciente? Paciente { get; set; }
    }
}