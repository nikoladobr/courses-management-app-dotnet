﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Course
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public int Ects { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
