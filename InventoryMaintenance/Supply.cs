using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryMaintenance
{
    public class Supply : InvItem
    {
        public string Manufacturer { get; set; } = "";

        // Jonathan Douglas
        public Supply()
        {
        }

        // Jonathan Douglas
        public Supply(
            int itemNo,
            string description,
            decimal price,
            string manufacturer)
            : base(itemNo, description, price)
        {
            Manufacturer = manufacturer;
        }

        // Jonathan Douglas
        public override string GetDisplayText()
        {
            return $"{ItemNo} {Manufacturer} {Description} ({Price:c})";
        }
    }
}