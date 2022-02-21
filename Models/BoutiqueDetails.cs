using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Boutique.Models
{
    public class BoutiqueDetails
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Styles { get; set; }
        public double Price { get; set; }

        public override string ToString()
        {
            string add = $"<h1>{Name}</h1><hr/><p>The ID: {Id}</p><p>The Name: {Name}</p><p>Styles {Styles}</p><p>Price: {Price}</p>";
            return add;
        }
    }
}
