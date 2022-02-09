using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAccountManagement
{
    public class StockManagement
    {
        public void Report(string filepath)
        {
            try
            {
                using (StreamReader reader = new StreamReader(filepath))
                {
                    var json = reader.ReadToEnd();
                    var items = JsonConvert.DeserializeObject<List<CalculateStock>>(json);
                    Console.WriteLine("Name\t" + "NumOfShere\t" + "SherePrice\t" + "totalAmount");
                    int totalValueOfStock=0; 
                    foreach (var data in items)

                    {
                        Console.WriteLine(data.Name + "\t" + data.NumOfShere + "\t" + data.SherePrice + "\t" + data.NumOfShere * data.SherePrice);
                         
                        totalValueOfStock += data.NumOfShere * data.SherePrice;
                    }
                    Console.WriteLine("total value of stock ",totalValueOfStock);
                    

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
