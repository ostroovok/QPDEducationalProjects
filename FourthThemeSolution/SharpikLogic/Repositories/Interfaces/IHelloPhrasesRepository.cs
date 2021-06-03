namespace SharpikLogic.Repositories
{
    interface IHelloPhrasesRepository
    {
        string FindAnswerForQuestion(string question);
        bool CheckInputQuestionForMatch(string question);
    }
}
