namespace SharpikLogicXML.Repositories
{
    interface IAphorismsRepository
    {
        string FindAnswerForQuestion();
        void Load(string fileName);
    }
}
