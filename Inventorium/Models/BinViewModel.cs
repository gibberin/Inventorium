using InventoriumLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventorium.Models
{
    public class BinViewModel : Bin
    {
        public List<Rack> Racks { get; set; }
        public Guid SelectedRackID { get; set; }

        public BinViewModel()
        {
            Racks = new List<Rack>();
        }

        public BinViewModel(Bin bin)
        {
            ID = bin.ID;
            OwnerID = bin.OwnerID;
            Edition = bin.Edition;
            Name = bin.Name;
            Description = bin.Description;
            Created = bin.Created;
            if (null != bin.Rack)
            {
                SelectedRackID = bin.Rack.ID;
            }
            Rack = bin.Rack;
            RackIndexX = bin.RackIndexX;
            RackIndexY = bin.RackIndexY;
            RackIndexZ = bin.RackIndexZ;
            Racks = new List<Rack>();
        }

        public Bin ToBin()
        {
            Bin bin = new Bin
            {
                ID = ID,
                OwnerID = OwnerID,
                Edition = Edition,
                Name = Name,
                Description = Description,
                Created = Created,
                Rack = Rack,
                RackIndexX = RackIndexX,
                RackIndexY = RackIndexY,
                RackIndexZ = RackIndexZ
            };

            return bin;
        }
    }
}
