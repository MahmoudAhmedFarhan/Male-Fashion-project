using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopWeb.Models
{
    public class TbSlider
    {
        [Key]
        public int sliderId { get; set; }
        [MaxLength(200)]
        public string Title { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        [MaxLength(200)]
        [Required]
        public string ImageName { get; set; }
    }
}
