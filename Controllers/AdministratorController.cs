using Microsoft.AspNetCore.Mvc;

namespace OnlineExamSystem.Controllers
{
    public class AdministratorController : Controller
    {
        [HttpPost]
        public string PostAddQuestion(string question_description, string OptionA, string OptionB, string OptionC, string OptionD)
        {
            return "Question:"+question_description + "\n" +"A: "+ OptionA + "\n"+ "B: "+OptionB + "\n" +"C: "+OptionC + "\n" + "D: "+OptionD;
        }

        public IActionResult AddQuestions()
        {
            return View();
        }

        public IActionResult ViewQuestion()
        {
            return View();
        }

        public IActionResult DeleteQuestions()
        {
            return View();
        }

        public IActionResult ModifyQuestions()
        {
            return View();
        }
        public IActionResult SetQuestionPaper()
        {
            return View();
        }
        public IActionResult ViewQuestionPaper()
        {
            return View();
        }
        public IActionResult GenerateReport()
        {
            return View();
        }
        public IActionResult SearchExamInfo()
        {
            return View();
        }
    }
}
