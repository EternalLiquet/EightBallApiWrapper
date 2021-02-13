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
            HttpResponseMessage response = httpClient.GetAsync($"https://8ball.delegator.com/magic/JSON/{HttpUtility.HtmlEncode(question)}").Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Something has gone wrong, the API might be down. Please check at: https://8ball.delegator.com/");
            }
            else
            {
                return new EightBallAnswer(JsonConvert.DeserializeObject<EightBallResponse>(response.Content.ReadAsStringAsync().Result));
            }
        }
    }

    public class EightBallResponse
    {
        public magic magic { get; set; }
    }

    public class magic
    {
        public string question { get; set; }
        public string answer { get; set; }
        public string type { get; set; }
    }
}
