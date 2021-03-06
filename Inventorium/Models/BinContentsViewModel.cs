﻿using NventoriumLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nventorium.Models
{
    public class BinContentsViewModel
    {
        public Bin Bin { get; set; }

        public List<Item> Items { get; set; }

        public BinContentsViewModel()
        {
            Items = new List<Item>();
        }
    }
}
