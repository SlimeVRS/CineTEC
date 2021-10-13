using NetCoreAPIPostgreSQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreAPIPostgreSQL.Data.Movie_Repository
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> GetAllMovies();
        Task<Movie> GetMovieDetails(int id_movie);
        Task<bool> InsertMovie(Movie rol);
        Task<bool> UpdateMovie(Movie rol);
        Task<bool> DeleteMovie(Movie rol);
    }
}
