namespace SharpikLogicXML.Repositories
{
    interface IHelloPhrasesRepository
    {
        string FindAnswerForQuestion(string question);
        bool CheckInputQuestionForMatch(string question);
        void Load(string fileName);
    }
}
