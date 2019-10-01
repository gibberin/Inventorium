using System;
using System.Collections.Generic;
using System.Text;

namespace InventoriumLib
{
    class Rack : Item
    {
        int Number { get; set; }
        Rack BinRack { get; set; }
        int RackXIndex { get; set; }
        int RackYIndex { get; set; }
        int RackZIndex { get; set; }
    }
}
