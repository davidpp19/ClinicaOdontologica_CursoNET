using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaOdontologica.Modelos
{
    [Table("odontologos")]
    public class Odontologo
    {
        [Key]
        [Column("id_odontologo")]
        public int IdOdontologo { get; set; }

        [MaxLength(50)]
        [Required]
        public string nombre { get; set; }

        [MaxLength(50)]
        [Required]
        public string apellido { get; set; }

        [Column("registro_medico")]
        [MaxLength(20)]
        [Required]
        public string registroMedico { get; set; }

        [ForeignKey("Especialidad")]
        [Column("id_especialidad")]
        [Required]
        public int IdEspecialidad { get; set; }
        public Especialidad? Especialidad { get; set; }

        //Relaciones
        List<Cita>? Citas { get; set; } = new List<Cita>();
    }
}
