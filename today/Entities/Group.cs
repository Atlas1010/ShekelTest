using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace today.Entities
{
    public class Group
    {
        [Key]
        public int groupCode { get; set; }

        [Column(TypeName = "nvarchar(150)")]
        public string groupName { get; set; }
    }
}
