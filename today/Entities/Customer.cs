using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace today.Entities
{
    public class Customer
    {

        public int customerId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string name { get; set; }

        [Column(TypeName = "nvarchar(150)")]
        public string? address { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string phone { get; set; }
    }
}
