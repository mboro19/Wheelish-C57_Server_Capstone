using Microsoft.Extensions.Configuration;
using Wheelish.Models;
using Wheelish.Utils;

namespace Wheelish.Repositories
{
    public class UserVehicleRepository : BaseRepository, IUserVehicleRepository
    {
        public UserVehicleRepository(IConfiguration config) : base(config) { }
        public void Add(UserVehicles vehicles)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                    INSERT INTO (VehicleCost, VehicleMiles, VehicleId, IsVehicleAvailable) from UserVehicles
                    WHERE UserId = CURRENT_USER.Id
                    VALUES (@vehicleCost, @vehicleMiles, @vehicleId, @isVehicleAvailable)";

                    DbUtils.AddParameter(cmd, "@vehicleCost", vehicles.VehicleCost);
                    DbUtils.AddParameter(cmd, "@vehicleMiles", vehicles.VehicleMiles);
                    DbUtils.AddParameter(cmd, "@vehicleId", vehicles.VehicleId);
                    DbUtils.AddParameter(cmd, "@isVehicleAvailable", vehicles.IsVehicleAvailable);


                    vehicles.Id = (int)cmd.ExecuteScalar();
                }
            }
        }
    }
}
