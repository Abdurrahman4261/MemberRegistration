using MemberRegistration.DataAccessLayer.Concrete;
using MemberRegistration.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace MemberRegistration.PresentationLayer.Controllers
{
    public class AccountController : Controller
    {
        public readonly MemberContext _memberContext;
        public AccountController(MemberContext memberContext)
        {
            _memberContext = memberContext;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("id").HasValue)
            {
                return Redirect("/home/index");
            }
            
            return View();
        }
        [HttpPost]
        public IActionResult LoginButtonAction(Login _user)
        {
            
            var user = _memberContext.Users.FirstOrDefault
                (u => u.UserName.Equals (_user.Username) && u.Password.Equals(_user.Password));
           
            if (!ModelState.IsValid)
            {
                var messages = ModelState.ToList();
                return View("index",_user);
            }
            else if (user != null) 
            {
                HttpContext.Session.SetInt32("id", user.UserId);
                HttpContext.Session.SetString("fullname", user.Name+" "+ user.Surname);
                HttpContext.Session.SetString("username", user.UserName);
                HttpContext.Session.SetString("email", user.Email);
                HttpContext.Session.SetString("password", user.Password);
                HttpContext.Session.SetString("name", user.Name);
                HttpContext.Session.SetString("surname", user.Surname);
                if (user.UserRoleId == 2)
                {
                    return Redirect("/home/index");
                }
                else
                {
                    return Redirect("/admin/index");
                }
            }
            else
            {
                ViewData["LoginFlag"] = "Invalid username or password!";
                return View("index", _user);
            }
        }
        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();

            return Redirect("index");
        }
        public IActionResult SignUp()
        {
            if (HttpContext.Session.GetInt32("id").HasValue)
            {
                return Redirect("/home/index");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(User user)
        {
            if (!ModelState.IsValid)
            {
                var messages = ModelState.ToList();
                return View(user);
            }
            
            user.UserRoleId = 2;
            user.RegisterTime = DateTime.Now;
            user.Topicality = true;
            await _memberContext.AddAsync(user);
            await _memberContext.SaveChangesAsync();

            return Redirect("Index");
        }
    }
}
