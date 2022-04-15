namespace OnlineExamSystem.Models
{
    public class Questions
    {
        public int QuestionId { get; set; }
        public string Question { get; set; }
        public string OptionA { get; set; }
        public string OptionB { get; set; }
        public string OptionC { get; set; }
        public string OptionD { get; set; }
        public string AnswerKey { get; set; }
        public string DifficultyLevel { get; set; }
    }
}
