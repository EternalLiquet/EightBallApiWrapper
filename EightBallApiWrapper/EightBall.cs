using Newtonsoft.Json;

using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace EightBallApiWrapper
{
    public class EightBall
    {
        private static HttpClient httpClient;

        public EightBall()
        {
            httpClient = new HttpClient();
        }

        private EightBallResponse[] responses = new EightBallResponse[]
        {
            new EightBallResponse(new magic("Cannot predict now", "Neutral")),
            new EightBallResponse(new magic("As I see it, yes", "Affirmative")),
            new EightBallResponse(new magic("Without a doubt", "Affirmative")),
            new EightBallResponse(new magic("Yes", "Affirmative")),
            new EightBallResponse(new magic("Very doubtful", "Contrary")),
            new EightBallResponse(new magic("Reply hazy, try again", "Neutral")),
            new EightBallResponse(new magic("Ask again later", "Neutral")),
            new EightBallResponse(new magic("Concentrate and ask again", "Neutral")),
            new EightBallResponse(new magic("My sources say no", "Contrary")),
            new EightBallResponse(new magic("Outlook not so good", "Contrary")),
            new EightBallResponse(new magic("Very doubtful", "Contrary")),
            new EightBallResponse(new magic("Outlook good", "Affirmative"))
        };

        public async Task<EightBallAnswer> AskQuestionAsync(string question)
        {
            if (String.IsNullOrEmpty(question)) throw new Exception("Please ask a question");
            HttpResponseMessage response = await httpClient.GetAsync($"https://8ball.delegator.com/magic/JSON/{HttpUtility.HtmlEncode(question)}");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Something has gone wrong, the API might be down. Please check at: https://8ball.delegator.com/");
            }
            else
            {
                return new EightBallAnswer(JsonConvert.DeserializeObject<EightBallResponse>(await response.Content.ReadAsStringAsync()));
            }
        }

        public EightBallAnswer AskQuestion(string question)
        {
            if (String.IsNullOrEmpty(question)) throw new Exception("Please ask a question");
            Random random = new Random();
            EightBallResponse response = responses[random.Next(0, responses.Length)];
            if (question.EndsWith('?'))
                response.magic.question = question.Remove(question.Length - 1, 1);
            else
                response.magic.question = question;
            return new EightBallAnswer(response);
        }
    }

    public class EightBallResponse
    {
        public magic magic { get; set; }

        public EightBallResponse(magic mag)
        {
            magic = mag;
        }
    }

    public class magic
    {
        public string question { get; set; }
        public string answer { get; set; }
        public string type { get; set; }

        public magic(string answer, string type)
        {
            this.answer = answer;
            this.type = type;
        }
    }
}
