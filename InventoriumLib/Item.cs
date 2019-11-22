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
        [DataType(DataType.Url)]
        public string InfoUrl { get; set; }
        [DisplayName("Serial #")]
        public string SerialNumber { get; set; }
        public string Source { get; set; }
        [DataType(DataType.Currency)]
        [DisplayName("Price")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public float? UnitPrice { get; set; }
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public float? Tax { get; set; }
        [DataType(DataType.Currency)]
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

        [DisplayName("Application Assignment")]
        public Application Assignment { get; set; }

        [DisplayFormat(DataFormatString = "0\"")]
        public float? Height { get; set; }
        [DisplayFormat(DataFormatString = "0\"")]
        public float? Width { get; set; }
        [DisplayFormat(DataFormatString = "0\"")]
        public float? Depth { get; set; }
        [DisplayFormat(DataFormatString = "0 lbs")]
        public float? Weight { get; set; }

        public Bin Bin { get; set; }

        public string ImageID;

        public Item()
        {
            Assignment = new Application();

            DateOfAcquisition = DateTime.Now;
            ExpirationDate = DateTime.MaxValue;
        }

        public void Copy(Item item)
        {
            Name = item.Name;
            Edition = item.Edition;
            OwnerID = item.OwnerID;
            Created = item.Created;
            Description = item.Description;
            Features = item.Features;
            Manufacturer = item.Manufacturer;
            Model = item.Model;
            InfoUrl = item.InfoUrl;
            SerialNumber = item.SerialNumber;
            Source = item.Source;
            UnitPrice = item.UnitPrice;
            Tax = item.Tax;
            Shipping = item.Shipping;
            DateOfAcquisition = item.DateOfAcquisition;
            ExpirationDate = item.ExpirationDate;
            Height = item.Height;
            Width = item.Width;
            Depth = item.Depth;
            Weight = item.Weight;
            Assignment = item.Assignment;
            Bin = item.Bin;
            ImageID = item.ImageID;
        }
    }
}
