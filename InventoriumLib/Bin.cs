using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace InventoriumLib
{
    /// <summary>
    /// Manages details of a given parts bin
    /// </summary>
    public class Bin : InvObject
    {
        // Use inherited Name property to track bin #
        public string Description { get; set; }

        public Rack Rack { get; set; }

        [DisplayName("X")]
        public int RackIndexX { get; set; }
        [DisplayName("Y")]
        public int RackIndexY { get; set; }
        [DisplayName("Z")]
        public int RackIndexZ { get; set; }
    }
}
