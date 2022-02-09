using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS_Programming
{
    public class Program
    {
        public static void Main(string[] args)
        {
            InventoryManagement inventoryManagement = new InventoryManagement();
            inventoryManagement.ReadData(@"C:\Users\kmani\Downloads\DNetFolder\OOPS_Programming\OOPS_Programming\Inventory.json");
            inventoryManagement.Write(@"C:\Users\kmani\Downloads\DNetFolder\OOPS_Programming\OOPS_Programming\Inventory.json");
            Console.ReadKey();
        }
    }
}
