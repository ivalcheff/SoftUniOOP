﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorderControl.Models.Interfaces
{
    public interface IBirthable
    {
        string Name { get; set; }
        string Birthdate { get; set; }
    }
}
