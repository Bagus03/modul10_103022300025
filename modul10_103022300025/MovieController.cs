using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using modul10_103022300025;

namespace modul10_103022300025
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : ControllerBase
    {
        private static List<string> stars1 = new List<string>
        {
            new string ("tim robbins"),
             new string ("morgan freeman"),
              new string ("bob gunton"),
        };

        private static List<string> stars2 = new List<string>
        {
            new string ("marlon brando"),
             new string ("al pacino"),
              new string ("james caan"),
        };

        private static List<string> stars3 = new List<string>
        {
            new string ("christian bale"),
             new string ("heath ledger"),
              new string ("aaron eckhart"),
        };
        private static List<Movie> MovieList = new List<Movie>
        {
            new Movie ("the shawsank redemtion","frank darabont", stars1, "A banker convicted of uxoricide forms a friendship over a quarter century with a hardened convict, while maintaining his innocence and trying to remain hopeful through simple compassion." ),
            new Movie ("the godfather","frank darabont", stars2, "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son." ),
            new Movie ("the dark knight","crishtoper nolan", stars3, "When a menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman, James Gordon and Harvey Dent must work together to put an end to the madness." ),

        };

        [HttpGet]
        public ActionResult<IEnumerable<Movie>> GetAllMovie()
        {
            return MovieList;
        }

        [HttpGet("{index}")]
        public ActionResult<Movie> GetMahasiswaByIndex(int index)
        {
            if (index >= 0 && index < MovieList.Count)
            {
                return MovieList[index];
            }
            return NotFound(new { message = "Movie tidak ditemukan" });
        }

        [HttpPost]
        public ActionResult AddMahasiswa([FromBody] Movie movie)
        {
            if (movie != null && !string.IsNullOrEmpty(movie.title))
            {
                MovieList.Add(movie);
                return Ok(new { message = "Movie berhasil ditambahkan" });
            }
            return BadRequest(new { message = "Data Movie tidak lengkap" });
        }


        [HttpDelete("{index}")]
        public ActionResult DeleteMovie(int index)
        {
            if (index >= 0 && index < MovieList.Count)
            {
                var deleted = MovieList[index];
                MovieList.RemoveAt(index);
                return Ok(new { message = "Movie berhasil dihapus", deleted });
            }
            return NotFound(new { message = "Movie tidak ditemukan" });
        }
    }
}

