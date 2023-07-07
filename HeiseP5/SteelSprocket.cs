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
 * File: SteelSprocket.cs
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeiseP5
{
    /// <summary>
    /// Class representing a sprocket made of steel.
    /// Inherits from Sprocket.
    /// </summary>
    public class SteelSprocket : Sprocket
    {
        public SteelSprocket():base()
        {
        }
        public SteelSprocket(int itemID, int numItems, int numTeeth):base(itemID, numItems, numTeeth)
        {
        }

        /// <summary>
        /// Calculates the cost of a steel sprocket.
        /// Adds upcharge from base Sprocket price.
        /// </summary>
        protected override void Calculate()
        {
            Price = (decimal)(numTeeth * numItems * 0.05);
        }

        public override string ToString()
        {
            return base.ToString() + $", Material: Steel, Price: {Price:c}";
        }
    }
}
