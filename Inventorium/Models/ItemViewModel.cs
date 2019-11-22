using InventoriumLib;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventorium.Models
{
    public class ItemViewModel : Item
    {
        public Guid SelectedBinID { get; set; }
        public List<Project> Projects { get; set; }
        public Guid SelectedProjectID { get; set; }
        public List<Bin> Bins;
        public string SelectedOwnerID { get; set; }
        public List<IdentityUser> Users { get; set; }

        public ItemViewModel()
        {
            Projects = new List<Project>();
            Bins = new List<Bin>();
            Users = new List<IdentityUser>();
        }

        /// <summary>
        /// Create from an existing Item
        /// </summary>
        /// <param name="item">The item to copy</param>
        public ItemViewModel(Item item)
        {
            Projects = new List<Project>();
            Bins = new List<Bin>();
            Users = new List<IdentityUser>();

            ID = item.ID;
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
            Assignment = item.Assignment;
            Height = item.Height;
            Width = item.Width;
            Depth = item.Depth;
            Weight = item.Weight;

            if ((null != item.Assignment) && item.Assignment.Assigned)
            {
                SelectedProjectID = item.Assignment.Project.ID;
            }

            if (null != item.Bin)
            {
                Bin = item.Bin;
            }

            ImageID = item.ImageID;
        }

        /// <summary>
        ///  Convert to an Item
        /// </summary>
        /// <returns>An Item object or null on failure</returns>
        public Item ToItem()
        {
            Item item = new Item()
            {
                ID = ID,
                Name = Name,
                Edition = Edition,
                OwnerID = OwnerID,
                Created = Created,
                Description = Description,
                Features = Features,
                Manufacturer = Manufacturer,
                Model = Model,
                InfoUrl = InfoUrl,
                SerialNumber = SerialNumber,
                Source = Source,
                UnitPrice = UnitPrice,
                Tax = Tax,
                Shipping = Shipping,
                DateOfAcquisition = DateOfAcquisition,
                ExpirationDate = ExpirationDate,
                Assignment = Assignment,
                Height = Height,
                Width = Width,
                Depth = Depth,
                Weight = Weight,
                Bin = Bin,
                ImageID = ImageID
            };

            return item;
        }
    }
}
