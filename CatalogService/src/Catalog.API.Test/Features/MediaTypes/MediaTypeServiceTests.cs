using Catalog.API.Features.MediaTypes.DTOs;
using Catalog.API.Features.MediaTypes.Services;
using Xunit;

namespace Catalog.API.Test.Features.MediaTypes;

public class MediaTypeServiceTests
{
    [Fact]
    public async Task CreateAsync_ShouldCreateMediaTypeAndReturnDto()
    {
        // Arrange
        var service = new MediaTypeService();
        var createDto = new CreateMediaTypeDto { Name = "MP3" };

        // Act
        var result = await service.CreateAsync(createDto);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("MP3", result.Name);
        Assert.True(result.MediaTypeId > 0);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnAllMediaTypes()
    {
        // Arrange
        var service = new MediaTypeService();
        await service.CreateAsync(new CreateMediaTypeDto { Name = "MP3" });
        await service.CreateAsync(new CreateMediaTypeDto { Name = "WAV" });

        // Act
        var result = await service.GetAllAsync();

        // Assert
        Assert.NotEmpty(result);
        Assert.Equal(2, result.Count());
    }
}
