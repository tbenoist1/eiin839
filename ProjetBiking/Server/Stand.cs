﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Stand
    {
        public Stand() { }
        public Availability availabilities { get; set; }
        public int capacity { get; set; }
    }
}