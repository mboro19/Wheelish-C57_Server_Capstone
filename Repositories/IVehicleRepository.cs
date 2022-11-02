using System.Collections.Generic;
using Wheelish.Models;

namespace Wheelish.Repositories
{
    public interface IVehicleRepository
    {
        void AddVehicle(Vehicles vehicles);

        public List<Vehicles> GetAllUserVehicles(int id);

        public List<Vehicles> GetAllVehicles();
    }
}
