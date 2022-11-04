using System.Collections.Generic;
using Wheelish.Models;

namespace Wheelish.Repositories
{
    public interface IVehicleRepository
    {
        void AddVehicle(Vehicles vehicles, int id);
        void EditVehicle(Vehicles vehicles);

        public List<Vehicles> GetAllUserVehicles(int id);

        public List<Vehicles> GetAllVehicles(); 

        public Vehicles GetVehicleById(int id);

        void DeleteVehicle(int id);
    }
}
