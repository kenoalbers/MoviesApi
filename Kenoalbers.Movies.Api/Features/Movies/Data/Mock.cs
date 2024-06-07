namespace Kenoalbers.Movies.Api.Features.Movies.Data;

using Entities;

public static class Mock
{
    public static List<Movie> GetMockData() =>
    [
        new Movie
        {
            Id = 1,
            Name = "Jaws"
        },
        new Movie
        {
            Id = 2,
            Name = "Saving Private Ryan"
        },
        new Movie
        {
            Id = 3,
            Name = "E.T. the Extra-Terrestrial"
        }
    ];
}