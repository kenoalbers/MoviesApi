namespace Kenoalbers.Movies.Api.Features.Movies.Endpoints.Get;

using Repository;

public class MultipleByName(IRepository repository)
    : Endpoint<Shared.NameRequest, List<Shared.Response>, Shared.ListMapper>
{
    public override void Configure()
    {
        Get("/movies/name/{name}");
        Description(builder => builder
                .Accepts<Shared.NameRequest>()
                .Produces<List<Shared.Response>>(200, "application/json")
                .ProducesProblemFE<InternalErrorResponse>(500),
            clearDefaults: true);
        AllowAnonymous();
    }

    public override async Task HandleAsync(Shared.NameRequest request, CancellationToken cancellationToken)
    {
        await SendOkAsync(Map.FromEntity(repository.RetrieveByName(request.Name)), cancellationToken);
    }
}