using NUnit.Framework;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace EightBallApiWrapper.Tests
{
    public class Tests
    {
        EightBall eightBall;

        [SetUp]
        public void Setup()
        {
            eightBall = new EightBall();
        }

        [Test]
        public async Task QuestionAsked()
        {
            var answer = await eightBall.AskQuestion("Will I ever find love?");
            Assert.NotNull(answer.magic.answer);
            Assert.NotNull(answer.magic.type);
            Assert.AreEqual("Will I ever find love", answer.magic.question);
        }

        [Test]
        public async Task BlankQuestion()
        {
            var exception = Assert.ThrowsAsync<Exception>(async () => await eightBall.AskQuestion(""));
            Assert.That(exception.Message, Is.EqualTo("Please ask a question"));
        }

        [Test]
        public async Task NullQuestion()
        {
            var exception = Assert.ThrowsAsync<Exception>(async () => await eightBall.AskQuestion(null));
            Assert.That(exception.Message, Is.EqualTo("Please ask a question"));
        }
    }
}