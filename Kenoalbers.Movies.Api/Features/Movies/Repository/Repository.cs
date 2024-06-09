namespace Kenoalbers.Movies.Api.Features.Movies.Repository;

using Entities;

public class Repository(List<Movie> movies) : IRepository
{
    public Movie Create(Movie movie)
    {
        var id = movies.Count == 0 ? 1 : movies.Last().Id + 1;
        var movieToAdd = new Movie { Id = id, Name = movie.Name };
        
        movies.Add(movieToAdd);
        return movieToAdd;
    }
    public List<Movie> RetrieveAll() => movies;
    public List<Movie> RetrieveByName(string name) => movies.FindAll(movie => string.Equals(movie.Name, name, StringComparison.CurrentCultureIgnoreCase));
    public Movie? RetrieveById(int id) => movies.Find(movie => movie.Id == id);
    public bool DeleteById(int id) => movies.Remove(RetrieveById(id)!);
}