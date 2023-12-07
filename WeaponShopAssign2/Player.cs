using System;

namespace WeaponShopAssign2
{
    class Player
    {
        public string name;
        public Backpack backpack;
        public int numItems;
        public double money;

        // Constructor
        public Player(string n, double m)
        {
            name = n;
            money = m;
            numItems = 0;
            backpack = new Backpack(50, 0);
        }

        // Player buys a weapon, add weapon to player's backpack
        public void buy(Weapon w)
        {
            Console.WriteLine(w.weaponName+" bought...");
            Weapon playerWeapon = backpack.findWeapon(w.weaponName);
            if (playerWeapon != null) playerWeapon.count++;
            else
            {
                playerWeapon = new Weapon(w);
                playerWeapon.count = 1;
                backpack.add(w);
            }
            numItems++;
            Console.Write(numItems);
        }

        // money left with player is reduced by the amount.
        public void withdraw(double amt)
        {
            money = money - amt;
        }

        public bool inventoryFull()
        {
            bool full = false;
            if (numItems == 10) full = true;
            return full;
        }


        public void printCharacter()
        {
            Console.WriteLine("Name:"+name+"\n Money:"+money);
            printBackpack();
        }

        // displays information about the player's backpack
        public void printBackpack()
        {
            Console.WriteLine(name+" has " + numItems + " weapons in his backpack.");
            backpack.showWeapons();
            Console.WriteLine();
        }

        // displays information about player and the weapons he holds
        public void printDetails()
        {
            Console.WriteLine("Name: " + name + ", Money: " + money);
            printBackpack();
        }
    }
}
