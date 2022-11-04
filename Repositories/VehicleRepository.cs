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

        public void AddVehicle(Vehicles vehicle, int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand()) //primary query for Vehicles Table
                {
                    cmd.CommandText = @"
                    INSERT INTO Vehicles(VehicleYear, VehicleMake, VehicleModel, BodyStyleId) 
                    OUTPUT INSERTED.ID
                    VALUES (@VehicleYear, @VehicleMake, @VehicleModel, @BodyStyleId)
                    ";

                    DbUtils.AddParameter(cmd, "@VehicleYear", vehicle.VehicleYear);
                    DbUtils.AddParameter(cmd, "@VehicleMake", vehicle.VehicleMake);
                    DbUtils.AddParameter(cmd, "@VehicleModel", vehicle.VehicleModel);
                    DbUtils.AddParameter(cmd, "@BodyStyleId", vehicle.BodyStyleId);



                    vehicle.Id = (int)cmd.ExecuteScalar();
                }
                using (var cmd = conn.CreateCommand()) //secondary query for UserVehicles table
                {
                    cmd.CommandText = @"
                    INSERT INTO UserVehicles(VehicleId,VehicleMiles, VehicleCost, IsVehicleAvailable, UserId) 
                    VALUES (@VehicleId, @VehicleMiles, @VehicleCost, @IsVehicleAvailable, @UserId)";

                    DbUtils.AddParameter(cmd, "@VehicleId", vehicle.Id);
                    DbUtils.AddParameter(cmd, "@VehicleMiles", vehicle.UserVehicles.VehicleMiles);
                    DbUtils.AddParameter(cmd, "@VehicleCost", vehicle.UserVehicles.VehicleCost);
                    DbUtils.AddParameter(cmd, "@IsVehicleAvailable", 0);
                    DbUtils.AddParameter(cmd, "@UserId", id);

                    cmd.ExecuteNonQuery();
                }


            }
        }


        public void EditVehicle(Vehicles vehicle)
        {
            using (var conn = Connection)
            {
                conn.Open();


                using (var cmd = conn.CreateCommand()) //primary query for Vehicles Table
                {
                    cmd.CommandText = @"
                    UPDATE Vehicles
                    SET VehicleYear = @VehicleYear, VehicleMake = @VehicleMake, VehicleModel = @VehicleModel, BodyStyleId = @BodyStyleId
                    WHERE Vehicles.Id = @vid
                    ";

                    DbUtils.AddParameter(cmd, "@VehicleYear", vehicle.VehicleYear);
                    DbUtils.AddParameter(cmd, "@VehicleMake", vehicle.VehicleMake);
                    DbUtils.AddParameter(cmd, "@VehicleModel", vehicle.VehicleModel);
                    DbUtils.AddParameter(cmd, "@BodyStyleId", vehicle.BodyStyleId);
                    DbUtils.AddParameter(cmd, "@vid", vehicle.Id);



                    cmd.ExecuteScalar();
                }
                using (var cmd = conn.CreateCommand()) //secondary query for UserVehicles table
                {
                    cmd.CommandText = @"
                    UPDATE UserVehicles 
                    SET VehicleMiles = @VehicleMiles, VehicleCost = @VehicleCost 
                    WHERE UserVehicles.Id = @uvid
                    ";

                    DbUtils.AddParameter(cmd, "@VehicleMiles", vehicle.UserVehicles.VehicleMiles);
                    DbUtils.AddParameter(cmd, "@VehicleCost", vehicle.UserVehicles.VehicleCost);
                    DbUtils.AddParameter(cmd, "@uvid", vehicle.UserVehicles.Id);

                    cmd.ExecuteScalar();

                }


            }
        }

        public Vehicles GetVehicleById(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                    SELECT v.Id, v.VehicleMake, v.VehicleModel, v.VehicleYear, uv.Id as uvid, uv.VehicleMiles, uv.VehicleCost, bs.BodyStyleName, uv.UserId, v.BodyStyleId from Vehicles v
                    JOIN UserVehicles uv
                    ON v.Id = uv.VehicleId
                    JOIN BodyStyle bs
                    ON v.BodyStyleId = bs.Id
                    WHERE v.Id = @id
                    ";

                    DbUtils.AddParameter(cmd, "@id", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
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
                                Id = reader.GetInt32(reader.GetOrdinal("uvid")),
                                VehicleCost = (float)reader.GetDouble(reader.GetOrdinal("VehicleCost"))

                            };
                            BodyStyle bodyStyle = new BodyStyle
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("BodyStyleId")),
                                BodyStyleName = reader.GetString(reader.GetOrdinal("BodyStyleName"))
                            };
                            vehicle.BodyStyle = bodyStyle;
                            vehicle.UserVehicles = userVehicle;

                            return vehicle;
                        }
                        else { return null; }
                    }
                }
            }
        }

        public void DeleteVehicle(int id)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                    DELETE FROM UserVehicles WHERE VehicleId = @vid
                    ";
                    cmd.Parameters.AddWithValue("@vid", id);
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = @"
                    DELETE FROM Vehicles WHERE Id = @id
                    ";
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }

            }
        }
    }
}
                        



