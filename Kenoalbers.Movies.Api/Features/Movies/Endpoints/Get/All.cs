namespace Kenoalbers.Movies.Api.Features.Movies.Endpoints.Get;

using Repository;

public class All(IRepository repository) : EndpointWithoutRequest<List<Shared.Response>, Shared.ListMapper>
{
    public override void Configure()
    {
        Get("/movies");
        Description(builder => builder
                .Produces(200)
                .ProducesProblemFE<InternalErrorResponse>(500),
            clearDefaults: true); 
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken cancellationToken)
    {
        await SendOkAsync(Map.FromEntity(repository.RetrieveAll()), cancellationToken);
    }
}