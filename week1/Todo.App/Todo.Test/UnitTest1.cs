using System.Net;
using FluentAssertions;
using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Web.Test;

public class Response<T>
{
    public bool? success { set; get; }
    public string? error { set; get; }
    public string? message { set; get; }
    public T? data { set; get; }
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

        var created = await response.Content.ReadFromJsonAsync<Response<TaskItem>>();
        created!.success.Should().Be(true);
        created!.message.Should().Be("Task created");
        created!.data.Should().NotBeNull();
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

        var created = await response.Content.ReadFromJsonAsync<Response<TaskItem>>();
        created!.success.Should().Be(false);
        created!.message.Should().Be("Title is required");
    }

    [Fact]
    public async Task PASS_PUTUpdateTaskItem()
    {
        var newTodo = new
        {
            title = "Learn testing",
            desc = "Adding TaskItem to TaskService"
        };
        var createResponse = await _client.PostAsJsonAsync("/api/tasks", newTodo);
        var created = await createResponse.Content.ReadFromJsonAsync<Response<TaskItem>>();
        var id = created!.data!.id;

        // Act
        var response = await _client.PutAsJsonAsync($"/api/tasks/{id}", newTodo);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var updated = await response.Content.ReadFromJsonAsync<Response<TaskItem>>();
        updated!.success.Should().Be(true);
        updated!.message.Should().Be("Task updated");
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

        var created = await response.Content.ReadFromJsonAsync<Response<TaskItem>>();
        created!.success.Should().Be(false);
        created!.message.Should().Be("Task not found or update failed");
    }

    [Fact]
    public async Task PASS_DELETETaskItem()
    {
        //Arrange
        var createResponse = await _client.PostAsJsonAsync("/api/tasks", new
        {
            title = "Temp Task",
            desc = "To be deleted"
        });
        var created = await createResponse.Content.ReadFromJsonAsync<Response<TaskItem>>();
        var id = created!.data!.id;

        // Act
        var response = await _client.DeleteAsync($"/api/tasks/{id}");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var deleted = await response.Content.ReadFromJsonAsync<Response<TaskItem>>();
        deleted!.success.Should().Be(true);
        deleted!.message.Should().Be("Operation completed successfully");
    }

    [Fact]
    public async Task FAIL_DELETETaskItem()
    {
        //Arrange
        //No Tasks in list

        // Act
        var response = await _client.DeleteAsync($"/api/tasks/999999");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

        var deleted = await response.Content.ReadFromJsonAsync<Response<TaskItem>>();
        deleted!.success.Should().Be(false);
        deleted!.message.Should().Be("Operation failed");
        deleted!.error.Should().Be("Id not found");
    }

    [Fact]
    public async Task PASS_GETTaskItemById()
    {
        //Arrange
        var addTask = await _client.PostAsJsonAsync("/api/tasks", new
        {
            title = "Get this task",
            desc = "Unit test to get a task by id"
        });
        var created = await addTask.Content.ReadFromJsonAsync<Response<TaskItem>>();
        var id = created!.data!.id;

        // Act
        var data = await _client.GetAsync($"/api/tasks/{id}");

        // Assert
        data.StatusCode.Should().Be(HttpStatusCode.OK);

        var task = await data.Content.ReadFromJsonAsync<Response<TaskItem>>();
        task!.success.Should().Be(true);
        task!.message.Should().Be("Operation completed successfully");
        task!.data!.id.Should().Be(id);
        task!.data!.title.Should().Be("Get this task");
    }

    [Fact]
    public async Task FAIL_GETTaskItemById()
    {
        //Arrange
        //No Tasks in list

        // Act
        var data = await _client.GetAsync($"/api/tasks/99999");

        // Assert
        data.StatusCode.Should().Be(HttpStatusCode.BadRequest);

        var task = await data.Content.ReadFromJsonAsync<Response<TaskItem>>();
        task!.success.Should().Be(false);
        task!.message.Should().Be("Operation failed");
        task!.error.Should().Be("Id not found");
    }

        [Fact]
    public async Task PASS_GETTaskItemList()
    {
        //Arrange
        Random r = new Random();
        for (int i = 50; i < 70; i++)
        {
            await _client.PostAsJsonAsync("/api/tasks", new
            {
                title = $"Task {i}",
                priority = r.Next(0, 4),
                dueDate = $"2025-06-{i}"
            });

        }

        // Act
        var data = await _client.GetAsync($"/api/tasks");

        // Assert
        data.StatusCode.Should().Be(HttpStatusCode.OK);

        var task = await data.Content.ReadFromJsonAsync<Response<List<TaskItem>>>();
        task!.success.Should().Be(true);
        task!.message.Should().Be("Operation completed successfully");
    }
}