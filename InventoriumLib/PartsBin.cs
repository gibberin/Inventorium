using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        [DisplayName("X")]
        public int RackIndexX { get; set; }
        [DisplayName("Y")]
        public int RackIndexY { get; set; }
        [DisplayName("Z")]
        public int RackIndexZ { get; set; }
    }
}
