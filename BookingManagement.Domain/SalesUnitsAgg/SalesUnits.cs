using _0_Framework.Domain;
using BookingManagement.Domain.ShopsAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingManagement.Domain.SalesUnitsAgg
{
     public class SalesUnits: EntityBase
    {
        
        public string Name { get;private set; }
        public string Country { get; private set; }
        public string Currency { get; private set; }
        public bool IsRemoved { get;set; }
        public List<Shops> Shops { get; set; }
        

        // these three property didnot want from me but
        // are nessessary in real world 
        //PictureAlt && PictureTitle for seo
        //i point to them but not implimenting
        //public string Picture { get; private set; }
        //public string PictureAlt { get; private set; }
        //public string PictureTitle { get; private set; }

        //these three property is assign and set just for seo
        //public string Keywords { get; private set; }
        //public string MetaDescription { get; private set; }
        //public string Slug { get; private set; }

        public SalesUnits(string name, string country, string currency)
        {
            Name = name;
            Country = country;
            Currency = currency;
            IsRemoved = false;
        }

        public void Edit(string name, string country, string currency)
        {
            Name = name;
            Country = country;
            Currency = currency;
        }
        public void Removed()
        {
            IsRemoved = true;
        }
    }
}
