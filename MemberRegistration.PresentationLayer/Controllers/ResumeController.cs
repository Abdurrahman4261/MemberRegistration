using MemberRegistration.DataAccessLayer.Concrete;
using MemberRegistration.EntityLayer.Concrete;
using MemberRegistration.PresentationLayer.Filter;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MemberRegistration.PresentationLayer.Controllers
{
    [UserFilter]
    public class ResumeController : Controller
    {
        MemberContext _memberContext;
        public ResumeController(MemberContext memberContext)
        {
            _memberContext = memberContext;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(IFormFile file)
        {
            User user = _memberContext.Users.FirstOrDefault(u => u.UserId==HttpContext.Session.GetInt32("id"));
            Resume? oldresume = _memberContext.Resumes.FirstOrDefault(u => u.UserId==user.UserId);
            if(oldresume == null) 
            {
                oldresume = new Resume();
            }
            if (file != null)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Resumes", file.FileName);
                oldresume.Name = file.FileName;
                oldresume.Path = "wwwroot/Resumes";
                oldresume.UserId = (int)HttpContext.Session.GetInt32("id");
                oldresume.File = file;
                // user.Cv= resume;
                using (var stream = new FileStream(path,FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }
            else if (!ModelState.IsValid)
            {
                var messages = ModelState.ToList();
                return View();
            }
            _memberContext.Update(oldresume);
            
            await _memberContext.SaveChangesAsync();
            return View();
        }
    }
}


//public async Task<IActionResult> Index(IFormFile file)
//{
//    User user = _memberContext.Users.FirstOrDefault(u => u.UserId == HttpContext.Session.GetInt32("id"));
//    Resume? oldresume = _memberContext.Resumes.FirstOrDefault(u => u.UserId == user.UserId);
//    if (oldresume == null)
//    {
//        // aşağıdaki kodları buna alacan eğer null değilse update yaparsın



//        var resume = new Resume();
//        if (file != null)
//        {
//            //var extent = Path.GetExtension(file.FileName);
//            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Resumes", file.FileName);
//            resume.Name = file.FileName;
//            resume.Path = "wwwroot/Resumes";
//            resume.UserId = (int)HttpContext.Session.GetInt32("id");
//            resume.File = file;
//            // user.Cv= resume;

//            //.user = _memberContext.Users.FirstOrDefault(u=>u.UserId==resume.Id);
//            using (var stream = new FileStream(path, FileMode.Create))
//            {
//                await file.CopyToAsync(stream);
//            }
//        }
//        else if (!ModelState.IsValid)
//        {
//            var messages = ModelState.ToList();
//            return View();
//        }

//        await _memberContext.AddAsync(resume);
//        await _memberContext.SaveChangesAsync();
//    }
//    else
//    {

//    }
//    return View();
//}

//var a = _memberContext.Entry<User>(user);
//a.State = EntityState.Modified;
//_memberContext.Update(user);


//await _memberContext.AddAsync(resume);
//var cv = await _memberContext.Resumes.FindAsync(HttpContext.Session.GetInt32("resumeid"));
//await _memberContext.SaveChangesAsync();
//return View(cv);


//if (user.Cv != null)
//{
//    _memberContext.Resumes.Remove(user.Cv);
//}