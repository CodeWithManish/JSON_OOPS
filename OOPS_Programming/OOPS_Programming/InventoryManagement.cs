using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS_Programming
{
    class InventoryManagement
    {
        List<Inventory> riceList = new List<Inventory>();
        List<Inventory> wheatList = new List<Inventory>();
        List<Inventory> pulsesList = new List<Inventory>();

        InventoryFactory factory = new InventoryFactory();
        public void ReadData(string filePath)
        {
            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    var json = reader.ReadToEnd();
                    var itemsPresent = JsonConvert.DeserializeObject<InventoryFactory>(json);
                    this.riceList = itemsPresent.RiceList;
                    this.wheatList = itemsPresent.WheatList;
                    this.pulsesList = itemsPresent.PulsesList;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void Display()
        {
            if (this.riceList != null)
            {
                Console.WriteLine("\n==================RiceList==============\n");
                Console.WriteLine("name\t" + "price\t" + "weight\t");

                foreach (var data in this.riceList)
                {
                    Console.WriteLine(data.Name + "\t\t" + data.Price + "\t\t" + data.Weight);
                }
            }

            if (this.wheatList != null)
            {
                Console.WriteLine("\n==================WheatList================\n");
                Console.WriteLine("name\t" + "price\t" + "weight\t");

                foreach (var data in this.wheatList)
                {
                    Console.WriteLine(data.Name + "\t\t" + data.Price + "\t\t" + data.Weight);
                }
            }

            if (this.pulsesList != null)
            {
                Console.WriteLine("\n==================PulsesList==============\n");
                Console.WriteLine("name\t" + "price\t" + "weight\t");

                foreach (var data in this.pulsesList)
                {
                    Console.WriteLine(data.Name + "\t\t" + data.Price + "\t\t" + data.Weight);
                }
            }
        }

        public bool Duplicate(List<Inventory> inventory, string name)
        {
            foreach (var data in inventory)
            {
                if (data.Name == name)
                {
                    return true;
                }
            }
            return false;
        }

        public void Write(string filePath)
        {
            try
            {
                Console.WriteLine("Press 1. for Rice\nPress 2. for Wheat\nPress 3. for Pulses");
                int option = Convert.ToInt32(Console.ReadLine());
                Inventory inventory = new Inventory();
                switch (option)
                {
                    case 1:
                        inventory.Name = "Rice";
                        inventory.Price = 30;
                        inventory.Weight = 10;
                        if (!Duplicate(this.riceList, inventory.Name))
                        {
                            this.riceList.Add(inventory);
                        }
                       
                        break;

                    case 2:
                        inventory.Name = "Wheat";
                        inventory.Price = 30;
                        inventory.Weight = 10;
                        if (!Duplicate(this.wheatList, inventory.Name))
                        {
                            this.wheatList.Add(inventory);
                        }
                       
                        break;

                    case 3:
                        inventory.Name = "pulses";
                        inventory.Price =30 ;
                        inventory.Weight = 10;
                        if (!Duplicate(this.pulsesList, inventory.Name))
                        {
                            this.pulsesList.Add(inventory);
                        }
                      
                        break;
                }
                InventoryFactory inventoryFactory = new InventoryFactory();
                inventoryFactory.RiceList = this.riceList;
                inventoryFactory.WheatList = this.wheatList;
                inventoryFactory.PulsesList = this.pulsesList;

                var jsonData = JsonConvert.SerializeObject(inventoryFactory);
                File.WriteAllText(filePath, jsonData);

                ReadData(filePath);
                Display();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

           








  



