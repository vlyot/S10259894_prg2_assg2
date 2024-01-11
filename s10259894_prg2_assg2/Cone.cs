using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace s10259894_prg2_assg2
{
    class Cone : IceCream
    {
        private bool dipped;
        public bool Dipped
        {
            get { return dipped; }
            set { dipped = value; }
        }
        public Cone() { }
        public Cone(string option, int scoops, List<Flavour> flavours, List<Topping> toppings, bool dipped) : base(option, scoops, flavours, toppings)
        {
            Option = option;
            Scoops = scoops;
            Flavours = flavours;
            Toppings = toppings;
            Dipped = dipped;
        }

        public override double CalculatePrice()
        {
            double total = 0;
            foreach (Flavour f in Flavours)
            {
                if (f.Type == "vanilla" || f.Type == "chocolate" || f.Type == "strawberry")
                {
                    continue;
                }
                else if (f.Type == "durian" || f.Type == "ube" || f.Type == "sea salt")
                {
                    total += 2;
                }
            }
            if (Scoops == 1)
            {
                total += 4;
            }
            else if (Scoops == 2)
            {
                total += 5.50;
            }
            else if (Scoops == 3)
            {
                total += 6.50;
            }
            total += Toppings.Count;
            if (dipped)
            {
                total += 2;
            }
            return total;
        }

        public override string ToString()
        {
            return $"Option: {Option}, Scoops: {Scoops}, Flavours: {Flavours}, Toppings: {Toppings}";
        }
    }
}
