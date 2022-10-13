using Microsoft.AspNetCore.Mvc;
using OA.Data;
using OA.Repository;
using OA.Service;
using Onion_Architecture.Models;
using Microsoft.AspNetCore.Http;
using System.Runtime.Serialization;

namespace Onion_Architecture.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService userService;

        private readonly IUserInfoService userInfoService;

        public UserController(IUserService userService, IUserInfoService userInfoService)
        {
            this.userService = userService;
            this.userInfoService = userInfoService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<UserViewModel> model = new List<UserViewModel>();

            userService.GetAllUser().ToList().ForEach(u =>
            {
                UserInfo userInfo = userInfoService.GetUserInfo(u.Id);
                UserViewModel user = new UserViewModel
                {
                    Id = u.Id,
                    Name = $"{userInfo.FirstName} {userInfo.LastName}",
                    Email = u.Email,
                    Address = userInfo.Address
                };
                model.Add(user);
            });
            return View(model);
        }

        [HttpGet]
        public IActionResult AddUser()
        {
            UserViewModel model = new UserViewModel();
            return View("AddUser", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddUser(UserViewModel model)
        {
                User user = new User
                {
                    UserName = model.UserName,
                    Password = model.Password,
                    Email = model.Email,
                    AddedDate = DateTime.UtcNow,
                    ModifiedDate = DateTime.UtcNow,
                    IPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString(),
                    UserInfo = new UserInfo
                    {
                        Address = model.Address,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        AddedDate = DateTime.UtcNow,
                        ModifiedDate = DateTime.UtcNow,
                        IPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString()
                    }
                };
                userService.InsertUser(user);
                if (user.Id > 0)
                {
                    return RedirectToAction("Index");
                }
            return View(model);
        }
    }
}
