using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBuy.Models
{
    public class CoverType
    {
        public int Id { get; set; }
        [DisplayName("Cover Type")]
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
