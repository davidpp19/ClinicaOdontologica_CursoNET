using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaOdontologica.Modelos
{
    [Table("recetas")]
    public class Receta
    {
        [Key]
        [Column("id_receta")]
        public int IdReceta { get; set; }

        [Column("fecha_emision")]
        [Required]
        public DateTime fechaEmision { get; set; }

        [Column("indicaciones", TypeName = "text")]
        [Required]
        public string indicacion { get; set; }

        [ForeignKey("IdCita")]
        [Column("id_cita")]
        [Required]
        public int IdCita { get; set; }
        public Cita? Cita { get; set; }
    }
}
