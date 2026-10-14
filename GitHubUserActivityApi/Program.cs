namespace GitHubUserActivityApi;

class Program
{
    private static async Task Main(string[] args)
    {
        Console.WriteLine("Hello to the GitHub User Activity API");

        var choice = '0';

        Console.WriteLine("Enter your username: ");
        var username = Console.ReadLine();
        Console.WriteLine();
        Console.WriteLine($"Received username: {username}");

        Console.WriteLine("----------MENU----------");
        Console.WriteLine("1 - Get my recent activity.");
        choice = Console.ReadKey().KeyChar;

        HttpClient client = new HttpClient();

        Console.WriteLine();
        if (choice == '1')
        {
            Console.WriteLine("Getting your recent public activity from GitHub...");
            var gitHubClient = new GitHubClient(client, username!);
            await gitHubClient.GetMyPublicEventsAsync();
        }
        else
        {
            Console.WriteLine("Exiting the application...");
        }
    }
}