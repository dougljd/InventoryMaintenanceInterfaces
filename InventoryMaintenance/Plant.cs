using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryMaintenance
{
    // Jonathan Douglas
    // The Plant class demonstrates inheritance because it inherits
    // the properties and methods of the InvItem class using ": InvItem".
    public class Plant : InvItem
    {
        public string Size { get; set; } = "";

        // Jonathan Douglas
        public Plant()
        {
        }

        // Jonathan Douglas
        public Plant(
            int itemNo,
            string description,
            decimal price,
            string size)
            : base(itemNo, description, price)
        {
            Size = size;
        }

        // Jonathan Douglas
        public override string GetDisplayText()
        {
            return $"{ItemNo} {Size} {Description} ({Price:c})";
        }
    }
}