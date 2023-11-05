using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using OpinionScoreAnalyzer.Models;
using OpinionScoreAnalyzer.Pages;

namespace OpinionScoreAnalyzer.Controller
{
    public class HomeController : Microsoft.AspNetCore.Mvc.Controller
    {
        public static string[] justQuestions = new string[]
        {
            "Вас можна віднести до категорії запеклих сперечальників?",
            "Ваше правило життя «Тихіше їдеш - далі будеш»?",
            "Ви енергійна людина?",
            "Якщо вас зацікавила якась робота, ви можете присвятити їй весь вільний час?",
            "Ви любите довгі розмови на одну тему?",
            "Ви з повагою ставитеся до тих, хто завжди й скрізь відстоює власну думку?",
            "Ви легко відступаєте перед труднощами?",
            "Ви любите весь свій вільний час полежати біля телевізора?",
            "Ви швидко, не надто розмірковуючи, приймаєте важливі рішення?",
            "Ви переконані, що історію роблять сильні, які вміють підкоряти собі інших людей?",
            "Вам властива боязкість і сором'язливість?",
            "У вашому житті є багато різнопланових захоплень?",
            "Ваш життєвий принцип: «Зробив справу - гуляй сміло»?"
        };

        public List<QuestionAndAnswer> questionsAndRightAnswer = new List<QuestionAndAnswer>
        {
            new QuestionAndAnswer { Question = justQuestions[0], Score1 = 2, Score2 = 1, Score3 = 0, Score1Description = "Так", Score2Description = "Не зовсім", Score3Description = "Ні"},
            new QuestionAndAnswer { Question = justQuestions[1], Score1 = 0, Score2 = 1, Score3 = 2, Score1Description = "Так", Score2Description = "Не завжди", Score3Description = "Ні"},
            new QuestionAndAnswer { Question = justQuestions[2], Score1 = 2, Score2 = 1, Score3 = 0, Score1Description = "Так", Score2Description = "Іноді", Score3Description = "Ні"},
            new QuestionAndAnswer { Question = justQuestions[3], Score1 = 2, Score2 = 1, Score3 = 0, Score1Description = "Так", Score2Description = "Не завжди ", Score3Description = "Ні"},
            new QuestionAndAnswer { Question = justQuestions[4], Score1 = 0, Score2 = 1, Score3 = 0, Score1Description = "Так", Score2Description = "Не завжди", Score3Description = "Ні"},
            new QuestionAndAnswer { Question = justQuestions[5], Score1 = 2, Score2 = 1, Score3 = 0, Score1Description = "Так", Score2Description = "Не завжди", Score3Description = "Ні"},
            new QuestionAndAnswer { Question = justQuestions[6], Score1 = 0, Score2 = 1, Score3 = 2, Score1Description = "Так", Score2Description = "Не завжди", Score3Description = "Ні"},
            new QuestionAndAnswer { Question = justQuestions[7], Score1 = 0, Score2 = 1, Score3 = 2, Score1Description = "Так", Score2Description = "Іноді", Score3Description = "Ні"},
            new QuestionAndAnswer { Question = justQuestions[8], Score1 = 1, Score2 = 2, Score3 = 1, Score1Description = "Так", Score2Description = "Не завжди", Score3Description = "Ні" },
            new QuestionAndAnswer { Question = justQuestions[9], Score1 = 2, Score2 = 1, Score3 = 0 , Score1Description = "Так", Score2Description = "Не дуже", Score3Description = "Ні"},
            new QuestionAndAnswer { Question = justQuestions[10], Score1 = 0, Score2 = 1, Score3 = 2, Score1Description = "Так", Score2Description = "Іноді", Score3Description = "Ні" },
            new QuestionAndAnswer { Question = justQuestions[11], Score1 = 0, Score2 = 1, Score3 = 2, Score1Description = "Так", Score2Description = "Не дуже", Score3Description = "Ні" },
            new QuestionAndAnswer { Question = justQuestions[12], Score1 = 2, Score2 = 1, Score3 = 0 , Score1Description = "Так", Score2Description = "Не завжди", Score3Description = "Ні"}
        };

        public IActionResult Index()
        {
            return View(questionsAndRightAnswer);
        }

        [HttpPost]
        public IActionResult ProcessAnswer(int[] answers)
        {
            int score = 0;

            for (int i = 0; i < answers.Length; i++)
            {
                switch (answers[i])
                {
                    case 1:
                        score += questionsAndRightAnswer[i].Score1;
                        break;
                    case 2:
                        score += questionsAndRightAnswer[i].Score2;
                        break;
                    case 3:
                        score += questionsAndRightAnswer[i].Score3;
                        break;
                    default:
                        // there is nothing
                        break;
                }
            }

            string retText = "";
            if (score >= 0 && score <= 8)
            {
                retText = $"Ваш бал {score} означає, що ви – людина, яка нерідко розмінюється на дрібниці. Швидше за все, ви тільки говорите про те, як хотіли б домогтися чого-небудь, але насправді опускаєте руки, коли з’являються труднощі. Можливо, все це відбувається через те, що ви увесь час боїтеся чийогось несхвалення й хочете бути як всі? Спробуйте поставити перед собою якусь мету й постарайтеся обов'язково досягти її без допомоги друзів і приятелів. Побачивши отриманий результат, ви напевно відчуєте впевненість у собі.";
            }
            else if (score >= 9 && score <= 17)
            {
                retText = $"Ваш бал {score} говорить, що ви досить реально оцінюєте те, що можете зробити, не любите жити безцільно й, поставивши перед собою якесь завдання, намагаєтеся в міру своїх сил вирішити його. Однак ви не завжди домагаєтеся того, чого хотіли. Можливо, через невіру у свої сили й можливості? Або ж вам просто заважає лінь? Спробуйте розібратися в собі, не «розпорошуйтеся на дрібниці», ставте перед собою реальну, досяжну мету.";
            }
            else
            {
                retText =
                    $"Ваш бал {score} свідчить, що, поставивши перед собою ціль, ви здатні досягти її усіма доступними вам способами. Завзятості вам явно не позичати. Ви прагнете все робити по-своєму, навіть якщо доводиться говорити, що «чорне - це біле». От тільки чи не здається вам, що в такий спосіб ви часом втручаєтеся в чуже життя? Будьте більш дипломатичні, і тоді люди потягнуться до вас.";
            }
            ViewData["Text"] = retText;

            return View("Result");
        }

        public IActionResult Result(int score)
        {
            ViewData["Score"] = score;
            return View();
        }
    }
}
