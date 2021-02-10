# Eight Ball Api Wrapper

![Eight Ball Picture](https://freepngimg.com/thumb/8_ball_pool/26906-7-8-ball-pool-transparent.png)

Don't want to write your own implementation of the 8Ball Delegator API? Want to simply instantiate an object that will do it for you? The 8Ball Delegator Wrapper is here! API Docs found here: https://8ball.delegator.com/

If you found this library particularly useful/helpful please consider supporting me:  
[![ko-fi](https://ko-fi.com/img/githubbutton_sm.svg)](https://ko-fi.com/E1E82Y3GS)

### Usage Example

#### From a synchronous function

```cs
using System;
using EightBallApiWrapper;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            EightBall eightBall = new EightBall();
            var result = eightBall.AskQuestion("Should I make this totally financially irresponsible decision?");
            Console.WriteLine(result.Result.magic.answer);
            //This will be phased out in the future as I make separate async and synchronous functions!
        }
    }
}
```

#### From an asynchronous function

```cs
using System;
using EightBallApiWrapper;

namespace Example
{
    public class CoolClass
    {
        public async void AskEightBallExample
        {
            EightBall eightBall = new EightBall();
            var result = await eightBall.AskQuestion("Should I make this totally financially irresponsible decision?");
            Console.WriteLine(result.magic.answer);
            //This will be phased out in the future as I make separate async and synchronous functions!
        }
    }
}
```

### Result Class Structure:

```javascript
result: (object){
    magic: (object){
        question: string //returns your initial question
        answer: string //returns the answer to your yes/no question
        type: string [ Affirmative, Contrary, Neutral ] //a string that will be either "Affirmative", "Contrary", or "Neutral" that denotes what kind of answer you received.
    }
}
```

### Benefits Of Using This Library:

Boils the process of writing the implementation of the Eight Ball Delegator API to 3 lines. Import. Instantiate. Ask.

### As a side note, if you would like to support or contribute to the development of the library:

- Feel free to fork the repo and PR back any additions
- Contact me at aldmnatividad@gmail.com for any suggestions
- Donate to my [Ko-fi here](https://ko-fi.com/liquet) (I do this in my free time so any donation you can give helps me develop more things like this!)
