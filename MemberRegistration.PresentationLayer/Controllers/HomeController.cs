using MemberRegistration.DataAccessLayer.Concrete;
using MemberRegistration.EntityLayer.Concrete;
using MemberRegistration.PresentationLayer.Filter;
using MemberRegistration.PresentationLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MemberRegistration.PresentationLayer.Controllers
{
    [UserFilter]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        MemberContext _memberContext;
        public HomeController(MemberContext memberContext)
        {
            _memberContext = memberContext;
        }
        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult ProfileInfo()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ProfileInfo(User user)
        {
            
            User profilınfo = _memberContext.Users.FirstOrDefault(u => u.UserId==user.UserId);
            if (!ModelState.IsValid)
            {
                var messages = ModelState.ToList();
                return View(user);
            }

            else if (user != null) {

                HttpContext.Session.SetString("fullname", user.Name + " " + user.Surname);
                HttpContext.Session.SetString("username", user.UserName);
                HttpContext.Session.SetString("email", user.Email);
                HttpContext.Session.SetString("password", user.Password);
                HttpContext.Session.SetString("name", user.Name);
                HttpContext.Session.SetString("surname", user.Surname);

                profilınfo.Name = HttpContext.Session.GetString("name");
                profilınfo.Surname = HttpContext.Session.GetString("surname");
                profilınfo.Email = HttpContext.Session.GetString("email");
                profilınfo.UserName = HttpContext.Session.GetString("username");
                profilınfo.Password = HttpContext.Session.GetString("password");

               
                _memberContext.SaveChanges();

                return Redirect("/Home/ProfileInfo");
            }
            return View(user);

        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
