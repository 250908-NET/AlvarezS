using System.Net;
using FluentAssertions;
using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http.Json;

namespace Web.Test;

public class Response
{
    public bool? success { set; get; }
    public string? error { set; get; }
    public string? message { set; get; }
    public TaskItem? data { set; get; }
}

public class ApiTest : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public ApiTest(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task PASS_POSTAddTaskItem()
    {
        var newTodo = new
        {
            title = "Learn testing",
            desc = "Adding TaskItem to TaskService"
        };

        // Act
        var response = await _client.PostAsJsonAsync("/api/tasks", newTodo);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var created = await response.Content.ReadFromJsonAsync<Response>();
        created!.success.Should().Be(true);
        created!.message.Should().Be("Task created");
        // created!.taskItem.Should().NotBeNull();
        // created!.taskItem!.id.Should().Be(1);
    }

    [Fact]
    public async Task FAIL_POSTAddTaskItem()
    {
        var newTodo = new
        {
            desc = "Adding TaskItem to TaskService"
        };

        // Act
        var response = await _client.PostAsJsonAsync("/api/tasks", newTodo);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

        var created = await response.Content.ReadFromJsonAsync<Response>();
        created!.success.Should().Be(false);
        created!.message.Should().Be("Title is required");
    }

    [Fact]
    public async Task PASS_PUTUpdateTaskItem()
    {
        var newTodo = new
        {
            title = "Update title",
            desc = "Updating TaskItem 1 in TaskService"
        };

        // Act
        var response = await _client.PutAsJsonAsync("/api/tasks/1", newTodo);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var created = await response.Content.ReadFromJsonAsync<Response>();
        created!.success.Should().Be(true);
        created!.message.Should().Be("Task updated");
    }

    [Fact]
    public async Task FAIL_PUTUpdateTaskItem()
    {
        
        var newTodo = new
        {
            title = "Update title",
            desc = "Updating TaskItem 2 in TaskService"
        };

        // Act
        var response = await _client.PutAsJsonAsync("/api/tasks/2", newTodo);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

        var created = await response.Content.ReadFromJsonAsync<Response>();
        created!.success.Should().Be(false);
        created!.message.Should().Be("Task not found or update failed");
    }
    
    [Fact]
    public async Task PASS_DELETETaskItem()
    {
        //Arrange
        var createResponse = await _client.PostAsJsonAsync("/api/tasks", new {
            title = "Temp Task",
            desc = "To be deleted"
        });
        var created = await createResponse.Content.ReadFromJsonAsync<Response>();
        var id = created!.data!.id;

        // Act
        var response = await _client.DeleteAsync($"/api/tasks/{id}");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var deleted = await response.Content.ReadFromJsonAsync<Response>();
        deleted!.success.Should().Be(true);
        deleted!.message.Should().Be("Operation completed successfully");
    }
}