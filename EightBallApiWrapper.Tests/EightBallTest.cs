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
        public async Task QuestionAskedAsync()
        {
            var answer = await eightBall.AskQuestionAsync("Will I ever find love?");
            Assert.That(answer.magic.answer, Is.Not.Null);
            Assert.That(answer.magic.type, Is.Not.Null);
            Assert.That(answer.magic.question, Is.EqualTo("Will I ever find love"));
        }

        [Test]
        public void BlankQuestionAsync()
        {
            var exception = Assert.ThrowsAsync<Exception>(async () => await eightBall.AskQuestionAsync(""));
            Assert.That(exception.Message, Is.EqualTo("Please ask a question"));
        }

        [Test]
        public void NullQuestionAsync()
        {
            var exception = Assert.ThrowsAsync<Exception>(async () => await eightBall.AskQuestionAsync(null));
            Assert.That(exception.Message, Is.EqualTo("Please ask a question"));
        }

        [Test]
        public void QuestionAsked()
        {
            var answer = eightBall.AskQuestion("Should I make this irresponsible financial purchase?");
            Assert.That(answer.magic.answer, Is.Not.Null);
            Assert.That(answer.magic.type, Is.Not.Null);
            Assert.That(answer.magic.question, Is.EqualTo("Should I make this irresponsible financial purchase"));
        }

        [Test]
        public void BlankQuestion()
        {
            var exception = Assert.Throws<Exception>(() => eightBall.AskQuestion(""));
            Assert.That(exception.Message, Is.EqualTo("Please ask a question"));
        }

        [Test]
        public void NullQuestion()
        {
            var exception = Assert.Throws<Exception>(() => eightBall.AskQuestion(null));
            Assert.That(exception.Message, Is.EqualTo("Please ask a question"));
        }
    }
}