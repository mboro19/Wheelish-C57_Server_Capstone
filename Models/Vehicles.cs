using System;
using Wheelish.Models;

namespace Wheelish.Models
{
    public class Vehicles
    {
        public int Id { get; set; }
        public string VehicleMake { get; set; }
        public string VehicleModel { get; set; }
        public int VehicleYear { get; set; }
        public int BodyStyleId { get; set; }

        public UserVehicles UserVehicles { get; set; }
        public BodyStyle BodyStyle { get; set; }

    }
}
