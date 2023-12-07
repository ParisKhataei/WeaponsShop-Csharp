using System;

namespace WeaponShopAssign2
{
    class Program
    {
        // the player object
        private static Player player;

        // the weapons armory
        private static WeaponTree weapons;


        // User action to add a weapon to the armory
        public static void addWeapon()
        {
            Console.WriteLine("***********WELCOME TO THE WEAPON ADDING MENU*********");
            string weaponName; int weaponRange; int weaponDamage; double weaponWeight; double weaponCost; int weaponCount;
            Console.Write("Please enter the NAME of the Weapon: ");
            weaponName=Console.ReadLine();
            Console.Write("Please enter the Range of the Weapon (0-10): ");
            weaponRange= Convert.ToInt32(Console.ReadLine()); 
            Console.Write("Please enter the Damage of the Weapon: ");
            weaponDamage=Convert.ToInt32(Console.ReadLine()); 
            Console.Write("Please enter the Weight of the Weapon (in pounds): ");
            weaponWeight= Convert.ToDouble(Console.ReadLine());
            Console.Write("Please enter the Cost of the Weapon: ");
            weaponCost=Convert.ToDouble(Console.ReadLine());
            Console.Write("Please enter the count of the Weapon: ");
            weaponCount = Convert.ToInt32(Console.ReadLine());
            Weapon w = new Weapon(weaponName, weaponRange, weaponDamage, weaponWeight, weaponCost, weaponCount);
            weapons.AddWeapon(w);
        }

        // delete a weapon from the armory
        private static void deleteWeapon()
        {
            weapons.printInorder();
            if (weapons.rootNode == null) return;
            string name;
            Console.Write("Enter weapon to delete: ");
            name = Console.ReadLine();
            Weapon weapon = weapons.SearchWeapon(name);
            if (weapon != null)
            {
                weapons.deleteWeapon(weapon);
                Console.WriteLine("Weapon \"" + name + "\" was deleted from the store.");
            }
            else Console.WriteLine("Weapon \"" + name + "\" could not be found in the store.");
        }

        // user action to buy a weapon for the player
        public static void buyWeapon()
        {
            string choice;
            Console.WriteLine("WELCOME TO THE SHOWROOM!!!!");
            weapons.printInorder();
            Console.WriteLine(player.name + " has " + player.money+" money left.");
            if (weapons.rootNode == null) return;

            Console.Write("Please enter a weapon to buy: ");
            choice=Console.ReadLine();
            Weapon w = weapons.SearchWeapon(choice);
            if (w != null)
            {
                if (w.cost > player.money)
                {
                    Console.WriteLine("Insufficient funds to buy "+w.weaponName );
                }
                else
                {
                    player.buy(w);
                    w.count--;
                    if (w.count == 0) weapons.deleteWeapon(w);
                    player.withdraw(w.cost);
                }
            }
            else
            {
                Console.WriteLine(" ** "+choice+" not found!! **" );
            }
        }

        // Show weapons details
        private static void showWeapons()
        {
            weapons.printInorder();
        }

        // Show backpack weapons details for the player
        private static void showBackpack()
        {
            player.printBackpack();
        }

        // show player details
        private static void showPlayer()
        {
            player.printDetails();
        }

        // Show action menu to the user
        private static int showMenu()
        {
            Console.WriteLine();
            Console.WriteLine("1) Add Items to the shop.");
            Console.WriteLine("2) Delete Items from the shop.");
            Console.WriteLine("3) Show Weapons in the shop.");
            Console.WriteLine("4) Buy from the Shop.");
            Console.WriteLine("5) View Backpack.");
            Console.WriteLine("6) View Player.");
            Console.WriteLine("7) Exit.");

            while(true)
            {
                Console.Write("Your choice: ");
                int opt = Convert.ToInt32(Console.ReadLine());
                if (opt < 1 || opt > 7)
                    Console.WriteLine("Invalid Input. Try again.");
                else return opt;
            }
        }

        public static void Main(string[] args)
        {
            string pname;
            Console.Write("Please enter Player name: ");
            pname=Console.ReadLine();
            Console.Write("The amount " + pname + " has to buy weapons: ");
            double money = Convert.ToDouble(Console.ReadLine());
            player = new Player(pname, money);
            weapons = new WeaponTree();
            Boolean callQuits = false;
            while(!callQuits)
            {
                int opt = showMenu();
                switch(opt)
                {
                    case 1: addWeapon(); break;
                    case 2: deleteWeapon(); break;
                    case 3: showWeapons(); break;
                    case 4: buyWeapon(); break;
                    case 5: showBackpack(); break;
                    case 6: showPlayer(); break;
                    default: callQuits = true; break;
                }
            }
        }
    }
}
