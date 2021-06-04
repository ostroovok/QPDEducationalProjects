namespace SharpikLogicXML.Repositories
{
    interface IAnecdotesRepository
    {
        string FindAnswerForQuestion(string question);
        bool CheckInputQuestionForMatch(string question);
        void Load(string fileName);
    }
}
