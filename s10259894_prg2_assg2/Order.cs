using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace s10259894_prg2_assg2
{
    public class Order
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private DateTime timeReceived = new DateTime();
        public DateTime TimeReceived
        {
            get { return timeReceived; }
            set { timeReceived = value; }
        }

        private DateTime? timeFullfilled;
        public DateTime? TimeFullfilled
        {
            get { return timeFullfilled; }
            set { timeFullfilled = value; }
        }

        private List<IceCream> iceCreamList = new List<IceCream>();
        public List<IceCream> IceCreamList
        {
            get { return iceCreamList; }
            set { iceCreamList = value; }
        }

        public Order() { }

        public Order(int Id, DateTime timeReceived)
        {
            this.Id = Id;
            this.TimeReceived = timeReceived;
        }
        public static void ModifyIceCream(int choice, List<IceCream> IceCreamList)
        {
            if (choice < IceCreamList.Count)
            {
                IceCream chosen = IceCreamList[choice];
                Console.WriteLine("----------- Modifying IceCream ------");
                if (chosen.Option == "waffle")
                {
                    Console.WriteLine("Select which part of the icecream you would like to modify \n [1]option\n [2] scoops\n [3] flavours \n [4] toppings \n[5] Waffle Flavour ");
                    int option = 0;
                    option = Convert.ToInt32(chosen.Option);
                    if (option == 1) //change type of ice cream
                    {
                        Console.WriteLine("Choose which type you would like: \n [1] Cup \n [2] Cone");
                        string changetype = Console.ReadLine();
                        if (changetype == "1")
                        {
                            Cup newType = new Cup("cup", chosen.Scoops, chosen.Flavours, chosen.Toppings);
                            IceCreamList[choice] = newType;
                            Console.WriteLine("Successfully changed type to cup");
                        }
                        else if (changetype == "2") 
                        {
                            Console.WriteLine("Would you like to add chocolate dipping? (Y/N)");
                            string response = Console.ReadLine().ToLower();
                            if (response == "y")
                            {
                                Cone newType = new Cone("cone", chosen.Scoops, chosen.Flavours, chosen.Toppings, true);
                                IceCreamList[choice] = newType;
                            }
                            else if (response == "n")
                            {
                                Cone newType = new Cone("cone", chosen.Scoops, chosen.Flavours, chosen.Toppings, false);
                                IceCreamList[choice] = newType;
                            }
                            else
                            {
                                Console.WriteLine("Wrong input given!");
                            }
                            Console.WriteLine("Successfully changed type to cone");
                        }
                    }
                    else if (option == 2)
                    {
                        Console.WriteLine("Change number scoops \n current selection: ");
                        Console.WriteLine($"Number of scoops: {chosen.Scoops}");
                        for (int i = 0; i < chosen.Scoops; i++)
                        {
                            Console.WriteLine($"Scoop {i}: {chosen.Flavours[i]}");
                        }
                        Console.WriteLine("Which scoop would u like to change? ");
                        for (int i = 0; i < chosen.Scoops; i++)
                        {
                            Console.WriteLine($"{i} \t {chosen.Flavours[i]}");
                        }
                        Console.WriteLine($"[{chosen.Scoops + 1}] I would like to change the number of scoops");
                        int resp = Convert.ToInt32(Console.ReadLine());
                        if (resp <= chosen.Scoops)
                        {
                            Console.WriteLine("Which flavour would u like to replace this scoop with? \n  vanilla, chocolate, strawberry, durian, ube, sea salt");
                            string chosenflav = Console.ReadLine();
                            if (chosenflav != "vanilla" || chosenflav != "chocolate" || chosenflav != "strawberry" || chosenflav != "durian" || chosenflav != "ube" || chosenflav != "sea salt")
                            {
                                Console.WriteLine("invalid flavour. ");
                            }
                            chosen.Flavours[resp].Type = chosenflav;
                            Console.WriteLine("successfully changed flavour");
                        }
                    }
                    else if (option == 3)
                    {
                        Console.WriteLine("Change flavour");
                        for (int i = 0; i < chosen.Scoops; i++)
                        {
                            Console.WriteLine($"Scoop {i}: {chosen.Flavours[i]}");
                        }
                        Console.WriteLine("Which scoop would u like to change? ");
                        for (int i = 0; i < chosen.Scoops; i++)
                        {
                            Console.WriteLine($"{i} \t {chosen.Flavours[i]}");
                        }
                        int resp = Convert.ToInt32(Console.ReadLine());
                        if (resp <= chosen.Scoops)
                        {
                            Console.WriteLine("Which flavour would u like to replace this scoop with? \n  vanilla, chocolate, strawberry, durian, ube, sea salt");
                            string chosenflav = Console.ReadLine().ToLower();
                            if (chosenflav != "vanilla" || chosenflav != "chocolate" || chosenflav != "strawberry" || chosenflav != "durian" || chosenflav != "ube" || chosenflav != "sea salt")
                            {
                                Console.WriteLine("invalid flavour. ");
                            }
                            if (chosenflav == "vanilla" || chosenflav == "chocolate" || chosenflav == "strawberry")
                            {
                                Flavour f1 = new Flavour(chosenflav, false, chosen.Flavours[resp].Quantity);
                                chosen.Flavours[resp] = f1;
                                Console.WriteLine("Successfully changed flavour");
                            }
                            else if (chosenflav == "durian" || chosenflav == "ube" || chosenflav == "sea salt")
                            {
                                Flavour f1 = new Flavour(chosenflav, true, chosen.Flavours[resp].Quantity);
                                chosen.Flavours[resp] = f1;
                                Console.WriteLine("Successfully changed flavour");
                            }
                            Console.WriteLine();
                        }
                    }
                    else if (option == 4)
                    {
                        Console.WriteLine("Change Toppings");
                        Console.WriteLine("Current toppings: \n ");
                        for (int i = 0;  i < chosen.Toppings.Count; i++)
                        {
                            Console.WriteLine($"{i} \t" + chosen.Toppings[i].ToString());
                        }
                        Console.WriteLine("What topping would you like to change? ");
                        int resp = Convert.ToInt32(Console.ReadLine());
                        if (resp <= chosen.Toppings.Count)
                        {
                            Console.WriteLine("What topping would you like to replace this with? \n Sprinkles, Mochi, Sago, Oreos");
                            string newtopping = Console.ReadLine().ToLower();
                            Topping T = new Topping(newtopping);
                            chosen.Toppings[resp] = T;
                            Console.WriteLine("Successfully changed topping.");
                        }
                    }
                }
                else if (chosen.Option == "cone")
                {
                    Console.WriteLine("Select which part of the icecream you would like to modify \n [1]option\n [2] scoops\n [3] flavours \n [4] toppings \n[5] Dipping ");
                    int option = 0;
                    option = Convert.ToInt32(chosen.Option);
                    if (option == 1) //change type of ice cream
                    {
                        Console.WriteLine("Choose which type you would like: \n [1] Cup \n [2] Waffle");
                        string changetype = Console.ReadLine();
                        if (changetype == "1")
                        {
                            Cup newType = new Cup("cup", chosen.Scoops, chosen.Flavours, chosen.Toppings);
                            IceCreamList[choice] = newType;
                            Console.WriteLine("Successfully changed type to cup");
                        }
                        else if (changetype == "2") // change the scoops 
                        {
                            Console.WriteLine("What flavour would you like the waffle to be? Red velvet, charcoal, pandan waffle, plain");
                            string response = Console.ReadLine().ToLower();
                            Waffle newType = new Waffle("Waffle", chosen.Scoops, chosen.Flavours, chosen.Toppings, response);
                            IceCreamList[choice] = newType;
                            Console.WriteLine("Successfully changed type to Waffle");
                        }
                    }
                    else if (option == 2)
                    {
                        Console.WriteLine("Change number scoops \n current selection: ");
                        Console.WriteLine($"Number of scoops: {chosen.Scoops}");
                        for (int i = 0; i < chosen.Scoops; i++)
                        {
                            Console.WriteLine($"Scoop {i}: {chosen.Flavours[i]}");
                        }
                        Console.WriteLine("Which scoop would u like to change? ");
                        for (int i = 0; i < chosen.Scoops; i++)
                        {
                            Console.WriteLine($"{i} \t {chosen.Flavours[i]}");
                        }
                        Console.WriteLine($"[{chosen.Scoops + 1}] I would like to change the number of scoops");
                        int resp = Convert.ToInt32(Console.ReadLine());
                        if (resp <= chosen.Scoops)
                        {
                            Console.WriteLine("Which flavour would u like to replace this scoop with? \n  vanilla, chocolate, strawberry, durian, ube, sea salt");
                            string chosenflav = Console.ReadLine();
                            if (chosenflav != "vanilla" || chosenflav != "chocolate" || chosenflav != "strawberry" || chosenflav != "durian" || chosenflav != "ube" || chosenflav != "sea salt")
                            {
                                Console.WriteLine("invalid flavour. ");
                            }
                            chosen.Flavours[resp].Type = chosenflav;
                            Console.WriteLine("successfully changed flavour");
                        }
                    }
                    else if (option == 3)
                    {
                        Console.WriteLine("Change flavour");
                        for (int i = 0; i < chosen.Scoops; i++)
                        {
                            Console.WriteLine($"Scoop {i}: {chosen.Flavours[i]}");
                        }
                        Console.WriteLine("Which scoop would u like to change? ");
                        for (int i = 0; i < chosen.Scoops; i++)
                        {
                            Console.WriteLine($"{i} \t {chosen.Flavours[i]}");
                        }
                        int resp = Convert.ToInt32(Console.ReadLine());
                        if (resp <= chosen.Scoops)
                        {
                            Console.WriteLine("Which flavour would u like to replace this scoop with? \n  vanilla, chocolate, strawberry, durian, ube, sea salt");
                            string chosenflav = Console.ReadLine().ToLower();
                            if (chosenflav != "vanilla" || chosenflav != "chocolate" || chosenflav != "strawberry" || chosenflav != "durian" || chosenflav != "ube" || chosenflav != "sea salt")
                            {
                                Console.WriteLine("invalid flavour. ");
                            }
                            if (chosenflav == "vanilla" || chosenflav == "chocolate" || chosenflav == "strawberry")
                            {
                                Flavour f1 = new Flavour(chosenflav, false, chosen.Flavours[resp].Quantity);
                                chosen.Flavours[resp] = f1;
                                Console.WriteLine("Successfully changed flavour");
                            }
                            else if (chosenflav == "durian" || chosenflav == "ube" || chosenflav == "sea salt")
                            {
                                Flavour f1 = new Flavour(chosenflav, true, chosen.Flavours[resp].Quantity);
                                chosen.Flavours[resp] = f1;
                                Console.WriteLine("Successfully changed flavour");
                            }
                            Console.WriteLine();
                        }
                    }
                    else if (option == 4)
                    {
                        Console.WriteLine("Change Toppings");
                        Console.WriteLine("Current toppings: \n ");
                        for (int i = 0; i < chosen.Toppings.Count; i++)
                        {
                            Console.WriteLine($"{i} \t" + chosen.Toppings[i].ToString());
                        }
                        Console.WriteLine("What topping would you like to change? ");
                        int resp = Convert.ToInt32(Console.ReadLine());
                        if (resp <= chosen.Toppings.Count)
                        {
                            Console.WriteLine("What topping would you like to replace this with? \n Sprinkles, Mochi, Sago, Oreos");
                            string newtopping = Console.ReadLine().ToLower();
                            Topping T = new Topping(newtopping);
                            chosen.Toppings[resp] = T;
                            Console.WriteLine("Successfully changed topping.");
                        }
                    }
                }
                else if (chosen.Option == "cup")
                {
                    Console.WriteLine("Select which part of the icecream you would like to modify \n [1]option\n [2] scoops\n [3] flavours \n [4] toppings \n[5] Dipping ");
                    int option = 0;
                    option = Convert.ToInt32(chosen.Option);
                    if (option == 1) //change type of ice cream
                    {
                        Console.WriteLine("Choose which type you would like: \n [1] Cone \n [2] Waffle");
                        string changetype = Console.ReadLine();
                        if (changetype == "1")
                        {
                            Console.WriteLine("Would you like to add chocolate dipping? (Y/N)");
                            string response = Console.ReadLine().ToLower();
                            if (response == "y")
                            {
                                Cone newType = new Cone("cone", chosen.Scoops, chosen.Flavours, chosen.Toppings, true);
                                IceCreamList[choice] = newType;
                            }
                        }
                        else if (changetype == "2") 
                        {
                            Console.WriteLine("What flavour would you like the waffle to be? Red velvet, charcoal, pandan waffle, plain");
                            string response = Console.ReadLine().ToLower();
                            Waffle newType = new Waffle("Waffle", chosen.Scoops, chosen.Flavours, chosen.Toppings, response);
                            IceCreamList[choice] = newType;
                            Console.WriteLine("Successfully changed type to Waffle");
                        }
                    }
                    else if (option == 2)
                    {
                        Console.WriteLine("Change number scoops \n current selection: ");
                        Console.WriteLine($"Number of scoops: {chosen.Scoops}");
                        for (int i = 0; i < chosen.Scoops; i++)
                        {
                            Console.WriteLine($"Scoop {i}: {chosen.Flavours[i]}");
                        }
                        Console.WriteLine("Which scoop would u like to change? ");
                        for (int i = 0; i < chosen.Scoops; i++)
                        {
                            Console.WriteLine($"{i} \t {chosen.Flavours[i]}");
                        }
                        Console.WriteLine($"[{chosen.Scoops + 1}] I would like to change the number of scoops");
                        int resp = Convert.ToInt32(Console.ReadLine());
                        if (resp <= chosen.Scoops)
                        {
                            Console.WriteLine("Which flavour would u like to replace this scoop with? \n  vanilla, chocolate, strawberry, durian, ube, sea salt");
                            string chosenflav = Console.ReadLine();
                            if (chosenflav != "vanilla" || chosenflav != "chocolate" || chosenflav != "strawberry" || chosenflav != "durian" || chosenflav != "ube" || chosenflav != "sea salt")
                            {
                                Console.WriteLine("invalid flavour. ");
                            }
                            chosen.Flavours[resp].Type = chosenflav;
                            Console.WriteLine("successfully changed flavour");
                        }
                    }
                    else if (option == 3)
                    {
                        Console.WriteLine("Change flavour");
                        for (int i = 0; i < chosen.Scoops; i++)
                        {
                            Console.WriteLine($"Scoop {i}: {chosen.Flavours[i]}");
                        }
                        Console.WriteLine("Which scoop would u like to change? ");
                        for (int i = 0; i < chosen.Scoops; i++)
                        {
                            Console.WriteLine($"{i} \t {chosen.Flavours[i]}");
                        }
                        int resp = Convert.ToInt32(Console.ReadLine());
                        if (resp <= chosen.Scoops)
                        {
                            Console.WriteLine("Which flavour would u like to replace this scoop with? \n  vanilla, chocolate, strawberry, durian, ube, sea salt");
                            string chosenflav = Console.ReadLine().ToLower();
                            if (chosenflav != "vanilla" || chosenflav != "chocolate" || chosenflav != "strawberry" || chosenflav != "durian" || chosenflav != "ube" || chosenflav != "sea salt")
                            {
                                Console.WriteLine("invalid flavour. ");
                            }
                            if (chosenflav == "vanilla" || chosenflav == "chocolate" || chosenflav == "strawberry")
                            {
                                Flavour f1 = new Flavour(chosenflav, false, chosen.Flavours[resp].Quantity);
                                chosen.Flavours[resp] = f1;
                                Console.WriteLine("Successfully changed flavour");
                            }
                            else if (chosenflav == "durian" || chosenflav == "ube" || chosenflav == "sea salt")
                            {
                                Flavour f1 = new Flavour(chosenflav, true, chosen.Flavours[resp].Quantity);
                                chosen.Flavours[resp] = f1;
                                Console.WriteLine("Successfully changed flavour");
                            }
                            Console.WriteLine();
                        }
                    }
                    else if (option == 4)
                    {
                        Console.WriteLine("Change Toppings");
                        Console.WriteLine("Current toppings: \n ");
                        for (int i = 0; i < chosen.Toppings.Count; i++)
                        {
                            Console.WriteLine($"{i} \t" + chosen.Toppings[i].ToString());
                        }
                        Console.WriteLine("What topping would you like to change? ");
                        int resp = Convert.ToInt32(Console.ReadLine());
                        if (resp <= chosen.Toppings.Count)
                        {
                            Console.WriteLine("What topping would you like to replace this with? \n Sprinkles, Mochi, Sago, Oreos");
                            string newtopping = Console.ReadLine().ToLower();
                            Topping T = new Topping(newtopping);
                            chosen.Toppings[resp] = T;
                            Console.WriteLine("Successfully changed topping.");
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Choice entered is invalid.");
            }
        }
        //AddIcecream method here
    }
}
