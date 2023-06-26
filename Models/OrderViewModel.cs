using System.ComponentModel.DataAnnotations;

namespace Entrev1sta.Models
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }
        public string? CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public string? CustomerAddress { get; set; }
    }
}
