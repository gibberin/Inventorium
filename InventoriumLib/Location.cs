using System;
using System.Collections.Generic;
using System.Text;

namespace NventoriumLib
{
    public class Location : InvObject
    {
        public string Addr1 { get; set; }
        public string Addr2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
    }
}
