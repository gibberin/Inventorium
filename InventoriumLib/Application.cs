using System;
using System.Collections.Generic;
using System.Text;

namespace InventoriumLib
{
    /// Object for tracking the application of a given inventory item, e.g. the project it is being used in.
    class Application : InvObject
    {
        string ProjectID { get; set; }

    }
}
