namespace Kenoalbers.Movies.Api.Features.Movies.Repository;

using Entities;
using Data;

public class Repository(Mock mock) : IRepository
{
    private readonly List<Movie> _movies = mock!.GetMockData();

    public void Create(Movie movie) => _movies.Add(movie);
    public List<Movie> RetrieveAll() => _movies;
    public List<Movie> RetrieveByName(string name) => _movies.FindAll(movie => movie.Name == name);
    public Movie? RetrieveById(int id) => _movies.Find(movie => movie.Id == id);
    public bool DeleteById(int id) => _movies.Remove(RetrieveById(id)!);
}