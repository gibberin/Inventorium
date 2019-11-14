using InventoriumLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventorium.Models
{
    public class BinViewModel : PartsBin
    {
        public List<BinRack> Racks { get; set; }
        public Guid SelectedRackID { get; set; }

        public BinViewModel()
        {
            Racks = new List<BinRack>();
        }

        public BinViewModel(PartsBin bin)
        {
            ID = bin.ID;
            OwnerID = bin.OwnerID;
            Edition = bin.Edition;
            Name = bin.Name;
            Created = bin.Created;
            if (null != bin.Rack)
            {
                SelectedRackID = bin.Rack.ID;
            }
            Rack = bin.Rack;
            RackIndexX = bin.RackIndexX;
            RackIndexY = bin.RackIndexY;
            RackIndexZ = bin.RackIndexZ;
            Racks = new List<BinRack>();
        }

        public PartsBin ToBin()
        {
            PartsBin bin = new PartsBin
            {
                ID = ID,
                OwnerID = OwnerID,
                Edition = Edition,
                Name = Name,
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
