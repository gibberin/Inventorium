using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InventoriumLib
{
    public class Project : InvObject
    {
        public string Description { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")] 
        public DateTime TargetDate { get; set; }

    }
}
