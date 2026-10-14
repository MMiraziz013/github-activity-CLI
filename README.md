# Github Activity CLI-API

This project is a simple CLI HTTP client to get recent activity from the runner's github.

---

## Architecture & Setup

### Constructor Dependencies
* **`HttpClient`**: Injected via dependency injection to handle HTTP communication.
* **`username`**: A string representing the target GitHub user whose activity feed will be queried.

### Request Headers Configuration
* **API Version Header**: Automatically adds `application/vnd.github.v3+json` to comply with GitHub REST API requirements.
* **User-Agent Header**: Automatically injects a default user-agent header (`.NET-GitHub-Activity-App`) if none is explicitly present on the client.
* **Endpoint Construction**: Dynamically builds the targeted REST endpoint URL: `https://api.github.com/users/{username}/events`.

---

## Core Methods

### 1. `GetMyPublicEventsAsync()`
Handles the retrieval and initial processing of the user's public event feed.

* **Asynchronous Request**: Sends an HTTP GET request to the configured GitHub events endpoint.
* **Status Handling**: Inspects the response status code:
    * **Success (`IsSuccessStatusCode` == true)**: Reads the response body as a JSON string and deserializes it into a `List<GetActivityResponseDto>`.
    * **Empty Feed**: Detects if the event list is null or empty, notifying the user.
    * **Failure**: Logs failure details and the reason phrase to the console.
* **Exception Safety**: Wrapped in a `try-catch` block to handle network timeouts, serialization errors, or unhandled exceptions gracefully.

### 2. `ProcessGitHubEvent(GetActivityResponseDto ev)`
Processes individual event items extracted from the feed. It prints basic metadata (Event ID, Type, and Repository Name) and routes the raw JSON payload (`ev.Payload`) using a strongly-typed switch-case parser.

---

## Supported Event Types & Payload Deserialization

The module uses `System.Text.Json` to deserialize `JsonElement` payloads into specific Data Transfer Objects (DTOs):

| Event Type | Target DTO | Mapped Details |
| :--- | :--- | :--- |
| **`WatchEvent`** | `WatchEventPayloadDto` | Displays star/watch actions. |
| **`CommitCommentEvent`** | `CommitCommentEventPayloadDto` | Logs comment actions and comment body text. |
| **`CreateEvent`** | `CreateEventPayloadDto` | Shows created branch/reference (`Ref`) and description status. |
| **`DeleteEvent`** | `DeleteEventPayloadDto` | Displays deleted references and the object type (`RefType`). |
| **`DiscussionEvent`** | `DiscussionEventPayloadDto` | Logs discussion actions and associated discussion info. |
| **`ForkEvent`** | `ForkEventPayloadDto` | Displays fork actions and forkee details. |
| **`GollumEvent`** | `GollumEventPayloadDto` | Iterates through wiki page updates, logging page names, actions, and HTML URLs. |
| **`IssueCommentEvent`** | `IssueCommentEventPayloadDto` | Logs issue comment actions, issues, and comments. |
| **`PushEvent`** | `PushEventPayloadDto` | Shows pushed branch references (`Ref`) and head commit hashes. |
| **Default / Unhandled** | *None* | Gracefully flags and logs any unrecognized or unsupported event types. |

---

project reference link: https://roadmap.sh/projects/github-user-activity