namespace Kenoalbers.Movies.Api.Features.Movies.Endpoints.Get;

using Repository;
using Entities;

public class Single(IRepository repository) : Endpoint<Shared.IdRequest, Shared.Response, Mapper>
{
    public override void Configure()
    {
        Get("/movies/id/{id}");
        Description(builder => builder
                .Accepts<Shared.IdRequest>()
                .Produces<Shared.Response>(200, "application/json")
                .Produces(404)
                .ProducesProblemFE<InternalErrorResponse>(500),
            clearDefaults: true);
        AllowAnonymous();
    }

    public override async Task HandleAsync(Shared.IdRequest req, CancellationToken cancellationToken)
    {
        var movie = repository.RetrieveById(req.Id);

        if (movie is not null)
            await SendOkAsync(Map.FromEntity(movie), cancellationToken);
        else
            await SendNotFoundAsync(cancellationToken);
    }
}

public class Mapper : ResponseMapper<Shared.Response, Movie>
{
    public override Shared.Response FromEntity(Movie movie) =>
        new() { Id = movie.Id, Name = movie.Name };
}