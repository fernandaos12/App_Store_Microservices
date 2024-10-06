using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GeekShopping.Api.Model.Base
{
    public class BaseEntity
    {
        [Key]
        [Column("Id")]
        public int Id {get; set;}
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}