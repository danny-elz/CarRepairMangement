using CarRepairManagement.Models;
using CarRepairManagement.Services;
using System;
using System.Collections.Generic;

namespace CarRepairManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("Welcome, please choose a command:");
                Console.WriteLine("1. Modify Vehicles");
                Console.WriteLine("2. Modify Inventory");
                Console.WriteLine("3. Modify Repair");
                Console.WriteLine("4. Exit Program");

                switch (Console.ReadLine())
                {
                    case "1":
                        ManageVehicles();
                        break;
                    case "2":
                        ManageInventory();
                        break;
                    case "3":
                        ManageRepair();
                        break;
                    case "4":
                        exit = true;
                        break;
                }
            }
        }

        static void ManageVehicles()
        {
            bool backToMainMenu = false;

            while (!backToMainMenu)
            {
                Console.WriteLine("Vehicle Management:");
                Console.WriteLine("1. List all vehicles");
                Console.WriteLine("2. Add a new vehicle");
                Console.WriteLine("3. Update a vehicle");
                Console.WriteLine("4. Delete a vehicle");
                Console.WriteLine("5. Return to main menu");

                switch (Console.ReadLine())
                {
                    case "1":
                        ListAllVehicles();
                        break;
                    case "2":
                        AddNewVehicle();
                        break;
                    case "3":
                        UpdateVehicle();
                        break;
                    case "4":
                        DeleteVehicle();
                        break;
                    case "5":
                        backToMainMenu = true;
                        break;
                }
            }
        }

        static void ListAllVehicles()
        {
            try
            {
                List<Vehicle> vehicles = VehicleService.GetAllVehicles();
                foreach (var vehicle in vehicles)
                {
                    Console.WriteLine($"ID: {vehicle.ID}, Make: {vehicle.Make}, Model: {vehicle.Model}, Year: {vehicle.Year}, New/Used: {vehicle.NewOrUsed}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while fetching vehicles: {ex.Message}");
            }
        }

        static void AddNewVehicle()
        {
            try
            {
                Console.Write("Enter Make: ");
                string make = Console.ReadLine();

                Console.Write("Enter Model: ");
                string model = Console.ReadLine();

                int year;
                while (true)
                {
                    Console.Write("Enter Year: ");
                    if (int.TryParse(Console.ReadLine(), out year) && year.ToString().Length == 4)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid year. Please enter a valid year.");
                    }
                }

                string newOrUsed;
                while (true)
                {
                    Console.Write("Enter New/Used: ");
                    newOrUsed = Console.ReadLine().ToLower();
                    if (newOrUsed == "new" || newOrUsed == "used")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter 'new' or 'used'.");
                    }
                }

                Vehicle vehicle = new Vehicle
                {
                    Make = make,
                    Model = model,
                    Year = year,
                    NewOrUsed = newOrUsed
                };

                VehicleService.AddVehicle(vehicle);
                Console.WriteLine("Vehicle added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while adding the vehicle: {ex.Message}");
            }
        }

        static void UpdateVehicle()
        {
            try
            {
                int id;
                while (true)
                {
                    Console.Write("Enter Vehicle ID to update: ");
                    if (int.TryParse(Console.ReadLine(), out id))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid ID. Please enter a valid number.");
                    }
                }

                Console.Write("Enter Make: ");
                string make = Console.ReadLine();

                Console.Write("Enter Model: ");
                string model = Console.ReadLine();

                int year;
                while (true)
                {
                    Console.Write("Enter Year: ");
                    if (int.TryParse(Console.ReadLine(), out year))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid year. Please enter a valid number.");
                    }
                }

                string newOrUsed;
                while (true)
                {
                    Console.Write("Enter New/Used: ");
                    newOrUsed = Console.ReadLine().ToLower();
                    if (newOrUsed == "new" || newOrUsed == "used")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter 'new' or 'used'.");
                    }
                }

                Vehicle vehicle = new Vehicle
                {
                    ID = id,
                    Make = make,
                    Model = model,
                    Year = year,
                    NewOrUsed = newOrUsed
                };

                VehicleService.UpdateVehicle(vehicle);
                Console.WriteLine("Vehicle updated successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while updating the vehicle: {ex.Message}");
            }
        }

        static void DeleteVehicle()
        {
            try
            {
                int id;
                while (true)
                {
                    Console.Write("Enter Vehicle ID to delete: ");
                    if (int.TryParse(Console.ReadLine(), out id))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid ID. Please enter a valid number.");
                    }
                }

                VehicleService.DeleteVehicle(id);
                Console.WriteLine("Vehicle deleted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while deleting the vehicle: {ex.Message}");
            }
        }

        static void ManageInventory()
        {
            bool backToMainMenu = false;

            while (!backToMainMenu)
            {
                Console.WriteLine("Inventory Management:");
                Console.WriteLine("1. List all inventory");
                Console.WriteLine("2. Add new inventory");
                Console.WriteLine("3. Update inventory");
                Console.WriteLine("4. Delete inventory");
                Console.WriteLine("5. Return to main menu");

                switch (Console.ReadLine())
                {
                    case "1":
                        ListAllInventory();
                        break;
                    case "2":
                        AddNewInventory();
                        break;
                    case "3":
                        UpdateInventory();
                        break;
                    case "4":
                        DeleteInventory();
                        break;
                    case "5":
                        backToMainMenu = true;
                        break;
                }
            }
        }

        static void ListAllInventory()
        {
            try
            {
                List<Inventory> inventoryList = InventoryService.GetAllInventory();
                foreach (var inventory in inventoryList)
                {
                    Console.WriteLine($"ID: {inventory.ID}, VehicleID: {inventory.VehicleID}, NumberOnHand: {inventory.NumberOnHand}, Price: {inventory.Price}, Cost: {inventory.Cost}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while fetching inventory: {ex.Message}");
            }
        }

        static void AddNewInventory()
        {
            try
            {
                int vehicleId;
                while (true)
                {
                    Console.Write("Enter Vehicle ID: ");
                    if (int.TryParse(Console.ReadLine(), out vehicleId))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Vehicle ID. Please enter a valid number.");
                    }
                }

                int numberOnHand;
                while (true)
                {
                    Console.Write("Enter Number on Hand: ");
                    if (int.TryParse(Console.ReadLine(), out numberOnHand))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid number. Please enter a valid number.");
                    }
                }

                decimal price;
                while (true)
                {
                    Console.Write("Enter Price: ");
                    if (decimal.TryParse(Console.ReadLine(), out price))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid price. Please enter a valid number.");
                    }
                }

                decimal cost;
                while (true)
                {
                    Console.Write("Enter Cost: ");
                    if (decimal.TryParse(Console.ReadLine(), out cost))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid cost. Please enter a valid number.");
                    }
                }

                Inventory inventory = new Inventory
                {
                    VehicleID = vehicleId,
                    NumberOnHand = numberOnHand,
                    Price = price,
                    Cost = cost
                };

                InventoryService.AddInventory(inventory);
                Console.WriteLine("Inventory added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while adding the inventory: {ex.Message}");
            }
        }

        static void UpdateInventory()
        {
            try
            {
                int id;
                while (true)
                {
                    Console.Write("Enter Inventory ID to update: ");
                    if (int.TryParse(Console.ReadLine(), out id))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid ID. Please enter a valid number.");
                    }
                }

                int vehicleId;
                while (true)
                {
                    Console.Write("Enter Vehicle ID: ");
                    if (int.TryParse(Console.ReadLine(), out vehicleId))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Vehicle ID. Please enter a valid number.");
                    }
                }

                int numberOnHand;
                while (true)
                {
                    Console.Write("Enter Number on Hand: ");
                    if (int.TryParse(Console.ReadLine(), out numberOnHand))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid number. Please enter a valid number.");
                    }
                }

                decimal price;
                while (true)
                {
                    Console.Write("Enter Price: ");
                    if (decimal.TryParse(Console.ReadLine(), out price))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid price. Please enter a valid number.");
                    }
                }

                decimal cost;
                while (true)
                {
                    Console.Write("Enter Cost: ");
                    if (decimal.TryParse(Console.ReadLine(), out cost))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid cost. Please enter a valid number.");
                    }
                }

                Inventory inventory = new Inventory
                {
                    ID = id,
                    VehicleID = vehicleId,
                    NumberOnHand = numberOnHand,
                    Price = price,
                    Cost = cost
                };

                InventoryService.UpdateInventory(inventory);
                Console.WriteLine("Inventory updated successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while updating the inventory: {ex.Message}");
            }
        }

        static void DeleteInventory()
        {
            try
            {
                int id;
                while (true)
                {
                    Console.Write("Enter Inventory ID to delete: ");
                    if (int.TryParse(Console.ReadLine(), out id))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid ID. Please enter a valid number.");
                    }
                }

                InventoryService.DeleteInventory(id);
                Console.WriteLine("Inventory deleted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while deleting the inventory: {ex.Message}");
            }
        }

        static void ManageRepair()
        {
            bool backToMainMenu = false;

            while (!backToMainMenu)
            {
                Console.WriteLine("Repair Management:");
                Console.WriteLine("1. List all repairs");
                Console.WriteLine("2. Add new repair");
                Console.WriteLine("3. Update repair");
                Console.WriteLine("4. Delete repair");
                Console.WriteLine("5. Return to main menu");

                switch (Console.ReadLine())
                {
                    case "1":
                        ListAllRepairs();
                        break;
                    case "2":
                        AddNewRepair();
                        break;
                    case "3":
                        UpdateRepair();
                        break;
                    case "4":
                        DeleteRepair();
                        break;
                    case "5":
                        backToMainMenu = true;
                        break;
                }
            }
        }

        static void ListAllRepairs()
        {
            try
            {
                List<Repair> repairList = RepairService.GetAllRepairs();
                foreach (var repair in repairList)
                {
                    Console.WriteLine($"ID: {repair.ID}, InventoryID: {repair.InventoryID}, WhatToRepair: {repair.WhatToRepair}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while fetching repairs: {ex.Message}");
            }
        }

        static void AddNewRepair()
        {
            try
            {
                int inventoryId;
                while (true)
                {
                    Console.Write("Enter Inventory ID: ");
                    if (int.TryParse(Console.ReadLine(), out inventoryId))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Inventory ID. Please enter a valid number.");
                    }
                }

                Console.Write("Enter What to Repair: ");
                string whatToRepair = Console.ReadLine();

                Repair repair = new Repair
                {
                    InventoryID = inventoryId,
                    WhatToRepair = whatToRepair
                };

                RepairService.AddRepair(repair);
                Console.WriteLine("Repair added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while adding the repair: {ex.Message}");
            }
        }

        static void UpdateRepair()
        {
            try
            {
                int id;
                while (true)
                {
                    Console.Write("Enter Repair ID to update: ");
                    if (int.TryParse(Console.ReadLine(), out id))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid ID. Please enter a valid number.");
                    }
                }

                int inventoryId;
                while (true)
                {
                    Console.Write("Enter Inventory ID: ");
                    if (int.TryParse(Console.ReadLine(), out inventoryId))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Inventory ID. Please enter a valid number.");
                    }
                }

                Console.Write("Enter What to Repair: ");
                string whatToRepair = Console.ReadLine();

                Repair repair = new Repair
                {
                    ID = id,
                    InventoryID = inventoryId,
                    WhatToRepair = whatToRepair
                };

                RepairService.UpdateRepair(repair);
                Console.WriteLine("Repair updated successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while updating the repair: {ex.Message}");
            }
        }

        static void DeleteRepair()
        {
            try
            {
                int id;
                while (true)
                {
                    Console.Write("Enter Repair ID to delete: ");
                    if (int.TryParse(Console.ReadLine(), out id))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid ID. Please enter a valid number.");
                    }
                }

                RepairService.DeleteRepair(id);
                Console.WriteLine("Repair deleted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while deleting the repair: {ex.Message}");
            }
        }
    }
}
