﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace s10259894_prg2_assg2
{
    class Topping
    {
        private string type;
        public string Type
        {
            get { return type; }
            set { type = value.ToLower(); }
        }

        public Topping() { }

        public Topping(string type)
        {
            Type = type;
        }

        public override string ToString()
        {
            return $"Topping: {Type}";
        }
    }
}
