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
 * File: Address.cs
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeiseP5
{
    public class Address
    {
        public string City { get; set; }
        public string State { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }

        public override string ToString()
        {
            return $"{Street}\n{City}, {State} {ZipCode}";
        }

    }
}
