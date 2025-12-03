// using Catalog.API.Features.Tracks.DTOs;
// using Catalog.API.Features.Tracks.Services;
// using Xunit;

// namespace Catalog.API.Test.Features.Tracks;

// public class TrackServiceTests
// {
//     [Fact]
//     public async Task CreateAsync_ShouldCreateTrackAndReturnDto()
//     {
//         // Arrange
//         var service = new TrackService();
//         var createDto = new CreateTrackDto
//         {
//             Name = "Let It Be",
//             AlbumId = 1,
//             GenreId = 1,
//             MediaTypeId = 1,
//             Milliseconds = 243000,
//             UnitPrice = 0.99m
//         };

//         // Act
//         var result = await service.CreateAsync(createDto);

//         // Assert
//         Assert.NotNull(result);
//         Assert.Equal("Let It Be", result.Name);
//         Assert.Equal(1, result.AlbumId);
//         Assert.True(result.TrackId > 0);
//     }

//     [Fact]
//     public async Task GetAllAsync_ShouldReturnAllTracks()
//     {
//         // Arrange
//         var service = new TrackService();
//         await service.CreateAsync(new CreateTrackDto { Name = "Track 1", AlbumId = 1, GenreId = 1, MediaTypeId = 1 });
//         await service.CreateAsync(new CreateTrackDto { Name = "Track 2", AlbumId = 1, GenreId = 1, MediaTypeId = 1 });

//         // Act
//         var result = await service.GetAllAsync();

//         // Assert
//         Assert.NotEmpty(result);
//         Assert.Equal(2, result.Count());
//     }
// }
