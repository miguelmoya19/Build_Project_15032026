using Moq;
using Software.Application.Services;
using Software.Domain.Interfaces.Repository;
using Software.Domain.Rules;
using Software.Infraestructure.Persistence;

using Xunit;
public class TaskServiceTests
{
    private readonly Mock<IRepositoryTask> _taskRepositoryMock;
    private readonly TaskServices _service;

    public TaskServiceTests()
    {
        _taskRepositoryMock = new Mock<IRepositoryTask>();
        _service = new TaskServices(_taskRepositoryMock.Object);
    }

    [Fact]
    public async Task CreateTask_ShouldThrow_WhenDeveloperHasTooManyTasks()
    {
        var dto = new TaskModel
        {
            AssigneeId = 1,
            Title = "Test Task",
            Priority = "High",
            EstimatedComplexity = 3,
            DueDate = DateTime.UtcNow.AddDays(3)
        };

        await Assert.ThrowsAsync<Exception>(() =>
            _service.InsertInformationTask(dto));
    }

    [Fact]
    public void ValidateFieldDescription_ShouldThrow_WhenDescriptionIsNull()
    {
        Assert.Throws<Exception>(() =>
            TaskValidator.ValidateFieldDescription(null));
    }

    [Fact]
    public void ValidateFieldTitle_ShouldThrow_WhenTitleIsEmpty()
    {
        Assert.Throws<Exception>(() =>
            TaskValidator.ValidatorLengthTitle(""));
    }

    [Fact]
    public void ValidateEstimatedComplexity_ShouldThrow_WhenComplexityIsZero()
    {
        Assert.Throws<Exception>(() =>
            TaskValidator.ValidatorEstimatedComplexity(0));
    }
}