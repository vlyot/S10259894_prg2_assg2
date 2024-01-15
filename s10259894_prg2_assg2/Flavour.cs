using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace s10259894_prg2_assg2
{
    public class Flavour
    {
        private string type;
        public string Type
        {
            get { return type; }
            set { type = value.ToLower(); }
        }

        private bool premium;
        public bool Premium
        {
            get { return premium; }
            set { premium = value; }
        }

        private int quantity;
        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public Flavour() { }

        public Flavour(string type, bool premium, int quantity)
        {
            this.Type = type;
            this.Premium = premium;
            this.Quantity = quantity;
        }
        public override string ToString()
        {
            return $"Flavour type: {Type}, premium: {Premium}, quantity: {Quantity}";
        }
    }

}
