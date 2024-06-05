using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Vanity.API.Models;

public partial class User
{
    [Key]
    public int UserId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Username { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Password { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Email { get; set; }

    public int? PlanId { get; set; }

    [InverseProperty("Plan")]
    public virtual PlanesVpn? PlanesVpn { get; set; }
}
