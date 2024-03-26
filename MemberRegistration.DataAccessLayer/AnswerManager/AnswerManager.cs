
using MemberRegistration.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegistration.DataAccessLayer.AnswerManager
{
    public class AnswerManager
    {
        Answer _answer;
        public AnswerManager(Answer answer)
        {
            _answer = answer;
        }
        public void AnswerUpdate(AnswerModel NewAnswer)
        {
            _answer.Answer1 = NewAnswer.Answer1;
            _answer.Answer2 = NewAnswer.Answer2;
            _answer.Answer3 = NewAnswer.Answer3;
            _answer.Answer4 = NewAnswer.Answer4;
            _answer.Answer5 = NewAnswer.Answer5;
            _answer.Answer6 = "";
            
            int len = 0;
            int count = 0;
            foreach (var item in NewAnswer.Answer6)
            {
                if (item != "false")
                {
                    _answer.Answer6 += item + ",";
                    len += item.Length;
                    count++;
                }
            }
            if (count == 0)
            {
                _answer.Answer6 = null;
            }
            else
            {
                _answer.Answer6 = _answer.Answer6.Substring(0, len+count-1);
            }
            
            _answer.Answer7 = null;
            if(NewAnswer.Answer7 != null) {
                _answer.Answer7 = String.Join(",",NewAnswer.Answer7);
            }
            _answer.Answer8 = NewAnswer.Answer8;
            _answer.Answer9 = NewAnswer.Answer9;
            _answer.Answer10 = NewAnswer.Answer10;
        }
    }
}
