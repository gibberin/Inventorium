using InventoriumLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventorium.Models
{
    public class RackContentsViewModel
    {
        public Rack Rack { get; set; }

        public List<Bin> Bins { get; set; }

        public RackContentsViewModel()
        {
            Bins = new List<Bin>();
        }
    }
}
