using System;
using System.Collections.Generic;
using System.Text;

namespace InventoriumLib
{
    class Item : InvObject
    {
        string Description { get; set; }
        string Features { get; set; }
        string Manufacturer { get; set; }
        string Model { get; set; }
        string Source { get; set; }
        float UnitPrice { get; set; }
        float Tax { get; set; }
        float Shipping { get; set; }
        DateTime DateOfAcquisition { get; set; }
        DateTime ExpirationDate { get; set; }

        Application Assignment { get; set; }

        float Height { get; set; }
        float Width { get; set; }
        float Depth { get; set; }
        float Weight { get; set; }

        Bin Bin { get; set; }


        string ImageID;

        public Item()
        {
            DateOfAcquisition = DateTime.Now;
            ExpirationDate = DateTime.MaxValue;
        }
    }
}
