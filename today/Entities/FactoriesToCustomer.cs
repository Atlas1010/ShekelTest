using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace today.Entities
{
    [Table("FactoriesToCustomer")]
    public class FactoriesToCustomer
    {
        [Key]
        public int id { get; set; }
        public int groupCode { get; set; }
        public int factoryCode { get; set; }
        public int customerId { get; set; }
    }
}
