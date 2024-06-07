namespace Kenoalbers.Movies.Api.Features.Movies.Repository;

using Entities;

public interface IRepository
{
        Movie Create(Movie movie);
        List<Movie> RetrieveAll();
        List<Movie> RetrieveByName(string name);
        Movie? RetrieveById(int id);
        bool DeleteById(int id);
}