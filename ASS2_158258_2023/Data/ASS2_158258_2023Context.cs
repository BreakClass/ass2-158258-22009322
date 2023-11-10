using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ASS2_158258_2023.Data
{
    public class ASS2_158258_2023Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public ASS2_158258_2023Context() : base("name=ASS2_158258_2023Context")
        {
        }

        public System.Data.Entity.DbSet<ASS2_158258_2023.Models.CityInfo> CityInfoes { get; set; }

        public System.Data.Entity.DbSet<ASS2_158258_2023.Models.HistoryCulture> HistoryCultures { get; set; }

        public System.Data.Entity.DbSet<ASS2_158258_2023.Models.SpecialtyFood> SpecialtyFoods { get; set; }

        public System.Data.Entity.DbSet<ASS2_158258_2023.Models.TouristAttraction> TouristAttractions { get; set; }
    }
}
