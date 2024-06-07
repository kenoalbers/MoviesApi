namespace Kenoalbers.Movies.Api.Features.Movies.Endpoints.Shared;

using Entities;

public class ListMapper : ResponseMapper<List<Response>, List<Movie>>
{
    public override List<Response> FromEntity(List<Movie> entity) =>
        entity.Select(movie => new Response { Id = movie.Id, Name = movie.Name }).ToList();
}