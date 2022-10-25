using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using Wheelish.Models;

namespace Wheelish.Repositories
{

        public class UserProfileRepository : BaseRepository, IUserProfileRepository
        {
            public UserProfileRepository(IConfiguration config) : base(config) { }

            public UserProfile GetByEmail(string email)
            {
                using (var conn = Connection)
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {

                        cmd.CommandText = @"
                       SELECT u.id, u.UserName, u.UserAddress, u.UserCity, u.UserState,
                              u.UserZip, u.UserPhone, u.UserEmail,
                              ut.[Name] AS UserTypeName
                         FROM UserProfile u";

                        cmd.Parameters.AddWithValue("@email", email);

                        UserProfile userProfile = null;
                        var reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            userProfile = new UserProfile()
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                UserName = reader.GetString(reader.GetOrdinal("UserName")),
                                UserAddress = reader.GetString(reader.GetOrdinal("UserAddress")),
                                UserCity = reader.GetString(reader.GetOrdinal("UserCity")),
                                UserState = reader.GetString(reader.GetOrdinal("UserState")),
                                UserZip = reader.GetInt32(reader.GetOrdinal("UserZip")),
                                UserPhone = reader.GetInt32(reader.GetOrdinal("UserPhone")),
                                UserEmail = reader.GetString(reader.GetOrdinal("UserEmail")),
                                
                            };
                        }

                        reader.Close();

                        return userProfile;
                    }
                }
            }

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
                                    UserPhone = reader.GetInt32(reader.GetOrdinal("UserPhone")),
                                    UserEmail = reader.GetString(reader.GetOrdinal("UserEmail"))

                                };




                                users.Add(user);
                            }
                            return users;
                        }
                    }
                }
            }

            public UserProfile GetUserById(int id)
            {
                using (SqlConnection conn = Connection)
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = @"
                        SELECT UserName, UserAddress, UserCity, UserState, UserZip, UserPhone, UserEmail 
                        FROM UserProfile  
                        WHERE UserProfile.Id = @id
                    ";

                        cmd.Parameters.AddWithValue("@id", id);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                UserProfile user = new UserProfile
                                {

                                    UserName = reader.GetString(reader.GetOrdinal("UserName")),
                                    UserAddress = reader.GetString(reader.GetOrdinal("UserAddress")),
                                    UserCity = reader.GetString(reader.GetOrdinal("UserCity")),
                                    UserState = reader.GetString(reader.GetOrdinal("UserState")),
                                    UserZip = reader.GetInt32(reader.GetOrdinal("UserZip")),
                                    UserPhone = reader.GetInt32(reader.GetOrdinal("UserPhone")),
                                    UserEmail = reader.GetString(reader.GetOrdinal("UserEmail"))
                                    


                                };

                                return user;
                            }
                            else
                            {
                                return null;
                            }
                        }
                    }
                }
            }

            public int CreateUser(UserProfile userProfile)
            {
                using (SqlConnection conn = Connection)
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = @"
                    INSERT INTO UserProfile (UserName, UserAddress, UserCity, UserState, UserZip, UserPhone, UserEmail)
                    OUTPUT INSERTED.ID
                    VALUES (@UserName, @UserAddress, @UserCity, @UserState, @UserZip, @UserPhone, @UserEmail)
                    ";

                        cmd.Parameters.AddWithValue("@UserName", userProfile.UserName);
                        cmd.Parameters.AddWithValue("@UserAddress", userProfile.UserAddress);
                        cmd.Parameters.AddWithValue("@UserCity", userProfile.UserCity);
                        cmd.Parameters.AddWithValue("@UserState", userProfile.UserState);
                        cmd.Parameters.AddWithValue("@UserZip", userProfile.UserZip);
                        cmd.Parameters.AddWithValue("@UserPhone", userProfile.UserPhone);
                        cmd.Parameters.AddWithValue("@UserEmail", userProfile.UserEmail);




                        int id = (int)cmd.ExecuteScalar();

                        return id;
                    }
                }
            }
        }
    
}
