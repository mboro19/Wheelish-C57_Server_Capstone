using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using Wheelish.Models;
using Wheelish.Utils;

namespace Wheelish.Repositories
{

        public class UserProfileRepository : BaseRepository, IUserProfileRepository
        {
            public UserProfileRepository(IConfiguration config) : base(config) { }

        public List<UserProfile> GetAllUsers()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                    SELECT UserName, UserAddress, UserCity, UserState, UserZip, UserPhone, UserEmail  
                    FROM UserProfile  
                    ORDER BY DisplayName ASC
                ";
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<UserProfile> users = new List<UserProfile>();

                        while (reader.Read())
                        {
                            UserProfile user = new UserProfile
                            {
                                UserName = reader.GetString(reader.GetOrdinal("UserName")),
                                UserAddress = reader.GetString(reader.GetOrdinal("UserAddress")),
                                UserCity = reader.GetString(reader.GetOrdinal("UserCity")),
                                UserState = reader.GetString(reader.GetOrdinal("UserState")),
                                UserZip = reader.GetInt32(reader.GetOrdinal("UserZip")),
                                UserPhone = reader.GetString(reader.GetOrdinal("UserPhone")),
                                UserEmail = reader.GetString(reader.GetOrdinal("UserEmail"))

                            };
                            users.Add(user);
                        }
                        return users;
                    }
                }
            }
        }

        public UserProfile GetByFirebaseUserId(string firebaseUserId)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                      SELECT userName, userAddress, userCity, userState, userZip, userPhone, userEmail, id 
                      FROM UserProfile  
                      WHERE FirebaseUserId = @FirebaseuserId";

                    DbUtils.AddParameter(cmd, "@FirebaseUserId", firebaseUserId);

                    UserProfile userProfile = null;

                    var reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        userProfile = new UserProfile()
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("id")),
                            UserName = reader.GetString(reader.GetOrdinal("userName")),
                            UserAddress = reader.GetString(reader.GetOrdinal("userAddress")),
                            UserCity = reader.GetString(reader.GetOrdinal("userCity")),
                            UserState = reader.GetString(reader.GetOrdinal("userState")),
                            UserZip = reader.GetInt32(reader.GetOrdinal("userZip")),
                            UserPhone = reader.GetString(reader.GetOrdinal("userPhone")),
                            UserEmail = reader.GetString(reader.GetOrdinal("userEmail"))
                        };
                    }
                    reader.Close();

                    return userProfile;
                }
            }
        }

        public void Add(UserProfile userProfile)
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                    INSERT INTO UserProfile (UserName, UserAddress, UserCity, UserState, UserZip, UserPhone, UserEmail, FirebaseUserId)
                    OUTPUT INSERTED.ID
                    VALUES (@UserName, @UserAddress, @UserCity, @UserState, @UserZip, @UserPhone, @UserEmail, @FirebaseUserId)";

                    DbUtils.AddParameter(cmd, "@UserName", userProfile.UserName);
                    DbUtils.AddParameter(cmd, "@UserAddress", userProfile.UserAddress);
                    DbUtils.AddParameter(cmd, "@UserCity", userProfile.UserCity);
                    DbUtils.AddParameter(cmd, "@UserState", userProfile.UserState);
                    DbUtils.AddParameter(cmd, "@UserZip", userProfile.UserZip);
                    DbUtils.AddParameter(cmd, "@UserPhone", userProfile.UserPhone);
                    DbUtils.AddParameter(cmd, "@UserEmail", userProfile.UserEmail);
                    DbUtils.AddParameter(cmd, "@FirebaseUserId", userProfile.FirebaseUserId);

                    userProfile.Id = (int)cmd.ExecuteScalar();
                }
            }
        }
        public UserProfile GetVehicleDealerByVehicleId(int id) //see getvehiclebyid above
        {
            using (var conn = Connection)
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                    select up.UserName, up.UserAddress, up.UserCity, up.UserState, up.UserPhone, up.UserEmail 
                    from UserProfile up
                    join UserVehicles uv
                    on uv.UserId = up.Id
                    join Vehicles v
                    on uv.VehicleId = v.Id
                    where up.id = @id
                    ";

                    DbUtils.AddParameter(cmd, "@id", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            //Vehicles vehicle = new Vehicles
                            //{
                            //    Id = reader.GetInt32(reader.GetOrdinal("Id")),

                            //};
                            //UserVehicles userVehicle = new UserVehicles
                            //{
                            //    UserId = reader.GetInt32(reader.GetOrdinal("UserId")),
                            //    VehicleId = reader.GetInt32(reader.GetOrdinal("VehicleId"))
                            //};

                            UserProfile userProfile = new UserProfile
                            {
                                UserName = reader.GetString(reader.GetOrdinal("UserName")),
                                UserAddress = reader.GetString(reader.GetOrdinal("UserAddress")),
                                UserCity = reader.GetString(reader.GetOrdinal("UserCity")),
                                UserState = reader.GetString(reader.GetOrdinal("UserState")),
                                UserPhone = reader.GetString(reader.GetOrdinal("UserPhone")),
                                UserEmail = reader.GetString(reader.GetOrdinal("UserEmail"))
                            };
                            //vehicle.UserVehicles = userVehicle;

                            return userProfile;
                        }
                        else { return null; }
                    }
                }
            }
        }
    }
    
}
