using Kenoalbers.Movies.Api.Entities;

namespace Kenoalbers.Movies.Api.Features.Movies.Repository;

public class Repository(List<Movie> movies) : IRepository
{
    public void Create(Movie movie) => movies.Add(movie);
    public List<Movie> RetrieveAll() => movies;
    public List<Movie> RetrieveByName(string name) => movies.FindAll(movie => movie.Name == name);
    public Movie? RetrieveById(int id) => movies.Find(movie => movie.Id == id);
    public bool DeleteById(int id) => movies.Remove(RetrieveById(id)!);
}