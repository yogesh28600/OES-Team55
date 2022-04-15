namespace OnlineExamSystem.Models
{
    public interface IQuestionsUtility
    {
        public bool AddQuestions(Questions Qn);
        public bool DeleteQuestions(int ID);
        public bool ModifyQuestions(int ID, Questions Qn);
        public Questions ViewQuestion(int ID);
        //public List<Questions> SetQuestionPaper();
        public List<Questions> ViewQuestionPaper();
    }
}
