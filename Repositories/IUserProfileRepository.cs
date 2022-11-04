using System.Collections.Generic;
using Wheelish.Models;

namespace Wheelish.Repositories
{
    public interface IUserProfileRepository
    {
        void Add(UserProfile userProfile);
        UserProfile GetByFirebaseUserId(string firebaseUserId);
        List<UserProfile> GetAllUsers();
        public UserProfile GetVehicleDealerByVehicleId(int id);


    }
}
