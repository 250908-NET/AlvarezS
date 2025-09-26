using System.Net;
using System.Net.Http.Json;
using Xunit;
using EventManager.API;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Text.Json.Nodes;
using FluentAssertions;
using Test.Responses;


namespace EventManager.Tests
{
    public class EventApiTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public EventApiTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task PostEvent_CreatesEvent()
        {
            // Arrange
            var newEvent = new
            {
                title = "Integration Test Event",
                description = "Learn how to do unit testing here!",
                location = "Room 209",
                startDate = "2025-08-16",
                endDate = "2025-08-18",
                startTime = "15:00",
                endTime = "20:00"
            };

            // Act
            var response = await _client.PostAsJsonAsync("/events", newEvent);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var jsonResponse = await response.Content.ReadFromJsonAsync<JsonNode>();
            jsonResponse.Should().NotBeNull();

            // Access the success property dynamically
            bool success = jsonResponse!["success"]!.GetValue<bool>();
            success.Should().BeTrue();

            // Optionally check data
            var data = jsonResponse["data"];
            data.Should().NotBeNull();
            data!["title"]!.GetValue<string>().Should().Be(newEvent.title);
        }

        [Fact]
        public async Task PostAttendee_CreatesAttendee()
        {
            // Arrange
            var newAttendee = new
            {
                FirstName = "Courtney",
                LastName = "Gimms",
                Phone = "514-879-3154",
                Email = "cgimms.work@gmail.com",
            };

            // Act
            var response = await _client.PostAsJsonAsync("/attendees", newAttendee);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var jsonResponse = await response.Content.ReadFromJsonAsync<JsonNode>();
            jsonResponse.Should().NotBeNull();

            // Access the success property dynamically
            bool success = jsonResponse!["success"]!.GetValue<bool>();
            success.Should().BeTrue();

            // Optionally check data
            var data = jsonResponse["data"];
            data.Should().NotBeNull();
            data!["firstName"]!.GetValue<string>().Should().Be(newAttendee.FirstName);
        }
    }
}
