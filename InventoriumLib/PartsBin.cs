using System;
using System.Collections.Generic;
using System.Text;

namespace InventoriumLib
{
    /// <summary>
    /// Manages details of a given parts bin
    /// </summary>
    public class PartsBin : InvObject
    {
        // Use inherited Name property to track bin #
        public BinRack Rack { get; set; }

        public int RackIndexX { get; set; }
        public int RackIndexY { get; set; }
        public int RackIndexZ { get; set; }
    }
}
