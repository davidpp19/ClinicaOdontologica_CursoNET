using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaOdontologica.Modelos
{
    [Table("facturas")]
    public class Factura
    {
        [Key]
        [Column("id_factura")]
        public int IdFactura { get; set; }

        [Column("fecha_emision")]
        [Required]
        public DateTime fechaEmision { get; set; }

        [Column(TypeName = "numeric(10,2)")]
        [Required]
        public decimal subtotal { get; set; }

        [Column("impuestos", TypeName = "numeric(10,2)")]
        [Required]
        public decimal impuesto { get; set; }

        [Column(TypeName = "numeric(10,2)")]
        [Required]
        public decimal total { get; set; }

        [Column("estado_pago")]
        [MaxLength(20)]
        public string? estadoPago { get; set; }

        [ForeignKey("Cita")]
        [Column("id_cita")]
        [Required]
        public int IdCita { get; set; }
        public Cita? Cita { get; set; }
    }
}
