using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace today.Entities
{
    public class GroupCustomers
    {
        [Key]
        public int groupCode { get; set; }
        public string groupName { get; set; }
        public int customerId { get; set; }
    }
}
