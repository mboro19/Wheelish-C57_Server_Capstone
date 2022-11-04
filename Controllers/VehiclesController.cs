using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wheelish.Repositories;
using System;
using Wheelish.Models;
using System.Security.Claims;
using System.Collections.Generic;

namespace Wheelish.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IUserProfileRepository _userProfileRepository;

        public VehiclesController(IVehicleRepository vehicleRepository, IUserProfileRepository userProfileRepository)
        {
            _vehicleRepository = vehicleRepository;
            _userProfileRepository = userProfileRepository;
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAllVehicles()
        {
            List<Vehicles> allVehicles = _vehicleRepository.GetAllVehicles();
            return Ok(allVehicles);
        }

        [HttpGet]
        
        public IActionResult Get()
        {
            var currentUser = GetCurrentUserProfile();
            List<Vehicles> vehicles = _vehicleRepository.GetAllUserVehicles(currentUser.Id);
            return Ok(vehicles);
        }

        [Authorize]
        [HttpPost]
        public IActionResult AddVehicle(Vehicles vehicle)
        {
            var currentUser = GetCurrentUserProfile();
            _vehicleRepository.AddVehicle(vehicle, currentUser.Id);

            return Ok();

            
        }
        [HttpGet]
        [Route("getVehicleById/{id}")]
        public IActionResult GetVehicleById(int id)
        {
            var vehicleById = _vehicleRepository.GetVehicleById(id);

                return Ok(vehicleById);
        }

        [Authorize]
        [HttpPut]
        [Route("EditVehicle")]
        public IActionResult EditVehicle(Vehicles vehicle)
        {

            _vehicleRepository.EditVehicle(vehicle);
            return Ok();
        }

        [Authorize]
        [HttpDelete]
        [Route("DeleteVehicle/{id}")]
        public IActionResult DeleteVehicle(int id)
        {
            _vehicleRepository.DeleteVehicle(id);
            return NoContent();
        }

        private UserProfile GetCurrentUserProfile()
        {
            var firebaseUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return _userProfileRepository.GetByFirebaseUserId(firebaseUserId);
        }
    }
}
