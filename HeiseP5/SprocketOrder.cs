/*
 * Programmer: Chris Heise (crheise@icloud.com)
 * School: Central New Mexico Community College
 * Course: CIS 1280 .NET I/C# Programming
 * Instructor: Rob Garner
 * Date: 23 March 2021
 * 
 * Program: P5 Sprocket Order Form
 * Purpose: Use XAML to create an order form and multiple
 *          inheritance to represent types of sprockets.
 * File: SprocketOrder.cs
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeiseP5
{
    /// <summary>
    /// A class representing an order of sprockets.
    /// </summary>
    public class SprocketOrder
    {
        public List<Sprocket> Sprockets { get; private set; }
        public Address CustAddress { get; set; }
        public string CustName { get; set; }
        public decimal TotalPrice { get; private set; }        

        public SprocketOrder()
        {
            Sprockets = new List<Sprocket>();
            CustAddress = new Address();
        }

        public SprocketOrder(Sprocket sprocket, Address custAddress, string custName, decimal price)
        {
            Sprockets = new List<Sprocket>();
            Sprockets.Add(sprocket);
            CustAddress = custAddress;
            CustName = custName;
            TotalPrice = price;
        }

        /// <summary>
        /// Method for adding a sprocket to an order.
        /// </summary>
        /// <param name="sprocket">The sprocket to be added.</param>
        public void Add(Sprocket sprocket)
        {
            Sprockets.Add(sprocket);
            CalcPrice();
        }

        /// <summary>
        /// Method for removing a sprocket from an order.
        /// </summary>
        /// <param name="sprocket">The sprocket to be removed.</param>
        public void Remove(Sprocket sprocket)
        {
            Sprockets.Remove(sprocket);
            CalcPrice();
        }

        private void CalcPrice()
        {
            TotalPrice = 0.0M;
            foreach(var item in Sprockets)
            {
                TotalPrice += item.Price;
            }
        }

        public override string ToString()
        {
            if(CustAddress is null)
            {
                return $"{CustName}: {Sprockets.Count} items, Total Price: {TotalPrice:c}"
                + "\nLocal Pickup\n\n";
            }
            else
            {                
                return $"{CustName}: {Sprockets.Count} items, Total Price: {TotalPrice:c}"
                + $"\nShip to: {CustAddress}\n\n";
            }
        }

    }
}
