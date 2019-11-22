using InventoriumLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventorium.Models
{
    public class BinContentsViewModel
    {
        public Bin Bin { get; set; }

        public List<Item> Items { get; set; }

        public BinContentsViewModel()
        {
            Items = new List<Item>();
        }
    }
}
