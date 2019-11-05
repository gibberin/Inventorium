using System;
using System.Collections.Generic;
using System.Text;

namespace InventoriumLib
{
    /// Object for tracking the application of a given inventory item, e.g. the project it is being used in.
    public class Application : InvObject
    {
        public string Project { get; set; }

        public bool Assigned { get { return string.IsNullOrWhiteSpace(Project); } }

        public Application()
        {
            Project = null;
        }
    }
}
