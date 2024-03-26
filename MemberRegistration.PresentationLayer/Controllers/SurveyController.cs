using MemberRegistration.DataAccessLayer.AnswerManager;
using MemberRegistration.DataAccessLayer.Concrete;
using MemberRegistration.EntityLayer.Concrete;
using MemberRegistration.PresentationLayer.Filter;
using MemberRegistration.PresentationLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace MemberRegistration.PresentationLayer.Controllers
{
    [UserFilter]
    public class SurveyController : Controller
    {
        private readonly MemberContext _memberContext;
        public SurveyController(MemberContext memberContext) 
        {
            _memberContext = memberContext;
        }

        public IActionResult Index()
        {
            //AnswerModel answerModel = new AnswerModel();
            //MultiSelectList selectList6 = new MultiSelectList(answerModel.AnswerAdd6(), "Key", "Value");
            //MultiSelectList selectList7 = new MultiSelectList(answerModel.AnswerAdd7(), "Key", "Value");
            //ViewBag.Brands = selectList6;
            //ViewBag.Medias = selectList7;
            return View();
        }
        [HttpPost]
        public IActionResult Index(AnswerModel answer)
        {
            answer.UserId = (int)HttpContext.Session.GetInt32("id");
            User user = _memberContext.Users.FirstOrDefault(u => u.UserId == HttpContext.Session.GetInt32("id"));
            Answer? oldanswer = _memberContext.Answers.FirstOrDefault(u => u.UserId == answer.UserId);

            if (oldanswer == null)
            {
                oldanswer = new Answer();
                oldanswer.UserId = user.UserId;
            }
            AnswerManager manager = new AnswerManager(oldanswer);
            manager.AnswerUpdate(answer);

            

            _memberContext.Answers.Update(oldanswer);
            _memberContext.SaveChanges();
            return Redirect("/Home/Index");
        }
    }
}
