using System;
using System.Collections.Generic;
using System.Text;

namespace InventoriumLib
{
    public class Rack : Item
    {
        public int Number { get; set; }
        public Rack BinRack { get; set; }
        public int RackXIndex { get; set; }
        public int RackYIndex { get; set; }
        public int RackZIndex { get; set; }
    }
}
