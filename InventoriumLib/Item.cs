using System;
using System.Collections.Generic;
using System.Text;

namespace InventoriumLib
{
    public class Item : InvObject
    {
        public string Description { get; set; }
        public string Features { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string Source { get; set; }
        public float UnitPrice { get; set; }
        public float Tax { get; set; }
        public float Shipping { get; set; }
        public DateTime DateOfAcquisition { get; set; }
        public DateTime ExpirationDate { get; set; }

        public Application Assignment { get; set; }

        public float Height { get; set; }
        public float Width { get; set; }
        public float Depth { get; set; }
        public float Weight { get; set; }

        public Bin Bin { get; set; }


        public string ImageID;

        public Item()
        {
            DateOfAcquisition = DateTime.Now;
            ExpirationDate = DateTime.MaxValue;
        }
    }
}
