using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace s10259894_prg2_assg2
{
    public abstract class IceCream
    {
        private string option;
        public string Option
        {
            get { return option; }
            set { option = value.ToLower(); }
        }

        private int scoops;
        public int Scoops
        {
            get { return scoops; }
            set { scoops = value; }
        }

        private List<Flavour> flavours = new List<Flavour>();
        public List<Flavour> Flavours
        {
            get { return flavours; }
            set { flavours = value; }
        }

        private List<Topping> toppings = new List<Topping>();
        public List<Topping> Toppings
        {
            get { return toppings; }
            set { toppings = value; }
        }

        public IceCream() { }

        public IceCream(string option, int scoops, List<Flavour> flavours, List<Topping> toppings)
        {
            this.Option = option;
            this.Scoops = scoops;
            this.Flavours = flavours;
            this.Toppings = toppings;
        }

        public abstract double CalculatePrice();
        public override string ToString()
        {
            return $"Option: {Option}, Scoops: {Scoops}, Flavours: {Flavours}, Toppings: {Toppings}";
        }
    }
}
