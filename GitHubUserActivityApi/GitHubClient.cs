using System.Net.Http.Headers;
using System.Text.Json;
using GitHubUserActivityApi.DTOs;
using GitHubUserActivityApi.DTOs.PayloadDTOs;

namespace GitHubUserActivityApi;

public class GitHubClient
{
    private readonly HttpClient _client;
    private readonly string _eventsRequestUrl;

    public GitHubClient(HttpClient client, string username)
    {
        _client = client;
        _client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));

        if (!_client.DefaultRequestHeaders.Contains("User-Agent"))
        {
            _client.DefaultRequestHeaders.Add("User-Agent", ".NET-GitHub-Activity-App");
        }

        _eventsRequestUrl = $"https://api.github.com/users/{username}/events";
    }

    public async Task GetMyPublicEventsAsync()
    {
        try
        {
            var response = await _client.GetAsync(_eventsRequestUrl);

            Console.WriteLine($"Status Code: {response.StatusCode}");

            if (response.IsSuccessStatusCode)
            {
                var jsonResult = await response.Content.ReadAsStringAsync();
                var events = JsonSerializer.Deserialize<List<GetActivityResponseDto>>(jsonResult);

                if (events is null || events.Count == 0)
                {
                    Console.WriteLine("No activity found for this user.");
                    return;
                }

                Console.WriteLine($"Found {events.Count} events:\n");

                foreach (var ev in events)
                {
                    ProcessGitHubEvent(ev);
                }
            }
            else
            {
                Console.WriteLine($"Failed to retrieve data. Reason: {response.ReasonPhrase}");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred: {e.Message}");
        }
    }

    private static void ProcessGitHubEvent(GetActivityResponseDto ev)
    {
        Console.WriteLine($"Event ID: {ev.Id} | Type: {ev.Type} | Repo: {ev.Repo?.Name}");

        switch (ev.Type)
        {
            case "WatchEvent":
                // Deserialize the JsonElement directly into WatchPayloadDto
                var watchPayload = ev.Payload.Deserialize<WatchEventPayloadDto>();
                Console.WriteLine($"  [Watch] Action: {watchPayload?.Action}");
                break;

            case "CommitCommentEvent":
                var commitCommentPayload = ev.Payload.Deserialize<CommitCommentEventPayloadDto>();
                Console.WriteLine($" [Commit Comment] Action:{commitCommentPayload?.Action} | Comment: {commitCommentPayload?.Comment}");
                break;

            case "CreateEvent":
                var createPayload = ev.Payload.Deserialize<CreateEventPayloadDto>();
                Console.WriteLine($" [Create] Branch: {createPayload?.Ref} | Description: {createPayload?.Description == null}");
                break;

            case "DeleteEvent":
                var deletePayload = ev.Payload.Deserialize<DeleteEventPayloadDto>();
                Console.WriteLine($" [Delete] Branch: {deletePayload?.Ref} | Object deleted: {deletePayload?.RefType}");
                break;

            case "DiscussionEvent":
                var discussionPayload = ev.Payload.Deserialize<DiscussionEventPayloadDto>();
                Console.WriteLine($" [Discussion] Branch: {discussionPayload?.Action} | Discussion: {discussionPayload?.Discussion}");
                break;

            case "ForkEvent":
                var forkPayload = ev.Payload.Deserialize<ForkEventPayloadDto>();
                Console.WriteLine($" [Fork] Branch: {forkPayload?.Action} | Forkee: {forkPayload?.Forkee}");
                break;

            case "GollumEvent":
                var gollumEvent = ev.Payload.Deserialize<GollumEventPayloadDto>();
                if (gollumEvent != null)
                {
                    foreach (var page in gollumEvent.GollumPageDtos)
                    {
                        Console.WriteLine($" [Page]: {page.PageName} | Action: {page.Action} | URL: {page.HtmlUrl}");
                    }
                }
                else
                {
                    Console.WriteLine("Error while deserializing the gollum event");
                }
                break;

            case "IssueCommentEvent":
                var issueCommentPayload = ev.Payload.Deserialize<IssueCommentEventPayloadDto>();
                Console.WriteLine($" [Action] {issueCommentPayload?.Action} | Issue: {issueCommentPayload?.Issue} | Comment: {issueCommentPayload?.Comment}");
                break;

            case "PushEvent":
                // Deserialize the JsonElement into PushPayloadDto
                var pushPayload = ev.Payload.Deserialize<PushEventPayloadDto>();
                Console.WriteLine($"  [Push] Branch: {pushPayload?.Ref} | Head Commit: {pushPayload?.Head}");
                break;

            default:
                Console.WriteLine($"  [Unhandled Event Type]: {ev.Type}");
                break;
        }

        Console.WriteLine(new string('-', 50));
    }
}