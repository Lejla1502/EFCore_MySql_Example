using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_MySql_Example.Storage.Models
{
    [Table("Customers")]
    public class Customer
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        //[StringLength(128)]
        //public string Country { get; set; }


        [ForeignKey("CustomerId")]
        public List<Order> Orders { get; set; }
    }
}
