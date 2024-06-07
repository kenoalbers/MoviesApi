namespace Kenoalbers.Movies.Api.Features.Movies.Endpoints.Delete;

using Repository;

public class Single(IRepository repository) : Endpoint<Shared.IdRequest>
{
    public override void Configure()
    {
        Delete("/movies/id/{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(Shared.IdRequest request, CancellationToken cancellationToken)
    {
        var deleteMovie = repository.DeleteById(request.Id);

        if (deleteMovie)
            await SendNoContentAsync(cancellationToken);
        else
            await SendNotFoundAsync(cancellationToken);
    }
}