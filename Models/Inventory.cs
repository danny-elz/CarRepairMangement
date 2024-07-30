namespace CarRepairManagement.Models
{
    public class Inventory
    {
        public int ID { get; set; }
        public int VehicleID { get; set; }
        public int NumberOnHand { get; set; }
        public decimal Price { get; set; }
        public decimal Cost { get; set; }
    }
}
