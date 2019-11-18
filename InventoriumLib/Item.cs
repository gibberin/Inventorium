using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InventoriumLib
{
    public class Item : InvObject
    {
        public string Description { get; set; }
        public string Features { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string InfoUrl { get; set; }
        [DisplayName("Serial #")]
        public string SerialNumber { get; set; }
        public string Source { get; set; }
        [DisplayName("Price")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public float? UnitPrice { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}")]
        public float? Tax { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}")]
        public float? Shipping { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("Acquired")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")] 
        public DateTime? DateOfAcquisition { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("Expires")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")] 
        public DateTime? ExpirationDate { get; set; }

        public Application Assignment { get; set; }

        public float? Height { get; set; }
        public float? Width { get; set; }
        public float? Depth { get; set; }
        public float? Weight { get; set; }

        public PartsBin Bin { get; set; }

        public string ImageID;

        public Item()
        {
            DateOfAcquisition = DateTime.Now;
            ExpirationDate = DateTime.MaxValue;
        }
    }
}
