using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ASS2_158258_2023.Models
{
    public class SpecialtyFood
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        // 外键
        public int CityInfoId { get; set; }
        public CityInfo CityInfo { get; set; }
    }
}