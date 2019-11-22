using InventoriumLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventorium.Models
{
    public class ProjectAssignmentsViewModel
    {
        public Project Project { get; set; }

        public List<Item> Items { get; set; }

        public ProjectAssignmentsViewModel()
        {
            Items = new List<Item>();
        }
    }
}
