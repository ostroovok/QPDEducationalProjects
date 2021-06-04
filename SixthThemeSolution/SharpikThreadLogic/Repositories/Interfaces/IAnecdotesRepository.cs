namespace SharpikLogic.Repositories
{
    interface IAnecdotesRepository
    {
        string FindAnswerForQuestion(string question);
        bool CheckInputQuestionForMatch(string question);
    }
}
