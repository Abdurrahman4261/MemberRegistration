using MemberRegistration.DataAccessLayer.Concrete;
using MemberRegistration.EntityLayer.Concrete;
using MemberRegistration.EntityLayer.Model;
using MemberRegistration.PresentationLayer.Filter;
using MemberRegistration.PresentationLayer.Managers;
using MemberRegistration.PresentationLayer.Models;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace MemberRegistration.PresentationLayer.Controllers
{
    [UserFilter]
    public class AdminController : Controller
    {
        MemberContext _memberContext;
        public AdminController(MemberContext memberContext)
        {
            _memberContext = memberContext;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult UserInfo()
        {
            MemberManager memberManager = new MemberManager(_memberContext);
            var infos = _memberContext.AllUserInfos.FirstOrDefault(i=>i.AllUserInfosId==1);
            infos = memberManager.GetUsersInfos(infos);
            _memberContext.AllUserInfos.Update(infos);
            _memberContext.SaveChanges();
            return View(infos);
        }
        [HttpPost]
        public IActionResult UserInfo(AllUserInfos infos)
        {

            MemberManager memberManager = new MemberManager(_memberContext);
            var info = _memberContext.AllUserInfos.FirstOrDefault();
            memberManager.SetUsersTopicality();
            memberManager.GetUsersInfos(info);
            infos = info;
            return View(infos);
        }
        public IActionResult Answer()
        {
            return View();
        }
        [HttpPost]
        public List<List<object>> AnswerChart()
        {
            MemberManager memberManager = new MemberManager(_memberContext);
            var numberOfAnswers = new List<List<AnswerChart>>();

            numberOfAnswers = memberManager.NumberOfAnswersChart(numberOfAnswers);
            
            List<List<object>> data = new List<List<object>>();
            foreach (var item in numberOfAnswers)
            {
                var sortedAnswers = item.OrderByDescending(a=>a.rate).ToList();
                var list = new List<object>();
                List<string> labels = sortedAnswers.Select(n=>n.text).ToList();
                List<int> rates = sortedAnswers.Select(n => n.rate).ToList();
                list.Add(labels);
                list.Add(rates);
                data.Add(list);
            }
            return data;
        }
    }
}
