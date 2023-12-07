using System;
using System.Collections.Generic;
using System.Text;

namespace WeaponShopAssign2
{   // This class implements a backpack as a linked list
    // The backpack can hold any number of weapons as long as maxWeight is not crossed.
    // If an attempt to add a weapon to backpack is rejected due to weight
    class Backpack
    {
        double maxWeight;
        double presentWeight;
        LinkedList<Weapon> myList = new LinkedList<Weapon>();


        public Backpack(double maxWeight, double presentWeight)
        {

            this.maxWeight = maxWeight;
            this.presentWeight = presentWeight;
            
        } 

        // add weapon to the backpack if the overall weight is within permissible limits
        public void add(Weapon weapon)
        {
            if (maxWeight >= presentWeight + weapon.weight)
            {
                myList.AddLast(weapon);
                presentWeight = presentWeight + weapon.weight;
                Console.WriteLine("weight "+presentWeight);
                Console.WriteLine("Added "+weapon.weaponName);

                presentWeight += weapon.weight;
            }
        }

        // find if a weapon already exists in the backpack
        public Weapon findWeapon(String name)
        {
            LinkedListNode<Weapon> node = myList.First;

            while (node != null)
            {
                if (node.Value.weaponName.CompareTo(name) == 0) return node.Value;
                node = node.Next;
            }

            return null;
        }

        // display information about weapons in the backpack.
        public void showWeapons()
        {
            LinkedListNode<Weapon> node = myList.First;

            while (node != null)
            {
                Console.WriteLine(node.Value.ToString());
                node = node.Next;
            }
        }

    }
}
