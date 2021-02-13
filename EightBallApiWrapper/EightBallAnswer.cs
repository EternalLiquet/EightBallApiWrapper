using System;
using System.Collections.Generic;
using System.Text;

namespace EightBallApiWrapper
{
    public class EightBallAnswer
    {
        public string Question { get; set; }
        public string Answer { get; set; }
        public string Type { get; set; }

        protected internal EightBallAnswer(EightBallResponse response)
        {
            Question = response.magic.question;
            Answer = response.magic.answer;
            Type = response.magic.answer;
        }
    }
}
