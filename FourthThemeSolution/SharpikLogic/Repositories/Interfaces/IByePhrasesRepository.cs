namespace SharpikLogic.Repositories
{
    interface IByePhrasesRepository
    {
        string FindAnswerForQuestion(string question);
        bool CheckInputQuestionForMatch(string question);
    }
}
