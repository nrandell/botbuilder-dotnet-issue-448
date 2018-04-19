using Microsoft.Bot;
using Microsoft.Bot.Builder;
using System.Threading.Tasks;

namespace BotIssue448Demo
{
    public class HelloBot : IBot
    {
        public async Task OnTurn(ITurnContext turnContext)
        {
            await turnContext.SendActivity($"Hello there from {turnContext.Activity.Type}");
        }
    }
}
