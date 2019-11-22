using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InventoriumLib
{
    /// <summary>
    /// Manages details of a given rack of parts bins
    /// </summary>
    public class Rack : InvObject
    {
        // Use inherited Name property to track rack #

        // The physical location of the rack
        public Location Location { get; set; }

        public int Height { get; set; }
        public int Width { get; set; }
        public int Depth { get; set; }
    }
}
