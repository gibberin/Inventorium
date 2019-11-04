using System;
using System.Collections.Generic;
using System.Text;

namespace InventoriumLib
{
    public class Project : InvObject
    {
        public string Description { get; set; }
        public DateTime TargetDate { get; set; }

    }
}
