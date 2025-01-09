using CallTrack.Api.Tests.UnitTests.CallsUnitTestsEndpoints;
using CallTrack.Domain.entities;
using CallTrack.Share.dtos.CallsDTO;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

public class PostCallsUnitTest : IClassFixture<CallsUnitTestEndpoints>
{
    private readonly CallsUnitTestEndpoints _endpoints;

    public PostCallsUnitTest()
    {
        _endpoints = CallsUnitTestEndpoints.Create();
    }

    [Fact]
    public async Task PostCalls_Return_CreatedStatusCode()
    {
        // Arrange
        var newCallDTO = new PostCallsDTO
        {
            Observation = "Observation",
            ReasonId = 1,
            AnalystId = 8,
            CloseDate = DateTime.Now.AddDays(1),
            OpenDate = DateTime.Now,
            CallType = 0,
            Code = "CH18942345",
            Status = 0
        };

        // Act
        var convertedCall = _endpoints._mapper.Map<Calls>(newCallDTO);
        var response = await _endpoints._repository.CreateAsync(convertedCall);

        // Assert
        response.Should().NotBeNull();
        response.Should().BeOfType<CreatedAtRouteResult>();

        var createdResult = response as CreatedAtRouteResult;
        createdResult!.StatusCode.Should().Be(201);
        createdResult.Value.Should().BeEquivalentTo(newCallDTO);
    }

    [Fact]
    public async Task PostCalls_Return_BadRequestStatusCode()
    {
        // Arrange
        var invalidCallDTO = new PostCallsDTO
        {
            Observation = null,
            ReasonId = 0,
            AnalystId = -1,
            CloseDate = DateTime.Now.AddDays(-1),
            OpenDate = DateTime.Now,
            CallType = -1,
            Code = string.Empty,
            Status = 0
        };

        // Act
        var convertedCall = _endpoints._mapper.Map<Calls>(invalidCallDTO);
        var response = await _endpoints._repository.CreateAsync(convertedCall);

        // Assert
        response.Should().BeNull();
    }
}
