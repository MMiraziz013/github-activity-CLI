namespace GitHubUserActivityApi;

public interface IGitHubClient
{
    public Task GetMyPublicEventsAsync();
}