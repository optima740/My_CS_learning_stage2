using System.Threading.Tasks;

namespace Space
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var commandHandlerAsync = new CommandHandler();
            await commandHandlerAsync.ExecuteAsync();
        }
    }
}
