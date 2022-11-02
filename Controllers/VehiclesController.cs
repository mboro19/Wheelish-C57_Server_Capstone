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

        [HttpPost]

        public IActionResult AddVehicle(Vehicles vehicle)
        {
            _vehicleRepository.AddVehicle(vehicle);

            return Ok();

            
        }


        private UserProfile GetCurrentUserProfile()
        {
            var firebaseUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return _userProfileRepository.GetByFirebaseUserId(firebaseUserId);
        }

        // // GET: VehicleController/Details/5
        // public ActionResult Details(int id)
        // {
        //     return View();
        // }

        // // GET: VehicleController/Create
        // public ActionResult Create()
        // {
        //     return View();
        // }

        // // POST: VehicleController/Create
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public ActionResult Create(IFormCollection collection)
        // {
        //     try
        //     {
        //         return RedirectToAction(nameof(Index));
        //     }
        //     catch
        //     {
        //         return View();
        //     }
        // }

        // // GET: VehicleController/Edit/5
        // public ActionResult Edit(int id)
        // {
        //     return View();
        // }

        // // POST: VehicleController/Edit/5
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public ActionResult Edit(int id, IFormCollection collection)
        // {
        //     try
        //     {
        //         return RedirectToAction(nameof(Index));
        //     }
        //     catch
        //     {
        //         return View();
        //     }
        // }

        // // GET: VehicleController/Delete/5
        // public ActionResult Delete(int id)
        // {
        //     return View();
        // }

        // // POST: VehicleController/Delete/5
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public ActionResult Delete(int id, IFormCollection collection)
        // {
        //     try
        //     {
        //         return RedirectToAction(nameof(Index));
        //     }
        //     catch
        //     {
        //         return View();
        //     }
        // }
    }
}
