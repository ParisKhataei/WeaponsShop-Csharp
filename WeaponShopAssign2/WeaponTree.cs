using System;
using System.Collections.Generic;
using System.Text;

namespace WeaponShopAssign2
{
    // The binary search tree for the weapons
    class WeaponTree
    {
        // the root node of the tree
        public WeaponNode rootNode;

        // Constructor
        public WeaponTree()
        {
            rootNode = null;
        }

        // Add a new weapon to the tree
        public void AddWeapon(Weapon w)
        {
            WeaponNode newNode = new WeaponNode();
            newNode.NodeWeapon = w;
            newNode.LeftChild = null;
            newNode.RightChild = null;

            // if this is the first weapon
            if (rootNode == null)
            {
                rootNode = newNode;
            }
            else
            {
                // traverse down to the left or right subtree to find the location at which weapon is tobe added.
                WeaponNode current = rootNode;

                while (true) 
                {
                    int compResult = w.weaponName.CompareTo(current.NodeWeapon.weaponName);

                    if (compResult < 0)
                    {
                        if (current.LeftChild != null)
                        {
                            current = current.LeftChild;
                        }
                        else
                        {
                            current.LeftChild = newNode;
                            break;
                        }
                    }
                    else if (compResult > 0)
                    {
                        if (current.RightChild != null)
                        {
                            current = current.RightChild;
                        }
                        else
                        {
                            current.RightChild = newNode;
                            break;
                        }
                    }
                }
            }
        }

        // Search if a weapon exists in the armory.
        public Weapon SearchWeapon(String name)
        {
            WeaponNode current = rootNode;

            while (current != null)
            {
                int compResult = name.CompareTo(current.NodeWeapon.weaponName);

                if (compResult < 0)
                {
                    current = current.LeftChild;
                }
                else if (compResult > 0)
                {
                    current = current.RightChild;
                }
                else return current.NodeWeapon;
            }

            return null;
        }

        // print details of all the weapons in InOrder.
        public void printInorder()
        {
            if (rootNode == null)
            {
                Console.WriteLine("No weapons in the Armory yet.");
                return;
            }
            printInOrder(rootNode);
        }

        private void printInOrder(WeaponNode node)
        { 
            if (node == null)
                return;

            /* first recur on left child */
            printInOrder(node.LeftChild);

            /* then print the data of node */
            Console.WriteLine(node.NodeWeapon.ToString());

            /* now recur on right child */
            printInOrder(node.RightChild);
        }

        public void deleteWeapon(Weapon w)
        {
            rootNode = deleteRec(rootNode, w);
        }

        /* A recursive function to insert a new key in BST */
        private WeaponNode deleteRec(WeaponNode root, Weapon w)
        { 
            /* Base Case: If the tree is empty */
            if (root == null) return root;

            /* Otherwise, recur down the tree */
            int compResult = w.weaponName.CompareTo(root.NodeWeapon.weaponName);
            if (compResult < 0)
                root.LeftChild = deleteRec(root.LeftChild, w);
            else if (compResult > 0)
                root.RightChild = deleteRec(root.RightChild, w);

            // if key is same as root's key, then This is the node to be deleted  
            else
            {
                // node with only one child or no child  
                if (root.LeftChild == null)
                    return root.RightChild;
                else if (root.RightChild == null)
                    return root.LeftChild;

                // node with two children: Get the 
                // inorder successor (smallest  
                // in the right subtree)  
                root.NodeWeapon = minValue(root.RightChild);

                // Delete the inorder successor  
                root.RightChild = deleteRec(root.RightChild, root.NodeWeapon);
            }
            return root;
        }

        Weapon minValue(WeaponNode root)
        {
            Weapon minv = root.NodeWeapon;
            while (root.LeftChild != null)
            {
                minv = root.LeftChild.NodeWeapon;
                root = root.LeftChild;
            }
            return minv;
        }
    }


}
