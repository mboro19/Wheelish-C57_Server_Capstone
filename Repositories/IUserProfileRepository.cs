using System.Collections.Generic;
using Wheelish.Models;

namespace Wheelish.Repositories
{
    public interface IUserProfileRepository
    {
        UserProfile GetByEmail(string email);

        List<UserProfile> GetAllUsers();

        UserProfile GetUserById(int id);

        int CreateUser(UserProfile userProfile);
    }
}
