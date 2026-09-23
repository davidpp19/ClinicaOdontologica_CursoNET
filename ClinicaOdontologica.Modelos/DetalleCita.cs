using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaOdontologica.Modelos
{
    [Table("detallescita")]
    public class DetalleCita
    {
        [Key]
        [Column("id_detalle_cita")]
        public int IdDetalleCita { get; set; }

        [Column("costo_aplicado", TypeName = "numeric(10,2)")]
        [Required]
        public decimal costoAplicado { get; set; }

        [Column("observaciones")]
        [MaxLength(200)]
        public string? observacion { get; set; }

        [ForeignKey("Cita")]
        [Column("id_cita")]
        [Required]
        public int IdCita { get; set; }

        [ForeignKey("Tratamiento")]
        [Column("id_tratamiento")]
        [Required]
        public int IdTratamiento { get; set; }

        // Objetos de navegación

        public Cita? Cita { get; set; }
        public Tratamiento? Tratamiento { get; set; }
    }
}
