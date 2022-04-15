using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace OnlineExamSystem.Controllers
{
    public class AdministratorController : Controller
    {
        [HttpPost]
        public string PostAddQuestion(string question_description, string OptionA, string OptionB, string OptionC, string OptionD)
        {
            SqlConnection con = new SqlConnection(@"Server=YOGESHKUMAR\SQLEXPRESS;Initial Catalog=OnlineExamSystem;Integrated Security=SSPI;");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Question(Question_Description,OptionA,OptionB,OptionC,OptionD,AnswerKey,DifficultyLevel) values(@QD,@A,@B,@C,@D,@Key,@Difficulty)", con);
            cmd.Parameters.AddWithValue("@QD", question_description);
            cmd.Parameters.AddWithValue("@A",OptionA);
            cmd.Parameters.AddWithValue("@B", OptionB);
            cmd.Parameters.AddWithValue("@C", OptionC);
            cmd.Parameters.AddWithValue("@D", OptionD);
            cmd.Parameters.AddWithValue("@Key", OptionB);
            cmd.Parameters.AddWithValue("@Difficulty", "Easy");
            int RowsEffected=cmd.ExecuteNonQuery();
            con.Close();
            if(RowsEffected>0)
            {
                return "question added succesfully";
            }
            else
            {
                return "question not added";
            }
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
