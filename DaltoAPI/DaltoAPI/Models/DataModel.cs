﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DaltoAPI.Models
{
    public class ColorModel
    {
        public string Cor { get; set; }
        public int Quantidade { get; set; }
        public int? IdCor { get; set; }
        public string Hexadecimal { get; set; }
    }
}