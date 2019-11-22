using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InventoriumLib
{
    public class Project : InvObject
    {
        public string Description { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Target Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")] 
        public DateTime? TargetDate { get; set; }

        public Project()
        {
            TargetDate = DateTime.UtcNow;
        }
    }
}
