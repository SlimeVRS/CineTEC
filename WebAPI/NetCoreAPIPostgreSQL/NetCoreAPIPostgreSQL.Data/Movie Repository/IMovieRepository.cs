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
        Task<IEnumerable<Movie>> GetAllMovies();                // Gets all the movies
        Task<Movie> GetMovieDetails(int id_movie);              // Gets a movie by id
        Task<bool> InsertMovie(Movie rol);                      // Inserts a new movie
        Task<bool> UpdateMovie(Movie rol);                      // Updates a movie
        Task<bool> DeleteMovie(Movie rol);                      // Deletes a movie
        Task<bool> InsertMovieFrontEnd(MovieFRONTEND movie);    // Inserts a movie using names of director, protagonist and classification
    }
}
