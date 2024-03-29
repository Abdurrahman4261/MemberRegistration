using MemberRegistration.DataAccessLayer.Concrete;
using MemberRegistration.EntityLayer.Concrete;
using MemberRegistration.EntityLayer.Model;
using MemberRegistration.PresentationLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace MemberRegistration.PresentationLayer.Managers
{
    public class MemberManager
    {
        MemberContext _memberContext;
        public MemberManager(MemberContext memberContext)
        {
            _memberContext = memberContext;
        }

        public AllUserInfos GetUsersInfos(AllUserInfos infos)
        {
            infos = new AllUserInfos();

            infos.Topicality = _memberContext.Users.ToList().Where(u => u.Topicality == true).Count();
            infos.NumberOfSurveyAnswers = _memberContext.Answers.Count();
            infos.QuestioOneResponseRate = SetQuestionRate(infos.QuestioOneResponseRate, "select * from answers where answer1 is not null");
            infos.QuestioTwoResponseRate = SetQuestionRate(infos.QuestioTwoResponseRate, "select * from answers where answer2 is not null");
            infos.QuestioThreeResponseRate = SetQuestionRate(infos.QuestioThreeResponseRate, "select * from answers where answer3 is not null");
            infos.QuestioFourResponseRate = SetQuestionRate(infos.QuestioFourResponseRate, "select * from answers where answer4 is not null");
            infos.QuestioFiveResponseRate = SetQuestionRate(infos.QuestioFiveResponseRate, "select * from answers where answer5 is not null");
            infos.QuestioSixResponseRate = SetQuestionRate(infos.QuestioSixResponseRate, "select * from answers where answer6 is not null");
            infos.QuestioSevenResponseRate = SetQuestionRate(infos.QuestioSevenResponseRate, "select * from answers where answer7 is not null");
            infos.QuestioEightResponseRate = SetQuestionRate(infos.QuestioEightResponseRate, "select * from answers where answer8 is not null");
            infos.QuestioNineResponseRate = SetQuestionRate(infos.QuestioNineResponseRate, "select * from answers where answer9 is not null");
            infos.QuestioTenResponseRate = SetQuestionRate(infos.QuestioTenResponseRate, "select * from answers where answer10 is not null");

            return infos;

        }
        public void SetUsersTopicality()
        {
            foreach (var item in _memberContext.Users)
            {
                item.Topicality = false;
            }
            _memberContext.SaveChanges();
        }
        public int SetQuestionRate(int questionrate, string query)
        {

            var alllist = _memberContext.Answers.FromSql($"select * from answers").
                Select(a => a.AnswerId).
                ToList();
            var listcount = alllist.Count;
            var notnulllist = _memberContext.Answers.FromSqlRaw($"{query}").
                Select(a => a.AnswerId).
                ToList();
            questionrate = (notnulllist.Count * 100) / (listcount);
            return questionrate;
        }
        public List<List<string>> FiilList(List<List<string>> answers)
        {
            answers.Add(new List<string> { "erkek", "kadın" });
            answers.Add(new List<string> { "messi", "ronaldo" });
            answers.Add(new List<string> { "yes", "no" });
            answers.Add(new List<string> { "Roses", "Calla Lilies", "Hydrangea", "Tulips" });
            answers.Add(new List<string> { "Tarkan", "Baris Manco", "Taylor Swift", "Billie Eilish" });
            answers.Add(new List<string> { "BMW", "Mercedes", "Volvo", "Lamborghini" });
            answers.Add(new List<string> { "YouTube", "Instagram", "Twitter", "Facebook", "WhatsApp", "TikTok" });
            answers.Add(new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" });
            return answers;
        }
        public List<List<AnswerChart>> NumberOfAnswersChart(List<List<AnswerChart>> numberOfAnswers)
        {
            var answers = new List<List<string>>();
            answers = FiilList(answers);
            int index = 0;

            numberOfAnswers.Add(new List<AnswerChart>());
            foreach (var item in answers[index])
            {

                var list1 = _memberContext.Answers.FromSql($"select * from answers where LOWER (answer1)={item}")
                    .Select(a => new
                    {
                        a.Answer1
                    })
                    .ToList();
                numberOfAnswers[index].Add(new AnswerChart
                {
                    text = item,
                    rate = list1.Count
                });
            }
            numberOfAnswers.Add(new List<AnswerChart>());
            index++;
            foreach (var item in answers[index])
            {
                var list1 = _memberContext.Answers.FromSql($"select * from answers where LOWER (answer2)={item}")
                    .Select(a => new
                    {
                        a.Answer2
                    }).ToList();

                numberOfAnswers[index].Add(new AnswerChart
                {
                    text = item,
                    rate = list1.Count
                });
            }
            numberOfAnswers.Add(new List<AnswerChart>());
            index++;
            foreach (var item in answers[index])
            {
                var list1 = _memberContext.Answers.FromSql($"select * from answers where LOWER (answer3)={item}")
                    .Select(a => new
                    {
                        a.Answer2
                    }).ToList();

                numberOfAnswers[index].Add(new AnswerChart
                {
                    text = item,
                    rate = list1.Count
                });
            }
            numberOfAnswers.Add(new List<AnswerChart>());
            index++;
            foreach (var item in answers[index])
            {
                var list1 = _memberContext.Answers.FromSql($"select * from answers where LOWER (answer4)={item}")
                    .Select(a => new
                    {
                        a.Answer2
                    }).ToList();

                numberOfAnswers[index].Add(new AnswerChart
                {
                    text = item,
                    rate = list1.Count
                });
            }
            numberOfAnswers.Add(new List<AnswerChart>());
            index++;
            foreach (var item in answers[index])
            {
                var list1 = _memberContext.Answers.FromSql($"select * from answers where LOWER (answer5)={item}")
                    .Select(a => new
                    {
                        a.Answer2
                    }).ToList();

                numberOfAnswers[index].Add(new AnswerChart
                {
                    text = item,
                    rate = list1.Count
                });
            }
            numberOfAnswers.Add(new List<AnswerChart>());
            index++;
            foreach (var item in answers[index])
            {
                var list1 = _memberContext.Answers.Where(i=>i.Answer6.Contains(item)).ToList();

                numberOfAnswers[index].Add(new AnswerChart
                {
                    text = item,
                    rate = list1.Count
                });
            }
            numberOfAnswers.Add(new List<AnswerChart>());
            index++;
            foreach (var item in answers[index])
            {
                var list1 = _memberContext.Answers.Where(i => i.Answer7.Contains(item)).ToList();

                numberOfAnswers[index].Add(new AnswerChart
                {
                    text = item,
                    rate = list1.Count
                });
            }
            numberOfAnswers.Add(new List<AnswerChart>());
            index++;
            foreach (var item in answers[index])
            {
                var list1 = _memberContext.Answers.FromSql($"select * from answers where LOWER (answer8)={item}")
                    .Select(a => new
                    {
                        a.Answer2
                    }).ToList();

                numberOfAnswers[index].Add(new AnswerChart
                {
                    text = item,
                    rate = list1.Count
                });
            }
            return numberOfAnswers;
        }

    }
}
