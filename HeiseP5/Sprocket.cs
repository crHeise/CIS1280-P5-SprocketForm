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
 * File: Sprocket.cs
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeiseP5
{
    /// <summary>
    /// Base abstract class representing a sprocket.
    /// All sprockets of different types inherit from this.
    /// </summary>
    public abstract class Sprocket
    {
        protected int numItems;
        protected int numTeeth;
        public int NumItems
        {
            get { return numItems; }
            set { numItems = value; }
        }
        public int NumTeeth
        {
            get { return numTeeth; }
            set { numTeeth = value; }
        }
        public int ItemID { get; private set; }
        public decimal Price { get; protected set; }

        public Sprocket() : this(0, 1, 1)
        {
        }

        public Sprocket(int itemID, int numItems, int numTeeth)
        {
            ItemID = itemID;
            this.numItems = numItems;
            this.numTeeth = numTeeth;
            Calculate();
        }

        protected abstract void Calculate();

        public override string ToString()
        {
            return $"Order #{ItemID}--> Number of Items: {numItems}, Teeth: {numTeeth}";
        }

    }
}
