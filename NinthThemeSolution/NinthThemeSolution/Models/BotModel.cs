using ChatBotLibrary;

namespace NinthThemeSolution.Models
{
    public class BotModel
    {
        public string Answer { get; set; }

        public void BotHandle(string message)
        {
            Bot bot = new Bot();
            Answer = bot.HandleMessage(message);
        }
    }
}
