using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace today.Entities
{ 
    [Table("Factories")]
    public class Factory
    {
       
            [Key]
            public int id { get; set; }
            public int factoryCode { get; set; }

            [Column(TypeName = "nvarchar(50)")]
            public string factoryName { get; set; }
            public int groupCode { get; set; }
       
    }
}
