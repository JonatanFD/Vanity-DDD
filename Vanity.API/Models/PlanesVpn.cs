using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Vanity.API.Models;

[Table("Planes_vpn")]
public partial class PlanesVpn
{
    [Key]
    public int PlanId { get; set; }

    [Column("nombre")]
    [StringLength(20)]
    [Unicode(false)]
    public string? Nombre { get; set; }

    [Column("descripcion")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Descripcion { get; set; }

    [Column("precio", TypeName = "decimal(18, 0)")]
    public decimal? Precio { get; set; }

    [Column("duracion")]
    public int? Duracion { get; set; }

    [ForeignKey("PlanId")]
    [InverseProperty("PlanesVpn")]
    public virtual User Plan { get; set; } = null!;
}
