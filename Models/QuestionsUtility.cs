using System.Data.SqlClient;
namespace OnlineExamSystem.Models
{
    public class QuestionsUtility:IQuestionsUtility
    {
        public bool AddQuestions(Questions Qn)
        {
            bool IsAdded = false;

            if (Qn != null)
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Server=.;Initial Catalog=OnlineExamSystem;Integrated Security=SSPQ";
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into Question(Question_Description,OptionA,OptionB,OptionC,OptionD,AnswerKey,DifficultyLevel) values(@QD,@A,@B,@C,@D,@Key,@Difficulty)", con);
                cmd.Parameters.AddWithValue("@QD", Qn.Question);
                cmd.Parameters.AddWithValue("@A", Qn.OptionA);
                cmd.Parameters.AddWithValue("@B", Qn.OptionB);
                cmd.Parameters.AddWithValue("@C", Qn.OptionC);
                cmd.Parameters.AddWithValue("@D", Qn.OptionD);
                cmd.Parameters.AddWithValue("@Key", Qn.AnswerKey);
                cmd.Parameters.AddWithValue("@Difficulty", Qn.DifficultyLevel);
                int RowsAffected = cmd.ExecuteNonQuery();
                con.Close();
                if (RowsAffected == 1)
                    IsAdded = true;   
            } 
            return IsAdded;
        }
        public bool DeleteQuestions(int ID)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Server=.;Initial Catalog=OnlineExamSystem;Integrated Security=SSPQ";
            con.Open();
            SqlCommand cmd = new SqlCommand("Delete from Question where QuestionID=ID", con);
            int RowsAffected=cmd.ExecuteNonQuery();
            con.Close();
            if (RowsAffected == 1)
                return true;
            else
                return false;
        }
        public bool ModifyQuestions(int ID, Questions Qn)
        {
            bool Modified=false;
            if(Qn!=null)
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Server=.;Initial Catalog=OnlineExamSystem;Integrated Security=SSPQ";
                con.Open();
                SqlCommand cmd = new SqlCommand("update Question set Question_Description=@QD,OptionA=@A,OptionB=@B,OptionC=C,OptionD=D,AnswerKey=@Key,DifficultyLevel=@Difficulty", con);
                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.Parameters.AddWithValue("@QD", Qn.Question);
                cmd.Parameters.AddWithValue("@A", Qn.OptionA);
                cmd.Parameters.AddWithValue("@B", Qn.OptionB);
                cmd.Parameters.AddWithValue("@C", Qn.OptionC);
                cmd.Parameters.AddWithValue("@D", Qn.OptionD);
                cmd.Parameters.AddWithValue("@Key", Qn.AnswerKey);
                cmd.Parameters.AddWithValue("@Difficulty", Qn.DifficultyLevel);
                int RowsAffected = cmd.ExecuteNonQuery();
                con.Close();
                if(RowsAffected == 1)
                    Modified=true;
            }
            return Modified;
        }
        public Questions ViewQuestion(int ID)
        {
            Questions question = new Questions();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Server=.;Initial Catalog=OnlineExamSystem;Integrated Security=SSPQ";
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Questions where QuestionID=@ID", con);
            cmd.Parameters.AddWithValue("@ID",ID);
            SqlDataReader DR=cmd.ExecuteReader();
            if(DR.HasRows)
            {
                DR.Read();
                question.Question = DR["Question_Description"].ToString();
                question.OptionA = DR["OptionA"].ToString();
                question.OptionB = DR["OptionB"].ToString();
                question.OptionC = DR["OptionC"].ToString();
                question.OptionD = DR["OptionD"].ToString();
                question.AnswerKey = DR["AnswerKey"].ToString();
                question.DifficultyLevel = DR["DifficultyLevel"].ToString();
            }
            con.Close();
            return question;
        }
        //public List<Questions> SetQuestionPaper()
        //{
        //    Questions question = new Questions();
        //    SqlConnection con = new SqlConnection();
        //    con.ConnectionString = "Server=.;Initial Catalog=OnlineExamSystem;Integrated Security=SSPQ";
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand("select * from Questions", con);
        //    SqlDataReader DR = cmd.ExecuteReader();
        //    List<Questions>QuestionsList=new List<Questions>();
        //    if (DR.HasRows)
        //    {
        //        while(DR.Read())
        //        {
        //            question.Question = DR["Question_Description"].ToString();
        //            question.OptionA = DR["OptionA"].ToString();
        //            question.OptionB = DR["OptionB"].ToString();
        //            question.OptionC = DR["OptionC"].ToString();
        //            question.OptionD = DR["OptionD"].ToString();
        //            question.AnswerKey = DR["AnswerKey"].ToString();
        //            question.DifficultyLevel = DR["DifficultyLevel"].ToString();
        //            QuestionsList.Add(question);
        //        }

        //    }
        //    con.Close();
        //    return QuestionsList;
        //}
        public List<Questions> ViewQuestionPaper()
        {
            Questions question = new Questions();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Server=.;Initial Catalog=OnlineExamSystem;Integrated Security=SSPQ";
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Questions", con);
            SqlDataReader DR = cmd.ExecuteReader();
            List<Questions> QuestionsList = new List<Questions>();
            if (DR.HasRows)
            {
                while (DR.Read())
                {
                    question.QuestionId = int.Parse(DR["QuestionID"].ToString());
                    question.Question = DR["Question_Description"].ToString();
                    question.OptionA = DR["OptionA"].ToString();
                    question.OptionB = DR["OptionB"].ToString();
                    question.OptionC = DR["OptionC"].ToString();
                    question.OptionD = DR["OptionD"].ToString();
                    question.AnswerKey = DR["AnswerKey"].ToString();
                    question.DifficultyLevel = DR["DifficultyLevel"].ToString();
                    QuestionsList.Add(question);
                }

            }
            con.Close();
            return QuestionsList;
        }
    }
}
