﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Page : IEntity
    {
        public int PageId { get; set; }
        public string PageName { get; set; }
        public string PageText { get; set; }
        public string PageIcon { get; set; }
        public bool PageState { get; set; }
    }
}
