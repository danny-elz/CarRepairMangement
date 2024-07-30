using CarRepairManagement.DataAccess;
using CarRepairManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CarRepairManagement.Services
{
    public static class InventoryService
    {
        public static List<Inventory> GetAllInventory()
        {
            List<Inventory> inventoryList = new List<Inventory>();
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    string query = "SELECT * FROM Inventory";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        inventoryList.Add(new Inventory
                        {
                            ID = (int)reader["ID"],
                            VehicleID = (int)reader["VehicleID"],
                            NumberOnHand = (int)reader["NumberOnHand"],
                            Price = (decimal)reader["Price"],
                            Cost = (decimal)reader["Cost"]
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while fetching inventory: {ex.Message}");
            }
            return inventoryList;
        }

        public static void AddInventory(Inventory inventory)
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    string query = "INSERT INTO Inventory (VehicleID, NumberOnHand, Price, Cost) VALUES (@VehicleID, @NumberOnHand, @Price, @Cost)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@VehicleID", inventory.VehicleID);
                    cmd.Parameters.AddWithValue("@NumberOnHand", inventory.NumberOnHand);
                    cmd.Parameters.AddWithValue("@Price", inventory.Price);
                    cmd.Parameters.AddWithValue("@Cost", inventory.Cost);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while adding the inventory: {ex.Message}");
            }
        }

        public static void UpdateInventory(Inventory inventory)
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    string query = "UPDATE Inventory SET VehicleID = @VehicleID, NumberOnHand = @NumberOnHand, Price = @Price, Cost = @Cost WHERE ID = @ID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@VehicleID", inventory.VehicleID);
                    cmd.Parameters.AddWithValue("@NumberOnHand", inventory.NumberOnHand);
                    cmd.Parameters.AddWithValue("@Price", inventory.Price);
                    cmd.Parameters.AddWithValue("@Cost", inventory.Cost);
                    cmd.Parameters.AddWithValue("@ID", inventory.ID);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while updating the inventory: {ex.Message}");
            }
        }

        public static void DeleteInventory(int inventoryId)
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    SqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        // Delete dependent Repair records
                        string deleteRepairsQuery = "DELETE FROM Repair WHERE InventoryID = @InventoryID";
                        SqlCommand deleteRepairsCmd = new SqlCommand(deleteRepairsQuery, conn, transaction);
                        deleteRepairsCmd.Parameters.AddWithValue("@InventoryID", inventoryId);
                        deleteRepairsCmd.ExecuteNonQuery();

                        // Delete the Inventory record
                        string deleteInventoryQuery = "DELETE FROM Inventory WHERE ID = @ID";
                        SqlCommand deleteInventoryCmd = new SqlCommand(deleteInventoryQuery, conn, transaction);
                        deleteInventoryCmd.Parameters.AddWithValue("@ID", inventoryId);
                        deleteInventoryCmd.ExecuteNonQuery();

                        transaction.Commit();
                        Console.WriteLine("Inventory and dependent repairs deleted successfully.");
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("An error occurred while deleting the inventory and dependent repairs: " + ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while deleting the inventory: {ex.Message}");
            }
        }
    }
}
