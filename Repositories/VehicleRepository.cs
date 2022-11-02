using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using Wheelish.Models;
using Wheelish.Utils;
using System;

namespace Wheelish.Repositories
{
    public class VehicleRepository : BaseRepository, IVehicleRepository
    {
        public VehicleRepository(IConfiguration config) : base(config) { }

        public List<Vehicles> GetAllVehicles()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                    SELECT v.Id, v.VehicleMake, v.VehicleModel, v.VehicleYear, uv.VehicleMiles, uv.VehicleCost, bs.BodyStyleName, uv.UserId, v.BodyStyleId from Vehicles v
                    JOIN UserVehicles uv
                    ON v.Id = uv.VehicleId
                    JOIN BodyStyle bs
                    ON v.BodyStyleId = bs.Id
                ";
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<Vehicles> allVehicles = new List<Vehicles>();

                        while (reader.Read())
                        {

                            Vehicles vehicle = new Vehicles
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                VehicleMake = reader.GetString(reader.GetOrdinal("VehicleMake")),
                                VehicleModel = reader.GetString(reader.GetOrdinal("VehicleModel")),
                                VehicleYear = reader.GetInt32(reader.GetOrdinal("VehicleYear")),
                                BodyStyleId = reader.GetInt32(reader.GetOrdinal("BodyStyleId"))

                            };
                            UserVehicles userVehicle = new UserVehicles
                            {
                                VehicleMiles = reader.GetInt32(reader.GetOrdinal("VehicleMiles")),
                                VehicleCost = (float)reader.GetDouble(reader.GetOrdinal("VehicleCost"))

                            };
                            BodyStyle bodyStyle = new BodyStyle
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("BodyStyleId")),
                                BodyStyleName = reader.GetString(reader.GetOrdinal("BodyStyleName"))
                            };
                            vehicle.BodyStyle = bodyStyle;
                            vehicle.UserVehicles = userVehicle;
                            allVehicles.Add(vehicle);


                        }
                        return allVehicles;
                    }
                }
            }
        }


        public List<Vehicles> GetAllUserVehicles(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                    SELECT v.Id, v.VehicleMake, v.VehicleModel, v.VehicleYear, uv.VehicleMiles, uv.VehicleCost, bs.BodyStyleName, uv.UserId, v.BodyStyleId from Vehicles v
                    JOIN UserVehicles uv
                    ON v.Id = uv.VehicleId
                    JOIN BodyStyle bs
                    ON v.BodyStyleId = bs.Id
                    WHERE UserId = @userId
                ";
                    DbUtils.AddParameter(cmd, "@userId", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<Vehicles> vehicles = new List<Vehicles>();

                        while (reader.Read())
                        {
                            Vehicles vehicle = new Vehicles
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                VehicleMake = reader.GetString(reader.GetOrdinal("VehicleMake")),
                                VehicleModel = reader.GetString(reader.GetOrdinal("VehicleModel")),
                                VehicleYear = reader.GetInt32(reader.GetOrdinal("VehicleYear")),
                                BodyStyleId = reader.GetInt32(reader.GetOrdinal("BodyStyleId"))
                            };
                            UserVehicles userVehicle = new UserVehicles
                            {
                                VehicleMiles = reader.GetInt32(reader.GetOrdinal("VehicleMiles")),
                                VehicleCost = (float)reader.GetDouble(reader.GetOrdinal("VehicleCost"))

                            };
                            BodyStyle bodyStyle = new BodyStyle
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("BodyStyleId")),
                                BodyStyleName = reader.GetString(reader.GetOrdinal("BodyStyleName"))
                            };
                            vehicle.BodyStyle = bodyStyle;
                            vehicle.UserVehicles = userVehicle;
                            vehicles.Add(vehicle);

                        }

                        return vehicles;
                    }
                }
            }
        }

        public void AddVehicle(Vehicles vehicle)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                    INSERT INTO Vehicle(VehicleYear, VehicleMake, VehicleModel, BodyStyleId) 
                    VALUES (@vehicleYear, @vehicleMake, @vehicleModel, @bodyStyleId)
                    INSERT INTO UserVehicles(VehicleMiles, VehicleCost, UserId) 
                    VALUES (@vehicleMiles, @vehicleCost)
                    ";
                    
                    //DbUtils.AddParameter(cmd, "@userId", );
                    DbUtils.AddParameter(cmd, "@vehicleYear", vehicle.VehicleYear);
                    DbUtils.AddParameter(cmd, "@vehicleMake", vehicle.VehicleMake);
                    DbUtils.AddParameter(cmd, "@vehicleModel", vehicle.VehicleModel);
                    DbUtils.AddParameter(cmd, "@bodyStyleId", vehicle.BodyStyleId);
                    DbUtils.AddParameter(cmd, "@vehicleMiles", vehicle.UserVehicles.VehicleMiles);
                    DbUtils.AddParameter(cmd, "@vehicleCost", vehicle.UserVehicles.VehicleCost);




                    vehicle.Id = (int)cmd.ExecuteScalar();
                    vehicle.Id = vehicle.UserVehicles.VehicleId;
                    vehicle.UserVehicles.Id = (int)cmd.ExecuteScalar();
                }
            }
        }
    }
}
