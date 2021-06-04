namespace SharpikLogicXML.Repositories
{
    interface IByePhrasesRepository
    {
        string FindAnswerForQuestion(string question);
        bool CheckInputQuestionForMatch(string question);
        void Load(string fileName);
    }
}
