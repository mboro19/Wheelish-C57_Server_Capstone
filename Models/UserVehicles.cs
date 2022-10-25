using System.Collections;

namespace Wheelish.Models
{
    public class UserVehicles
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public int UserId { get; set; }
        public int VehicleMiles { get; set; }
        public float VehicleCost { get; set; }
        public bool IsVehicleAvailable { get; set; }

    }
}
