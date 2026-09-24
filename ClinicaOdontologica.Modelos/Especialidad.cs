using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaOdontologica.Modelos
{
    [Table("especialidades")]
    public class Especialidad
    {
        [Key]
        [Column("id_especialidad", TypeName = "Serial")]
        public int IdEspecialidad { get; set; }

        [Column("nombre_especialidad")]
        [MaxLength(50)]
        [Required]
        public string nombreEspecialidad { get; set; }

        [MaxLength(200)]
        public string? descripcion { get; set; }

        //Relaciones
        List<Odontologo>? Odontologos { get; set; } = new List<Odontologo>();
    }
}
