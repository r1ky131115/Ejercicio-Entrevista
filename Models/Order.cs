using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Entrev1sta.Models;

public partial class Order
{
    [BindProperty(SupportsGet = true)]
    [Required(ErrorMessage = "El número de orden es obligatorio")]
    [Range(1, int.MaxValue, ErrorMessage = "El número de orden debe ser mayor que cero")]
    public int OrderId { get; set; }

    public string? CustomerId { get; set; }

    public virtual Customer? Customer { get; set; }

}
