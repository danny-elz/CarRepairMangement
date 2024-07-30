using CarRepairManagement.DataAccess;
using CarRepairManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CarRepairManagement.Services
{
    public static class VehicleService
    {
        public static List<Vehicle> GetAllVehicles()
        {
            List<Vehicle> vehicles = new List<Vehicle>();
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    string query = "SELECT * FROM Vehicle";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        vehicles.Add(new Vehicle
                        {
                            ID = (int)reader["ID"],
                            Make = reader["Make"].ToString(),
                            Model = reader["Model"].ToString(),
                            Year = (int)reader["Year"],
                            NewOrUsed = reader["NewOrUsed"].ToString()
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while fetching vehicles: {ex.Message}");
            }
            return vehicles;
        }

        public static void AddVehicle(Vehicle vehicle)
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    string query = "INSERT INTO Vehicle (Make, Model, Year, NewOrUsed) VALUES (@Make, @Model, @Year, @NewOrUsed)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Make", vehicle.Make);
                    cmd.Parameters.AddWithValue("@Model", vehicle.Model);
                    cmd.Parameters.AddWithValue("@Year", vehicle.Year);
                    cmd.Parameters.AddWithValue("@NewOrUsed", vehicle.NewOrUsed);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while adding the vehicle: {ex.Message}");
            }
        }

        public static void UpdateVehicle(Vehicle vehicle)
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    string query = "UPDATE Vehicle SET Make = @Make, Model = @Model, Year = @Year, NewOrUsed = @NewOrUsed WHERE ID = @ID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Make", vehicle.Make);
                    cmd.Parameters.AddWithValue("@Model", vehicle.Model);
                    cmd.Parameters.AddWithValue("@Year", vehicle.Year);
                    cmd.Parameters.AddWithValue("@NewOrUsed", vehicle.NewOrUsed);
                    cmd.Parameters.AddWithValue("@ID", vehicle.ID);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while updating the vehicle: {ex.Message}");
            }
        }

        public static void DeleteVehicle(int vehicleId)
        {
            try
            {
                using (SqlConnection conn = DatabaseHelper.GetConnection())
                {
                    string query = "DELETE FROM Vehicle WHERE ID = @ID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ID", vehicleId);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while deleting the vehicle: {ex.Message}");
            }
        }
    }
}
