using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace s10259894_prg2_assg2
{
    class Waffle : IceCream
    {
        private string waffleFlavour;
        public string WaffleFlavour
        {
            get { return waffleFlavour; }
            set { waffleFlavour = value;}
        }

        public Waffle() { }

        public Waffle(string option, int scoops, List<Flavour> flavours, List<Topping> toppings, string flavour):base(option, scoops, flavours, toppings)
        {
            Option = option;
            Scoops = scoops;
            Flavours = flavours;
            Toppings = toppings;
            WaffleFlavour = flavour;
        }

        public override double CalculatePrice()
        {
            return 1;
        }
        public override string ToString()
        {
            return $"Option: {Option}, Scoops: {Scoops}, Flavours: {Flavours}, Toppings: {Toppings} Waffle Flavour: {WaffleFlavour}";
        }
    }
}
