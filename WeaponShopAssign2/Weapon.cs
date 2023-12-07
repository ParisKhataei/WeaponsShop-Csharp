using System;
using System.Collections.Generic;
using System.Text;

namespace WeaponShopAssign2
{
    class Weapon
    {
        public string weaponName;
        public int count;
        public int range;
        public int damage;
        public double weight;
        public double cost;
        internal int id;

        // default constructor
        public Weapon()
        {
        }

        // Copy constructor
        public Weapon(Weapon w)
        {
            this.weaponName = w.weaponName;
            this.count = w.count;
            this.damage = w.damage;
            this.range = w.range;
            this.weight = w.weight;
            this.cost = w.cost;
        }

        // Parameterized constructor
        public Weapon(string n, int rang, int dam, double w, double c, int ct)
        {
            weaponName = n;
            count = ct;
            damage = dam;
            range = rang;
            weight = w;
            cost = c;
        }

        // String representation of the weapon
        public override String ToString()
        {
            return String.Format("Name: {0}, Range: {1}, Damage: {2}, Weight: {3:0.##}, Cost: {4:0.##}, ItemCount: {5}",
                            weaponName, range, damage, weight, cost, count);
        }
    }
}
