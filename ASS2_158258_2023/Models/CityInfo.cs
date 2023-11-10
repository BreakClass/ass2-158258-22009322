using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ASS2_158258_2023.Models
{
    public class CityInfo
    {
        public int Id { get; set; }

        [Required]
        public string CityName { get; set; }

        [Required]
        public string Description { get; set; }

        // 导航属性
        public List<HistoryCulture> Histories { get; set; }
        public List<SpecialtyFood> Foods { get; set; }
        public List<TouristAttraction> Attractions { get; set; }
    }
}