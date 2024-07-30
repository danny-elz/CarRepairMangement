using CarRepairManagement.DataAccess;
using CarRepairManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CarRepairManagement.Services
{
    public static class RepairService
    {
        public static List<Repair> GetAllRepairs()
        {
            List<Repair> repairList = new List<Repair>();
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    string query = "SELECT * FROM Repair";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        repairList.Add(new Repair
                        {
                            ID = (int)reader["ID"],
                            InventoryID = (int)reader["InventoryID"],
                            WhatToRepair = reader["WhatToRepair"].ToString()
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while fetching repairs: {ex.Message}");
            }
            return repairList;
        }

        public static void AddRepair(Repair repair)
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    string query = "INSERT INTO Repair (InventoryID, WhatToRepair) VALUES (@InventoryID, @WhatToRepair)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@InventoryID", repair.InventoryID);
                    cmd.Parameters.AddWithValue("@WhatToRepair", repair.WhatToRepair);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while adding the repair: {ex.Message}");
            }
        }

        public static void UpdateRepair(Repair repair)
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    string query = "UPDATE Repair SET InventoryID = @InventoryID, WhatToRepair = @WhatToRepair WHERE ID = @ID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@InventoryID", repair.InventoryID);
                    cmd.Parameters.AddWithValue("@WhatToRepair", repair.WhatToRepair);
                    cmd.Parameters.AddWithValue("@ID", repair.ID);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while updating the repair: {ex.Message}");
            }
        }

        public static void DeleteRepair(int repairId)
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    string query = "DELETE FROM Repair WHERE ID = @ID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ID", repairId);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while deleting the repair: {ex.Message}");
            }
        }
    }
}
