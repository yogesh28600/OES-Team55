using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using OnlineExamSystem.Models;

namespace OnlineExamSystem.Controllers
{
    public class AdministratorController : Controller
    {
        [HttpPost]
        public string PostAddQuestion(string question_description, string OptionA, string OptionB, string OptionC, string OptionD, string CorrectAnswer,string Difficulty )
        {
            SqlConnection con = new SqlConnection(@"Server=YOGESHKUMAR\SQLEXPRESS;Initial Catalog=OnlineExamSystem;Integrated Security=SSPI;");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Question(Question_Description,OptionA,OptionB,OptionC,OptionD,AnswerKey,DifficultyLevel) values(@QD,@A,@B,@C,@D,@Key,@Difficulty)", con);
            cmd.Parameters.AddWithValue("@QD", question_description);
            cmd.Parameters.AddWithValue("@A", OptionA);
            cmd.Parameters.AddWithValue("@B", OptionB);
            cmd.Parameters.AddWithValue("@C", OptionC);
            cmd.Parameters.AddWithValue("@D", OptionD);
            cmd.Parameters.AddWithValue("@Key", CorrectAnswer);
            cmd.Parameters.AddWithValue("@Difficulty", Difficulty);
            int RowsEffected = cmd.ExecuteNonQuery();
            con.Close();

            if (RowsEffected>0)
            {
                return "question added succesfully";
            }
            else
            {
                return "question not added";
            }
        }

        [HttpPost]
        public IActionResult PostViewQuestion(int QID)
        {
            SqlConnection con = new SqlConnection(@"Server=YOGESHKUMAR\SQLEXPRESS;Initial Catalog=OnlineExamSystem;Integrated Security=SSPI;");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Question where QuestionID=@ID", con);
            cmd.Parameters.AddWithValue("@ID", QID);
            SqlDataReader question = cmd.ExecuteReader();
            Questions questions = new Questions();
            question.Read();
            questions.QuestionId = int.Parse(question[0].ToString());
            questions.Question = question[1].ToString();
            questions.OptionA = question[2].ToString();
            questions.OptionB  = question[3].ToString();
            questions.OptionC = question[4].ToString();
            questions.OptionD = question[5].ToString();
            questions.AnswerKey = question[6].ToString();
            questions.DifficultyLevel = question[7].ToString(); 
            con.Close();           
            return View(questions);
        }
        [HttpPost]
        public IActionResult PostDeleteQuestion(int QID)
        {
            SqlConnection con = new SqlConnection(@"Server=YOGESHKUMAR\SQLEXPRESS;Initial Catalog=OnlineExamSystem;Integrated Security=SSPI;");
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from Question where QuestionID=@ID", con);
            cmd.Parameters.AddWithValue("@ID", QID); 
            int IsAffected=cmd.ExecuteNonQuery();
            ViewBag.IsAffected = IsAffected;
            con.Close();
            return View();
        }
        [HttpPost]
        public IActionResult PostSetQuestionPaper()
        {
            SqlConnection con = new SqlConnection(@"Server=YOGESHKUMAR\SQLEXPRESS;Initial Catalog=OnlineExamSystem;Integrated Security=SSPI;");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Question", con);
            SqlDataReader question = cmd.ExecuteReader();
            Questions questions = new Questions();
            List<Questions> QList=new List<Questions>();
            while(question.Read())
            {
                questions.QuestionId = int.Parse(question[0].ToString());
                questions.Question = question[1].ToString();
                questions.OptionA = question[2].ToString();
                questions.OptionB = question[3].ToString();
                questions.OptionC = question[4].ToString();
                questions.OptionD = question[5].ToString();
                questions.AnswerKey = question[6].ToString();
                questions.DifficultyLevel = question[7].ToString();
                QList.Add(questions);
            }
            con.Close();
            return View(QList);
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
            SqlConnection con = new SqlConnection(@"Server=YOGESHKUMAR\SQLEXPRESS;Initial Catalog=OnlineExamSystem;Integrated Security=SSPI;");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Question", con);
            SqlDataReader question = cmd.ExecuteReader();

            List<Questions> QList = new List<Questions>();
            if(question.HasRows)
            {
                while (question.Read())
                {
                    Questions questions = new Questions();
                    questions.QuestionId = int.Parse(question[0].ToString());
                    questions.Question = question[1].ToString();
                    questions.OptionA = question[2].ToString();
                    questions.OptionB = question[3].ToString();
                    questions.OptionC = question[4].ToString();
                    questions.OptionD = question[5].ToString();
                    questions.AnswerKey = question[6].ToString();
                    questions.DifficultyLevel = question[7].ToString();
                    QList.Add(questions);
                }

            }
            con.Close();
            return View(QList);
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
