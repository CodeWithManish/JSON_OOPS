using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAccountManagement
{
    public class Program
    {
        static void Main(string[] args)
        {
            StockManagement stockManagement = new StockManagement();
            stockManagement.Report(@"C:\Users\kmani\Downloads\DNetFolder\StockAccountManagement\Stock.json");
            Console.ReadKey();
        }
    }
}
