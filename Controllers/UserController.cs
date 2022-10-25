using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using Wheelish.Models;
using Wheelish.Repositories;

namespace Wheelish.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserProfileRepository _userRepo;

        public UserController(IUserProfileRepository userProfileRepository)
        {
            _userRepo = userProfileRepository;
        }

        public IActionResult Index()
        {
            List<UserProfile> users = _userRepo.GetAllUsers();

            return View(users);
        }

        public ActionResult Details(int id)
        {
            UserProfile user = _userRepo.GetUserById(id);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        public ActionResult Create()
        {
            var pro = new UserProfile();
            var UserProfiles = _userRepo.GetAllUsers();
            return View(pro);
        }

        [HttpPost]

        public ActionResult Create(UserProfile userProfile)
        {
            try
            {
                int id = _userRepo.CreateUser(userProfile);

                return RedirectToAction("Details", new { id });
            }
            catch (Exception ex)
            {
                return View(userProfile);
            }
        }

    }
}
